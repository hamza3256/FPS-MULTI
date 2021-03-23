ECS639 Game Development Project

Super Mega Death: Zombie Warzone

Highlighting few key features of this game:

Weapon scope:
Each weapon has scope mode. The scope mode is enabled through the use of animations. Each gun was recorded from its default position and set to the appropriate scope position. This enables easy scope mode, according to each gun type.

Recoil system:
Devised a script that takes into consideration both the type of bullet the weapons use and the type of gun being used by the player. Three parent objects: Recoil Center, Recoil Position, and Recoil Rotation, are fixated at specific points of all guns. These are the points where the recoil effect takes place—this is implemented in the WeaponRecoil.cs script which makes use of these points and assigns them random vector coordinates, which is different for each gun type, upon firing the gun. Moreover, the script also takes into account whether the gun is in scope mode, which reduces the effect of recoil, hence, we have fields both for when the gun is in scope mode or not.

Animation:
Implemented various types of animations: weapon reload, scope mode, walk mode, death mode, and recoil system. 

Developers: Muhammad Hamza, Sadeq Rahman, and Raj Kadir.
