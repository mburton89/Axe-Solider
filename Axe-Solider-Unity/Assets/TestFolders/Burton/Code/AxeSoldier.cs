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
    private KeyCode throwKey;

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
        thrownAxe.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
        StartCoroutine(FireRateBuffer());
    }

    private IEnumerator FireRateBuffer()
    {
        _canThrowAxe = false;
        yield return new WaitForSeconds(fireRate);
        _canThrowAxe = true;
    }
}
