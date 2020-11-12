using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MenteBacata.ScivoloCharacterControllerDemo;
using MenteBacata.ScivoloCharacterController;
using DG.Tweening;

public class AxeSoldier : MonoBehaviour
{
    public OrbitingCamera OrbitingCamera;
    public static AxeSoldier Instance;
    [SerializeField] private Animator _animator;
    [SerializeField] private AxeThrowManager _axeThrowManager;
    [HideInInspector] public bool canThrowAxe;
    private HealthBar _healthBar;
    public float health;
    private float _initialHealth;
    private CapsuleCollider _capsule;
    private CharacterCapsule _characterCapsule;

    [SerializeField] private AudioSource _axeSoldierHurt;
    private bool _canFlatten;
    public Transform respawnPoint;

    private void Start()
    {
        _healthBar = FindObjectOfType<HealthBar>();
        _capsule = GetComponent<CapsuleCollider>();
        _characterCapsule = GetComponent<CharacterCapsule>();
        canThrowAxe = true;
        _canFlatten = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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

        if (Input.GetKeyDown(KeyCode.LeftShift) && _canFlatten)
        {
            Flatten();
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
        _axeSoldierHurt.Play();
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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        OrbitingCamera.enabled = true;
    }

    void Flatten()
    {
        StartCoroutine(FlattenCo());
    }

    private IEnumerator FlattenCo()
    {
        _canFlatten = false;
        Vector3 rotateAmount = new Vector3(0, 90, 0);
        float duration = .5f;
        float initialRadius = _capsule.radius;
        _capsule.radius = .03f;
        _characterCapsule.Radius = .03f;
        _animator.transform.DOLocalRotate(rotateAmount, duration, RotateMode.Fast);
        yield return new WaitForSeconds(duration * 2);
        _animator.transform.DOLocalRotate(Vector3.zero, duration, RotateMode.Fast);
        yield return new WaitForSeconds(duration);
        _capsule.radius = initialRadius;
        _characterCapsule.Radius = initialRadius;
        _canFlatten = true;
    }
}
