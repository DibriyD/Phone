using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player_data 
{
    int score;
    public float[] position;
    public Player_data(GameObject player)

    {
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        score = player.transform.GetComponent<Pl_move>().score;
    }
}
