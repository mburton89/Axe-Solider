using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSoldier : MonoBehaviour
{
    [SerializeField] private Transform _pivot;
    [SerializeField] private Animator _animator;
    [SerializeField] private AxeThrowManager _axeThrowManager;
    [HideInInspector] public bool canThrowAxe;
    public HealthBar healthBar;
    public float health;
    private float _initialHealth;

    private void Start()
    {
        canThrowAxe = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Screen.lockCursor = true;
        _initialHealth = health;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canThrowAxe)
        {
            _axeThrowManager.ThrowAxe();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _axeThrowManager.RetrieveAxe();
        }
    }

    public void TakeDamage(float damageToTake)
    {
        health = health - damageToTake;
        healthBar.SetHealth(_initialHealth - (_initialHealth - health));
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
