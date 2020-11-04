using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpotLightMover : MonoBehaviour
{
    public Vector3 startRotation;
    public Vector3 endRotation;
    public float duration;
    public Ease ease;

    private void Start()
    {
        StartCoroutine(SwivelCo());
    }

    private IEnumerator SwivelCo()
    {
        transform.DORotate(endRotation, duration, RotateMode.Fast);
        yield return new WaitForSeconds(duration);
        transform.DORotate(startRotation, duration, RotateMode.Fast);
        yield return new WaitForSeconds(duration);
        StartCoroutine(SwivelCo());
    }
}
