using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSoldier : MonoBehaviour
{
    public float projectileSpeed;
    public float fireRate;

    [SerializeField]
    private Transform _thrownAxeSpawnPoint;
    [SerializeField]
    private ThrownAxe _thrownAxePrefab;
    [SerializeField]
    private Transform _pivot;
    [SerializeField]
    private KeyCode throwKey;
    [SerializeField]
    private Animator _animator;

    private bool _canThrowAxe;

    private void Start()
    {
        _canThrowAxe = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(throwKey) && _canThrowAxe)
        {
            ThrowAxe();
        }
    }

    void ThrowAxe()
    {
        ThrownAxe thrownAxe = Instantiate(_thrownAxePrefab, _thrownAxeSpawnPoint.position, _thrownAxeSpawnPoint.rotation);
        thrownAxe.GetComponent<Rigidbody>().AddForce(-_pivot.transform.forward * projectileSpeed);
    }

    private IEnumerator ThrowAxeCo()
    {
        _canThrowAxe = false;
        _animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(.5f);
        ThrowAxe();
        yield return new WaitForSeconds(5f);
        _canThrowAxe = true;
        _animator.SetBool("isAttacking", false);
    }
}
