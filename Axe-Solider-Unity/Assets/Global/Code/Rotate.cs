using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 directionToRotate;
    public float rotationSpeed;
    void Update()
    {
        transform.Rotate(directionToRotate * rotationSpeed * Time.deltaTime);
    }
}
