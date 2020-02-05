﻿using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using Legs;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

//responsible for 
public class LegFactory : MonoBehaviour
{
    [Range(0, 100)] public int LegLength = 20;
     private bool _isGrabbing; //WARNING: THIS IS ATTATCHED TO AN EVENT WHICH IS NEVER UNREJISTERED (when grabber is changed)
    [SerializeField] private SLegSettings _settings;
    [SerializeField] private GameObjectPool _pool;
    [SerializeField] private GameObject _legPrefab;
    [SerializeField] private Color _color = Color.white;
    private Rigidbody2D _rigidbody2D;
    private Segment _tip;
    private LineRenderer _lr;

    private List<Segment> _segs;
    private List<Rigidbody2D> _rbs;
    public event Action<Grabber> NewGrabberEvent;

    void Start()
    {
        _lr = gameObject.AddComponent<LineRenderer>();
        _lr.startColor = _color;
        _lr.endColor = _color;
        _lr.positionCount = LegLength;
        _lr.widthCurve = _settings.ScaleCurve;
        _lr.widthMultiplier = _settings.WidthMultiplier;
        _lr.material = new Material(Shader.Find("Unlit/Texture"));
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _segs = new List<Segment>(LegLength);
        _rbs = new List<Rigidbody2D>(LegLength);

        //spawn initial leg attached to leg factory
        Segment prevSeg;
        SpringJoint2D prevJnt;
        Rigidbody2D prevRb;

        CreateNewSegment(0f, _rigidbody2D, out prevSeg, out prevJnt, out prevRb);

        _segs.Add(prevSeg);
        _rbs.Add(prevRb);

        for (int i = 1; i < LegLength; i++) //spawn rest of legs
        {
            Segment currentSeg;
            SpringJoint2D currentJnt;
            Rigidbody2D currentRb;

            float normIndex = (float) i / (LegLength-1);

            CreateNewSegment(normIndex, prevRb, out currentSeg, out currentJnt, out currentRb);

            prevSeg.Next = currentSeg;
            currentSeg.Previous = prevSeg;
            
            _segs.Add(currentSeg);
            _rbs.Add(currentRb);
            
            prevJnt = currentJnt;
            prevRb = currentRb;
            prevSeg = currentSeg;

            if (i == LegLength - 1) //make last seg new grabber
            {
                currentSeg.BecomeNewGrabber();
                currentSeg.GetComponent<Grabber>().ChangedGrabbedStateEvent += OnGrabberChangedState;
            }

        }
    }

    void CreateNewSegment(float normalizedIndex, in Rigidbody2D toAttachRb, out Segment seg, out SpringJoint2D jnt,
        out Rigidbody2D rb)
    {
        var current = _pool.Spawn();

        seg = current.GetComponent<Segment>();
        jnt = current.GetComponent<SpringJoint2D>();
        rb = current.GetComponent<Rigidbody2D>();

        float deltaY = (_settings.ScaleCurve.Evaluate(normalizedIndex - 0.5f) * _settings.JointSpacing);
        seg.transform.position = toAttachRb.gameObject.transform.position - new Vector3(0, deltaY, 0);
        seg.IsNewGrabberEvent += OnNewGrabber; //notify factory when legs split
        jnt.connectedBody = toAttachRb;

        var spr = current.GetComponent<SpriteRenderer>();
        if (spr != null)
            spr.color = _color;

        jnt.autoConfigureDistance = true;
        jnt.distance = _settings.JointDistance * _settings.ScaleCurve.Evaluate(normalizedIndex)/2;
        jnt.frequency = _settings.MaxFrequency * _settings.FrequencyCurve.Evaluate(normalizedIndex);
        jnt.dampingRatio = _settings.MaxDampening * _settings.DampeningCurve.Evaluate(normalizedIndex);
        
        rb.gravityScale = _settings.MaxGravity * _settings.GravityCurve.Evaluate(normalizedIndex);
        rb.mass = _settings.MaxMass * _settings.MassCurve.Evaluate(normalizedIndex);

        current.transform.localScale = _settings.ScaleCurve.Evaluate(normalizedIndex) * _settings.MaxScale;
        
        
        //seg.transform.position = transform.position + new Vector3(0, toAttachRb.gameObject.transform.position.y - (jnt.distance * 6), 0);

    }

    void Update()
    {
        for (int i = 0; i < _rbs.Count; i++)
            _lr.SetPosition(i, _rbs[i].transform.position);
    }

    public void MoveLegs(Vector2 input)
    {
        if (_isGrabbing)
            _rigidbody2D.AddForce(_settings.ForceOnBody * input);

        for (int i = 0; i < _rbs.Count; i++)
        {
            float normalizedIndex = (float) i / (_rbs.Count - 1);
            if (_isGrabbing)
            {
                _rbs[i].AddForce(_settings.ClosedMaxForce * _settings.ClosedForceCurve.Evaluate(normalizedIndex) * input);
                //Debug.Log("big force");
            }
            else
            {
                //Debug.Log("small force");
                _rbs[i].AddForce(_settings.OpenMaxForce * _settings.OpenForceCurve.Evaluate(normalizedIndex) * input);
            }

        }
        
    }

    private void OnGrabberChangedState(bool trueFalse)
    {
        _isGrabbing = trueFalse;
        //Debug.Log($"grabber changed state {trueFalse}");
    }
    private void OnNewGrabber(Grabber grabber)
    {
        //Debug.Log($"new grabber {grabber}");
        grabber.ChangedGrabbedStateEvent += OnGrabberChangedState;
        NewGrabberEvent?.Invoke(grabber);
        //Debug.Log($"New Grabber Event {grabber}");
    }
}
