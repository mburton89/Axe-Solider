using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    private float _initialHealth;
    public float health;

    //Patrol AI
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private Animator _animator;
    public enum AnimationState {Idle, Walk, Attack, Defend}

    public bool shouldPatrol;

    public GameObject healthCanvas;
    public Image healthFill;

    //audio
    [SerializeField] private AudioSource _ouch;
    [SerializeField] private AudioSource _attack;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<AxeSoldier>().transform;
        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        healthCanvas.SetActive(false);
        _initialHealth = health;
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            if (shouldPatrol)
            {
                Patrol();
            }
            else
            {
                Idle();
            }
        }

        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }

        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
        }
    }

    private void Patrol()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

        SwitchAnimation(AnimationState.Walk);
    }

    private void Idle()
    {
        SwitchAnimation(AnimationState.Idle);
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        SwitchAnimation(AnimationState.Walk);
        _attack.Stop();
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

        if (!alreadyAttacked)
        {
            //TODO: Replace line below with custom attacks per enemy time (ie: froggee, turtly boy, archer)
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 20f, ForceMode.Impulse);
            rb.AddForce(transform.up * 2f, ForceMode.Impulse);
            //rb.transform.Rotate(Vector3.forward);
            rb.transform.LookAt(player);

            _attack.Play();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

        SwitchAnimation(AnimationState.Attack);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    void SwitchAnimation(AnimationState newState)
    {
        _animator.SetBool("isIdle", false);
        _animator.SetBool("isWalking", false);
        _animator.SetBool("isAttacking", false);
        _animator.SetBool("isDefending", false);

        if (newState == AnimationState.Idle)
        {
            _animator.SetBool("isIdle", true);
        }
        else if (newState == AnimationState.Walk)
        {
            _animator.SetBool("isWalking", true);
        }
        else if (newState == AnimationState.Attack)
        {
            _animator.SetBool("isAttacking", true);
        }
        else if (newState == AnimationState.Defend)
        {
            _animator.SetBool("isDefending", true);
        }
    }

    public void TakeDamage(float damageToTake)
    {
        healthCanvas.SetActive(true);
        health = health - damageToTake;
        healthFill.fillAmount = health / _initialHealth;
        _ouch.Play();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}