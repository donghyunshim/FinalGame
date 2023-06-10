# FinalGame  
Game by Daniel Shim, Nichols Tung, Sehadatullah Atal, Brendan Wang  
  
  
**Core Gameplay Prototype Requirements:**  
  
Audio:  
Background Music  
Three Different Sound Effects for Shooting (Pistol, Automatic, Shotgun)  
Roll Sound Effect  
  
Visual:  
Player Movement Sprites and animation  
Player Roll Sprite in four cardinal directions  
Three Different Enemy Movement Sprites and animation:  
-Hotdog  
-Burger  
-Fries  
Three different Bullet Sprites  
Black and White Floor Tiles  
Table and Bench Sprites  
Kitchen Counter Sprite  
Sink Counter Sprite  
Two Wall Sprites  
Door Sprites  
Game poster Art  
  
Motion:  
Player Movement four cardinal Directions  
Player Roll mechanic  
Enemy Scanning and A* path Finding  
Player Bullet and Variations  
Enemy Bullet and Variations  
  
Prefabs:  
Three bullet Prefabs used by weapons to instantiate  
Three Enemy Prefabs used by spawners to instantiate  
-Burger Enemy  
-Fries Enemy  
-Hotdog Enemy  
  
**Cinematic requirements:**  
  
Non-Interactive Cinematic:  
Presenting Scene aswell as Game Poster Image.  
beggining: presenting screen  
middle: Game Poster  
end: character walking aniamtion  
  
Interactive Cinematic:  
Seemless transition between animation into the interactable game.  
  
Chroeography in code:  
used the equivalent of tweens chains and events in unity to create a coherent  
cinematic for the begining of the game.  
  
**Scene Flow Prototype:**  
  
Scene Types:  
Main Title  
Credits  
Settings  
Game  
  
Communication between Scenes:  
The Volume slider Adjusted in the Settings Scene will be carried throughout other scenes that have audio  
  
Reachability:  
All scenes are reachable from Main Menu and Vice Versa. Different Screens Like credits and Settings have  
a back button to allow traversal.  
  
Transitions: Animated Transition when hovering over buttons aswell as when pressing play and moving onto  
next scene.  



