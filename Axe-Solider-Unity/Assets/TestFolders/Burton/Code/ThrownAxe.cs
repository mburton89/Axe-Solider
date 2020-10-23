using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownAxe : MonoBehaviour
{
    public float rotationSpeed;
    public float movementSpeed;
    public Transform thrownTarget;
    public Transform retrievedTarget;
    public Transform sprite;
    public Vector3 rotation;
    public bool isThrown;

    private BoxCollider _boxCollider;
    private SpriteRenderer _spriteRenderer;
    private bool _isActive;

    [SerializeField] private AudioSource _whoosh;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        sprite.Rotate(rotation * (rotationSpeed * Time.deltaTime));

        if (isThrown)
        {
            // Move our position a step closer to the target.
            float step = movementSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, thrownTarget.position, step);
            Activate(true);
        }
        else
        {
            float step = movementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, retrievedTarget.position, step);


            if (Vector3.Distance(transform.position, retrievedTarget.position) < 0.1f)
            {
                Activate(false);
            }
        }

        if (_isActive)
        {
            _whoosh.enabled = true;
        }
        else
        {
            _whoosh.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyAI>().TakeDamage(50f);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyAI>().TakeDamage(.5f);
        }
    }

    void Activate(bool enabled)
    {
        _isActive = enabled;
        _boxCollider.enabled = enabled;
        _spriteRenderer.enabled = enabled;
    }
}
