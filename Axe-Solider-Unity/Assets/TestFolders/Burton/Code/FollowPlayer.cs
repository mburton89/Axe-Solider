using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform _player;
    private Vector3 _wayPointPos;
    public float speed;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        _wayPointPos = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, _wayPointPos, speed * Time.deltaTime);
    }
}
