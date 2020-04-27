using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Be able to save it in file
[System.Serializable]
public class PlayerData
{
    public int sceneLevel;
    public int health;
    public float[] position;
    // needs a player class on the gun
    public PlayerData(Player player)
    {
        sceneLevel = player.level;
        health = player.health;

        // position of the player in worldspace
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
