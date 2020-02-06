## DesignJournal
### NumberOne ::IndvidualPrototypes


#### Original Idea and Rational for Pivot
Originally in the week I had the idea of making a walking simulator/narrative game which would use a maps api to create the 3D levels. I wanted to narrate over these levels and add my own meshes on top of the maps data to create little reminiscent vignettes of past places I’ve lived/have experienced. Unfortunately the maps API that I found in Unity (Mapbox) didn’t provide an adequate level of detail on their satellite generated mesh/texture data. I then tried to get this data pre-runtime by sort of stealing the 3D mesh/texture from google earth using photogrammetry tools and screen capture but it proved finicky and I didn’t manage to get any usable assets…

With this in mind I decided to pivot ideas at the last minute and try to reimplement an old prototype I made in GameMakerStudio in highschool (I was excited to come back to this idea now that for-loops aren’t intimidating).

### The New Prototype
The mechanic is a physics based movement system where each analog stick controls a separate limbs. Players are able to move these arms around and grab onto surfaces to lift themselves up and move. My whole inspiration for this idea was trying to create elegant input system (only 4 controls) which would still offer a lot of expressiveness to the player. Almost all video games feature movement as a part of the interaction. Accordingly, **I wondered what would happen if the very act of locomotion (not precise movement, but movement itself) became the primary system in the game. I also wondered if I could to some extent lower the high skill floor of the game by making the controls gesturally appropriate.** In my game moving up on the right analog stick lifts your right arm up; clenching the controller with your left hand presses the trigger down and simultaneously grabs in-game.

The major concerns when designing this game was the learning curve, difficulty and resultant frustration. In this prototype there is no direct way to move, you cannot hold up and travel upwards, you must grab onto a surface and lift your body upwards. This means that mechanically the game is elegant as there are very few systems, but also that there is the possibility for extreme frustration because when the very act of moving itself is difficult then there is a floor below which players can do nothing but flail there arms aimlessly (which I found through playtesting wasn’t necessarily so bad!) For these reasons my general design question was: **how frustrating is the game to learn and similarly is the movement satisfying enough to justify this steep curve?**

---------------------------------------------------

### Questions for Playtesters and Observations to Make

* How long did it take players to understand that grabbing was necessary to move?

* Did it take players long to first start moving?

* Did players use both of their arms independently, if so, how long did that take? (Grabbing/pushing with one, while reaching for a new surface with the other).

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
I was surprised at how quickly most players were able to start moving, my first GameMaker version of this game implemented the physics once grabbing less intuitively and the whole feel was much less forgiving and it seemed to really increase the rate at which players were able to pick up the game and begin locomoting. Just getting moving seemed to often take less than 10s, leading me to believe that indeed the controls were mapped gesturally well to their corresponding in-game actions; player's answers when asked about the controls confirmed this. However, most players only just started to be able to use both arms at the end of the playtest -- meaning that the learning curve to just begin make use of your two limbs is high-ish.

To my surprise most of the discussion often revolved around the phenomenon of arms “tangling” or “knotting”. Surprisingly, more than half of the players really liked the tangling, and all but one player warmed up to the phenomenon. Generally player’s wanted me to keep it in the game, and seemed to find the learning curve of finding strategies to efficiency detangle, and prevent tangling, satisfying -- despite it completely impeding their ability to move and often dominated their experience of the game for the first few minutes as they tried to escape their quagmire. 

A few players compared the prototype to games like *I Am Bread* and *Getting Over It With Bennet Foddy* and began to approach play as they would other unforgiving, masochistic physics-based games--- the difficulty (tangling, keeping track of both arms) became part of the aesthetic and the frusteration was understood as part of the experience not to be avoided. I found this somewhat surprising because there was no concrete goal which meant that no progress could ever quantitatively being lost which I thought was necessary for these masochistic unforgiving aesthetics. Also I set out to create a really satisfying experience, so perhaps there is a correlation between games which are extremely frustrating but also (in part to the contrast of the frustration) sometimes deeply satisfying if you execute things properly.

One player was frustrated that their body didn’t rotate and felt like it impeded their momentum (and thus satisfaction). Also it increased the tangling and made certain movement awkward as arms had to wrap around each other. But they seemed to become increasingly understanding of the decision. The rest of the players when asked said they appreciated always having the left arm on their left and the right arm on their right. I briefly tested enabling rotation but it wasn’t a fair test because there was no angular dampening and the movement was therefore too jerky.

Overall the prototype was received well, the frusteration of the tangling and difficulty curve (which ended up being not as steep as I suspected) seemed to be either embraced or as put by one player "a necessary evil" to the aesthetic of the game -- people seemed to like the movement and find it satisfying.


