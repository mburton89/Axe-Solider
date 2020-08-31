using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTest2 : MonoBehaviour
{
    public float deathDistance = 0.5f;
    public float distanceAway;
    //public Transform thisObject;
    public Transform target;
    private NavMeshAgent navComponent;
    public float dist;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navComponent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        dist = Vector3.Distance(target.position, transform.position);

        if (dist <= 30)
        {
            navComponent.SetDestination(target.position);

            if (dist >= 30)
            {
                target = null;
            }
        }

        else
        {
            if (target = null)
            {
                target = this.gameObject.GetComponent<Transform>();
            }
            else
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }
    }
}
