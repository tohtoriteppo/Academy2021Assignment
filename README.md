# Academy2021Assignment

## Test the project

Clone it and open GameScene in Unity

## Bugs

Might hear the player move sound when the game starts.

## Why I did this the way I did?

Since this is a very small project, it affected the implementation quite a bit. I used Main Camera to hold the game controller and the object spawner. A scene always has a main camera
so it made sense to put the game controller there. I used it to track most of the game events and play some sounds. I might have split these functionalities into separate scripts if the
scope of this prototype would have been bigger. 

As the camera follows the player it made sense to have it spawn the objects just above the screen as well. I used an array of objects from which the 
spawnable objects are randomized, the same object is never spawned twice in a row (no matter which it is). I chose this simple spawn logic as it makes sure that some variety is guaranteed. I only 
used a fixed distance interval between the spawns for simplicity, but the size of the object should be taken into account when spawning.
Having the array, It's easy to add more objects to the list for more variety. 

I put player related functionality into its own script to control how the player moves when left mouse is clicked 
and what sounds does it make. The player script also controls what happens when it hits certain objects. It will call functions in game controller when needed. I chose to use tags for obstacles 
as there were so few different cases.

I chose to use Unity's default colors (Color.blue etc.) as there was one for each color of the color wheel sprite. It was simple to use these colors for comparison as well. 

I chose to just reload the scene when the player decides to restart the game. I thought that in this scope it's easier to do it that way as there is nothing that needs to be kept around after losing.

I chose to restrict the max velocity of the player as it seemed easier to control it that way.

## Written part

Features I would like to add:

1. More obstacles. I would implement them by designing and testing different type of new obstacles to see which work and are fun.
2. Highscore system. I would implement it by checking whether the current score exceeds the saved highscore when the player dies. I would probably use PlayerPrefs for this simple saving system.
3. Make variance to obstacles. Their size, position, and spin speed etc. are a bit randomized. 
4. Make the game harder as the player gets further. For instance the above properties could be used to make obstacles harder the further the player gets. 
5. Pausing would be nice.

Note. Depending of the scope of the features, I might refactor code. For instance inheritance for obstacles could be a good idea and split GameController to multiple classes as it does a bit everything.
 
