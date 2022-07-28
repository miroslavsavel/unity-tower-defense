110 grid snapping
scene navigation
https://docs.unity3d.com/Manual/SceneViewNavigation.html
ALT - orbit
sipky + shift je posun
F - focus on object
edit - grid and snapping - here we set up world grid 
ou can align your scene view camera to your game camera: Select your game camera object in the hierarchy, and use GameObject > Align View To Selected from the Unity Editor Menu.

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


# 114 Coroutines - enemy moving following the hardcoded path
we would like to delay code to print debu and no instantly teleport to the target location
(seen in project boost section - InvokeRepeating) ???
https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html

coroutines???
- works slightly different 
StartCoroutine()
yield
IEnumerator?? return from method
8:00 running of coroutine, they seems to run in paralel

Ex - move object throught waypoints
https://medium.com/eincode/unity-fundamentals-moving-a-game-object-179f708c5d36#:~:text=Change%20position%20in%20the%20code,transform%20property%20of%20the%20object.&text=%2C1%2C1)-,transform.,Simple%20as%20that!
https://answers.unity.com/questions/1470684/how-to-change-position-of-gameobject.html
https://docs.unity3d.com/ScriptReference/GameObject.Find.html

https://answers.unity.com/questions/1710721/how-do-i-move-an-object-to-the-position-of-another.html

coroutines
https://gamedevbeginner.com/coroutines-in-unity-when-and-how-to-use-them/
https://medium.com/@kunaltandon.kt/coroutines-in-unity-6e8a12279364


# 115 importing assets
assts/import package/ custom package


replace tiles with the grass tiles
open our tiles prefab and delete cube and drag and drop grass prefab
we have created nested prefab
but we need some variance
right click on grass prefab and choose unpack

# 116 prefab variance
creating path 
click tile create, prefab variant 
it is the child of prefab
for rotating Tile_RoadStraigh create another prefab variant from Tile_RoadStraight variant

!!nested prefab - overiding
8:50 task - create three differenet prefab variants from Tile_RoadCorner

# 117 smooth enemy movement
delete cylinder enemy
voxel prefab find ram
1:55
- now we would like to move smoothly and face the direction of movement
- enemymover script

Linear interpolation (LERP) for smooth movement
Vector3.LERP(startPosition, endPosition, travelPercent)
3:53
EnemyMover.cs
https://www.youtube.com/watch?v=HRXkeaeImGs
https://www.youtube.com/watch?v=T4yAcPKyRmo

set the direction by LookAt function

# 118 mouse input
collider on tile object - tiles folder
all prefab variants - inherit from base tile object
add box colider to the root object of Tile
waypoint script

git checkout "commithash"
- pozriem sa na historicky commit
git checkout main
- zas ma vrati naspat
https://stackoverflow.com/questions/3601911/how-do-i-undo-a-checkout-in-git


# 119 targeting enemies
Object instantiation in the world  - LOOK for argo assault project
from waypoint script, because we already tracking clicking tiles, change click to console to 

do serializedfield pridame tower prefab



we!!! can place multiple towers on the same spot

add new script to tower prefab
add component to the tower

UnassignedReferenceException
- I have to add balista to the script
drag BalistaTopMesh to the weapon

-----------------------
what are unity quaternions??????
unity LookAt()
unity Object instantiation

https://www.youtube.com/watch?v=d4EgbgTm0Bg



# 120 damaging enemies
add particle system to the balista prefab used in argon assault project
https://learn.unity.com/tutorial/introduction-to-particle-systems#6025fdd9edbc2a112d4f0136
click na BalistaTopMesh-> right click - effects / particle system
render mode mesh
choose balista prefab
balista doesnt contain appropriate material, so choose material the first palette
render alignment - velocity
start speed 30
start life time 2
start size 6.25

!!! collision module
- from planes to world
- lifetime loss set to 1 - it going to kill particle by 100 percent on collision
- reduce radius scale 
dole je tlacidlo visualize bonds to show radius around particle

add collider to the ram - box collider