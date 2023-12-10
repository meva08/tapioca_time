# Design

**Overall Design:**
“Tapioca Time” is inspired by Overcooked, except our game is single-player and focuses more on quick reactions and getting familiar with the system.  We wanted to create a cute and lighthearted game within the timeframe!

**Art, Sound, and UI Design:**

We used free, public online resources for much of the art and music.
 
**Credits below:**

Tilesets:
JesusCarrasco (https://reliccastle.com/resources/15/)
(https://assetstore.unity.com/packages/2d/unity-learn-2d-beginner-tutorial-resources-urp-140167)

Music:
(https://assetstore.unity.com/packages/audio/music/free-music-tracks-for-games-156413)

SFX: 
(https://assetstore.unity.com/packages/audio/sound-fx/rpg-essentials-sound-effects-free-227708)

Some of the tileset, the UI icons, and the player character animations were made by Chris in Procreate. We focused on a pixel art style for efficiency and to imitate a Pokemon-esque, cute art style. Sound effects were used to accentuate game actions, like getting ingredients and shaking the boba. The UI elements like textboxes, ingredient icons, timer, order box, and money indicators, were placed around the screen to give the player a good sense of what is going on and what needs to be done while not blocking their view of the room. We wanted all the extra elements to make the player feel satisfied and add a crunch to each of their actions. When you shake the boba at the boba shaker, you can hear the sounds. When you get milk, you get a simple textbox to tell you what type of milk it is. 


**Design and Gameplay**

Game objects are essential to creating a game using Unity. They can be thought of as items of the game. Some of them have images so that the user can see and, sometimes, interact with them. Others only have scripts, so they are mostly used to maintain the game flow underneath the hood. In our game, the items that appear on the screen are either designed by ourselves or pulled from online resources. Some of them, such as but not limited to stations and order delivery, are interactable, which is enabled by scripts. 

When the user starts to play, an order is randomly generated. The code script for “Incoming Orders” generates an order and the order is displayed in a dynamic text box at the top right of the screen. However, we work with ingredient IDs and each order comes with an order value that is not shown to the player. Each ingredient adds an integer to the current order’s current value. The type of boba adds a value of 100/200, the tea type adds 10/20, milk type adds 1/2. The ingredient IDs are also added to our current order value as numerical values underneath the hood.

To interact with the stations, the player has to click X, which activates the function for adding the ingredient and its numerical value to our current value. Ultimately, when the player wants to submit the order, our code compares the current value to the order value to determine whether the player got the order correct. If that is the case, the player gains money through our script that adds money to the player’s account when an order is correctly delivered.
 
In our game, we also have a timer, which is frame-independent. When the timer hits zero, the game over screen appears and the player can restart the game. The script for the game over screen sets the object active when the time is up, and depending on the money the player collected in 2 minutes, the player will get a letter grade, which is also shown in a dynamic text box within the game over screen. If the player wants to restart, they can click Q, and it will activate the code that restarts the whole game.

We designed the game to be quite simple, but tricky to get a higher grade. This encourages players to play multiple times to master the locations of each station and their reflexes to get that A+, as the player has to figure out where each ingredient is located and the best order to get each ingredient. There are no deep systems or mechanics, but rather lighthearted fun that prioritizes fast thinking and familiarity with the setup of the space. 
