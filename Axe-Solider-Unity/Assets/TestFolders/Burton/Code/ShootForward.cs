using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootForward : MonoBehaviour
{
    public float projectileSpeed;
    public float fireRate;

    [SerializeField]
    private Transform _spawnPoint1;
    [SerializeField]
    private Transform _spawnPoint2;
    [SerializeField]
    private GameObject _projectilePrefab;

    void Start()
    {
        StartCoroutine(FireCo());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //DecreaseHealth(1f);
        }
    }

    void Fire()
    {
        GameObject projectile1 = Instantiate(_projectilePrefab, _spawnPoint1.position, _spawnPoint1.rotation);
        GameObject projectile2 = Instantiate(_projectilePrefab, _spawnPoint2.position, _spawnPoint2.rotation);
        projectile1.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
        projectile2.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
    }

    private IEnumerator FireCo()
    {
        Fire();
        yield return new WaitForSeconds(fireRate);
        StartCoroutine(FireCo());
    }
}
