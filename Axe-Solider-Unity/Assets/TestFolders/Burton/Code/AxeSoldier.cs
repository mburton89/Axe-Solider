using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MenteBacata.ScivoloCharacterControllerDemo;

public class AxeSoldier : MonoBehaviour
{
    public OrbitingCamera OrbitingCamera;
    public static AxeSoldier Instance;
    [SerializeField] private Transform _pivot;
    [SerializeField] private Animator _animator;
    [SerializeField] private AxeThrowManager _axeThrowManager;
    [HideInInspector] public bool canThrowAxe;
    private HealthBar _healthBar;
    public float health;
    private float _initialHealth;

    // Make empty GameObject in scene then drag it to this name. This will be where Axe Soldier respawns.
    public Transform respawnPoint;

    private void Start()
    {
        _healthBar = FindObjectOfType<HealthBar>();
        canThrowAxe = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Screen.lockCursor = true;
        _initialHealth = health;
        Instance = this;
        Application.targetFrameRate = 60;
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

        if(health <= 0)
        {
            HandleDeath();
        }
    }

    public void TakeDamage(float damageToTake)
    {
        health = health - damageToTake;
        _healthBar.SetHealth(_initialHealth - (_initialHealth - health));
    }

    void HandleDeath()
    {
        DeathScreen.Instance.Activate();
        //_pivot.gameObject.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        OrbitingCamera.enabled = false;
        
    }

    public void RespawnPlayer()
    {
        transform.position = respawnPoint.position;
        health = _initialHealth;
        _healthBar.SetHealth(health);
        //_pivot.gameObject.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        OrbitingCamera.enabled = true;
    }
}
