using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private Transform _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    void Update()
    {
        Vector3 lookPosition = new Vector3(_player.position.x, transform.position.y, _player.position.z);
        transform.LookAt(lookPosition);
    }
}
