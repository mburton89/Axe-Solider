using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //SoundManager.Instance.PlaySound(collectSound);
            Destroy(gameObject);
            GetCollected();
        }
    }

    public abstract void GetCollected();
}
