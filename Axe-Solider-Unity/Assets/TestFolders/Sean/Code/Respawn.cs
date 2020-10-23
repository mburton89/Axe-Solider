using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Make empty GameObject in scene then drag it to this name. This will be where Axe Soldier respawns.
    public Transform respawnPoint;

    private void Update()
    {
        // Checks to see if Axe Soldier's health is at 0 or below
        /*if ()
        {
            RespawnPlayer();
        }*/
    }

    private void RespawnPlayer()
    {
        transform.position = respawnPoint.position;
    }

}
