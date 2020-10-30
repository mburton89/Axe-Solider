using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyHurtPlayer : MonoBehaviour
{
    public float loseHealth;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<AxeSoldier>().TakeDamage(loseHealth);
        }
    }
}
