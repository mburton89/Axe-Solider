using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownAxe : MonoBehaviour
{
    public float rotationSpeed;
    public Transform sprite;
    public Vector3 rotation;

    private void Update()
    {
        sprite.Rotate(rotation * (rotationSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
