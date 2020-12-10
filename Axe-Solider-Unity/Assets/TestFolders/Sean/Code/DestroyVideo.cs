using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVideo : MonoBehaviour
{
    public float setTime;
    public GameObject HUD;

    private void Start()
    {
        HUD.SetActive(false);
        StartCoroutine(LateCall());
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(setTime);
        Destroy(gameObject);
        HUD.SetActive(true);
    }
}
