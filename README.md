# FinalGame  
Game by Daniel Shim, Nichols Tung, Sehadatullah Atal, Brendan Wang  
[HERE](https://salad-stash.itch.io/culinary-clash?password=7615)  
  
**Cutscene Prototype***  
[HERE](https://salad-stash.itch.io/cutsceneprototype?password=7615)  
  
**Scene Flow Prototype**
[HERE](https://salad-stash.itch.io/cutscenebuild?password=7615)  
  
**Core Gameplay Prototype Requirements:**  
[HERE](https://salad-stash.itch.io/gameplayprototype?password=761)
**Selectable Requirements**  

Advanced visual assets - Unity Particle System  

We were unable to implement more of the requirements specificed  
in the documentation however, we worked very hard on a unique  
A* pathfidning AI that is able to detect obstacles around it and track  
player movements and bullets in order to dodge them. We hope this is satisfactory  
for one of the requirements as it is difficult to implement.  


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

**Theme**

Unleash the power of innovative recipes and advanced cooking techniques as you adapt to a futuristic world, combining cutting-edge technology with traditional culinary practices to defeat mutated fast food enemies

**Contributor Credits**

Lead Developer: Atal Kakar
Production Lead: Atal Kakar
Technology Lead: Nick Tung
Testing Lead: Brendan Wang

**Asset Credits**

All assets were created by Brendan Wang, Nick Tung, and Daniel Shim
