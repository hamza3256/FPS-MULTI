ECS639 Game Development Project

Super Mega Death: Zombie Warzone

Highlighting few key features of this game:

Weapon scope:
Each weapon has a scope mode. The scope mode is made using animations. Each gun was animated from its default, scope-out position and set to a proper scope-in position. Scope mode varies accross different gun types.

Recoil system:
Implemented a script that takes into consideration both the bullet type and weapon type in use by the user. There are three parent objects that cause the recoil animation: Recoil Center, Recoil Position, and Recoil Rotation—all are fixated at specific points of a gun. These are the points where the recoil effect takes place—this is implemented in the WeaponRecoil.cs script which makes use of these points and assigns them random vector coordinates, which is different for each gun type. Moreover, the script also takes into account whether the gun is in scope mode, which reduces the recoil effect; therefore, we have different fields both for when the gun is in scope mode and not.

Animation:
Implemented various types of animations: weapon reload, scope-in/scope-out mode, walk mode, death mode, and recoil effect. 
