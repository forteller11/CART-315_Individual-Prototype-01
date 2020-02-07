## DesignJournal
### NumberOne ::IndvidualPrototypes


#### Original Idea and Rational for Pivot
Originally in the week I had the idea of making a walking simulator/narrative game which would use a maps api to create the 3D levels. I wanted to narrate over these levels and add my own meshes on top of the maps data to create little reminiscent vignettes of past places I’ve lived/have experienced. Unfortunately the maps API that I found in Unity (Mapbox) didn’t provide an adequate level of detail on their satellite generated mesh/texture data. I then tried to get this data pre-runtime by sort of stealing the 3D mesh/texture from google earth using photogrammetry tools and screen capture but it proved finicky and I didn’t manage to get any usable assets…

With this in mind I decided to pivot ideas at the last minute and try to reimplement an old prototype I made in GameMakerStudio in highschool (I was excited to come back to this idea now that for-loops aren’t intimidating).

### The New Prototype
The mechanic is a physics based movement system where each analog stick controls a separate limbs. Players are able to move these arms around and grab onto surfaces to lift themselves up and move. My goal was to attempt to create an elegant input system-- having few controls to learn and having the controls map gesturally to the actions performed in-game. For instance, in my prototype moving up on the right analog stick lifts your right arm up; clenching the controller with your left hand presses the trigger down and simultaneously grabs in-game. Almost all video games feature movement as a part of the interaction. Accordingly, **I wondered what would effect making location itself mechanically challenging, as in my prototype, movement itself (as opposed to precise movement) may represent a learning curve. I also wondered if I could to some extent lower the high skill floor of the game by making the controls gesturally appropriate.**

The major concerns when designing this game was the learning curve, difficulty and resultant frustration. Because in my prototype there is a skill floor below which players will only be able to flail there arms aimlessly (which I found through playtesting wasn’t necessarily so bad!) For these reasons my general design question was: **Is the game frusterating to learn? After players are able to move around, is it satisfying enough to justify taking so much skill that the system is almost forced to become the central mechanic of whatever game it's part of?**

---------------------------------------------------

### Questions for Playtesters and Observations to Make

* How long did it take players to understand that grabbing was necessary to move?

* Did it take players long to first start moving?

* Did players use both of their arms simultanously and independently --- were they able to, for instance, being pushing of with one arm while reaching for the next surface with their other arm? If so, how long did this take? Did it seem like a mental strain?

* **Q**: Do you find the controls intuitive?

* **Q**: Do you find it difficult to keep track of both arms at the same time?

* **Q**: Do you find the movement frustrating?

* **Q**: Do you think the physics glitches (the arms spazzing violently if they get pulled on hard) annoying?

* **Q**: Should I remove the potential for arms to tangle? Do you find it frustrating? Do you like the way it looks?

* **Q**: Do you like that the player’s body never rotates and therefore the left arm always stays on the left side of the player?

* **Q**: What type of game do you see this mechanic fitting into? A Platformer?

* **Q**: Do you like the minimal/abstract graphical style? Might you prefer something more painterly?

---------------------------------------

### Broad Takeaways Post-Playtest
I was surprised at how quickly most players were able to start moving, my first GameMaker version of this game implemented the physics once grabbing less intuitively and the whole feel was much less forgiving and it seemed to really increase the rate at which players were able to pick up the game and begin self-locomoting. Just getting moving seemed to often take less than 10s, leading me to believe that indeed the controls were mapped gesturally well to their corresponding in-game actions; player's answers when asked about the controls confirmed this. However, most players only just started to be able to use both arms at the end of the playtest -- meaning that the learning curve to simply begin ti make use of your two limbs is high-ish.

To my surprise most of the discussion often revolved around the phenomenon of arms “tangling” or “knotting”. Surprisingly, more than half of the players really liked the tangling, and all but one player warmed up to the phenomenon. Generally player’s wanted me to keep it in the game, and seemed to find the learning curve of finding strategies to efficiency detangle, and prevent tangling, satisfying -- despite it completely impeding their ability to move and often dominated their experience of the game for the first few minutes as they tried to escape their quagmire. 

A few players compared the prototype to games like *I Am Bread* and *Getting Over It With Bennet Foddy* and began to approach play as they would other unforgiving, masochistic physics-based games--- the difficulty (tangling, keeping track of both arms) became part of the aesthetic and the frusteration was understood as part of the experience not to be avoided. I found this somewhat surprising because there was no concrete goal which meant that no progress could ever quantitatively being lost which I thought was necessary for these masochistic unforgiving aesthetics. Also I set out to create a satisfying system, so perhaps there is a correlation between games which are extremely frustrating or difficult, but (in part due to the contrast of the frustration and its difficulty) also deeply satisfying if you execute things properly.

One player was frustrated that their body didn’t rotate and felt like it impeded their momentum (and thus satisfaction). Also it increased the tangling and made certain movement awkward as arms had to wrap around each other. But they seemed to become increasingly understanding of the decision. The rest of the players when asked said they appreciated always having the left arm on their left and the right arm on their right. I briefly tested enabling rotation but it wasn’t a fair test because there was no angular dampening and the movement was therefore too jerky.

Overall the prototype was received well, the frusteration of the tangling and difficulty curve (which ended up being not as steep as I suspected) seemed to be either embraced or as put by one player "a necessary evil" to the aesthetic of the game. Overall most players seemed to feel the mechanic felt good and would be worth exploring further.
