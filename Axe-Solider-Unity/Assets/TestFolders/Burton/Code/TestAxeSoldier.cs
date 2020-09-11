using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAxeSoldier : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Give Damage")
        {
            Debug.Log("Hurt Player!");
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
