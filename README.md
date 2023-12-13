# Bullet Game Project
A game project I have developed for making a game demo similar to [Bullet Inc by Rollic Games.](https://apps.apple.com/tr/app/bullet-inc/id6457264741) I hope this project can help me showcase my game development skills.
## Game Controls
Game can be simply played by pressing Left Key or A Key for left movement and Right Key or D Key for right movement.
## Game Description
In this game players control a gun that shoots bullets to advance through the level. There are several objects that players could shoot. These objects include power up gates, move obstacles or objects that can change your gun's appearance. At the end of the level there are several Money Gates that can be shot for different money rewards. After a player finishes a level, their money transfers to the next level and level name increases by one.
## Game Objects
There are 3 type of gates that players can shoot to gain power ups: Bullet range gates, fire rate gates and double shoot gates. When a player pass through these gates, their powers will increase according to the number on the gates. When gates are on a positive number, their color is green. When gates are on a negative number, their color is red. There are woodden obstacles with numbers on them that can block a gate. If players can shoot these woodden obstacles to zero the gates will become accesable.\
![Alt text](https://github.com/exclamationless/BulletGameProject/blob/main/ProjectImages/DoubleShootGate.png)\
Double Shoot Gates.\
![Alt text](https://github.com/exclamationless/BulletGameProject/blob/main/ProjectImages/DoubleShootExample.png)\
Double Shoot active on player.\
![Alt text](https://github.com/exclamationless/BulletGameProject/blob/main/ProjectImages/fire%20rate%20green.png)\
Positive Fire Rate Gates. One with woodden obstacle.\
![Alt text](https://github.com/exclamationless/BulletGameProject/blob/main/ProjectImages/GatesRed.png)\
Negative Fire Rate and Bullet Range Gates.
-
There are bullet objects that can increase player's bullet damage. Players can shoot these bullet objects to increase the damage. When a player collets these bullet objects, they will transfer to the next Cutscene Gate. When a player passes a Cutscene Gate the damage of our gun's bullets will change accordingly. There is also a Gun Power objects that can change the player gun's appearance. Every ten damage will increase the Gun Power by one. When Gun Power reaches three the gun will become red. When Gun Power reaches five the gun will become black. And when Gun Power reaches ten the gun will become magenta.\
![Alt text](https://github.com/exclamationless/BulletGameProject/blob/main/ProjectImages/BulletObject.png)\
Bullet Objects.\
![Alt text](https://github.com/exclamationless/BulletGameProject/blob/main/ProjectImages/CutsceneGate.png)\
Cutscene gates that hold the Bullet Objects.\
![Alt text](https://github.com/exclamationless/BulletGameProject/blob/main/ProjectImages/GunPowerUpObj.png)\
Gun Power Objects.\
![Alt text](https://github.com/exclamationless/BulletGameProject/blob/main/ProjectImages/RedGun2.png)\
Gun Power reached three, Gun color changed to red.\
There is a user interface that displays Gun Power, Level name and Money to the players. There is also a Main Menu and End of Level Menu that can be clicked to access desired levels.\
![Alt text](https://github.com/exclamationless/BulletGameProject/blob/main/ProjectImages/UserInterface.png)\
User Interface displays the Gun Power , Level Name and Current Money.\
![Alt text](https://github.com/exclamationless/BulletGameProject/blob/main/ProjectImages/MainMenu.png)\
Main Menu interface.\
![Alt text](https://github.com/exclamationless/BulletGameProject/blob/main/ProjectImages/WinMenu.png)\
End of level Menu interface.
