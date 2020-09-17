using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownAxe : MonoBehaviour
{
    public float rotationSpeed;
    private Vector3 _rotation;

    private void Start()
    {
        _rotation = new Vector3(0,0,1);
    }

    private void Update()
    {
        transform.Rotate(_rotation * (rotationSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
