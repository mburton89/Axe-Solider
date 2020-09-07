using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    // If this doesn't work during class, we can try adding another capsule collider and making that one a trigger.
    // We could also try making the health static. For example it would be public static float Health = 100;

    // Make sure the terrain has tag Terrain checked
    private Vector3 enterPosition;
    private Vector3 exitPosition;

    private void OnTriggerEnter(Collider AxeSoldier)
    {
        if (AxeSoldier.tag == "Terrain")
        {
            print("Enter");

            enterPosition = transform.position;

            if (exitPosition.y - enterPosition.y > 2)
            {
                print("Falling Damage");

                // We will need to replace this with what is right in your code
                // This will make fall damage increase over height, if it is too much we just need to adjust the 5.
                // PlayerHealth.health -= 5 * exitPosition.y - enterPosition.y;

            }
        }
    }

    private void OnTriggerExit(Collider AxeSoldier)
    {
        if (AxeSoldier.tag == "Terrain")
        {
            print("Exit");

            exitPosition = transform.position;
        }
    }
}
