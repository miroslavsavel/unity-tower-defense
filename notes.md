110 grid snapping
scene navigation
https://docs.unity3d.com/Manual/SceneViewNavigation.html
ALT - orbit

edit - grid and snapping - here we set up world grid 

111 text labels
if you want to prevent object rendering fighting (exact posiition of text mesh pro object and cube) -> text mesh pro
extra settings Distance Overlay

112 coordinate system
ExecuteAlways flag
https://docs.unity3d.com/ScriptReference/ExecuteAlways.html
- we would like to update text labels based on position of tile in the world coordinate system
awake()
https://docs.unity3d.com/Manual/ExecutionOrder.html


113 list
moving enemy inside world
empty object enemy

new script attached to Tile asset - Waypoint.cs
news script ettached to the enemy - EnemyMover.cs