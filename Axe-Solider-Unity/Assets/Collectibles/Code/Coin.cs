using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : Collectible
{
    public Vector3 rotationDirection;
    public float rotationSpeed;
    private float _initialYPosition;
    public float bobDistance;
    public float bobDuration;
    public Ease ease;

    private bool _canCollect;

    private void Start()
    {
        _canCollect = true;
        StartCoroutine(BobCo());
        _initialYPosition = transform.position.y;
    }
    public override void GetCollected()
    {
        if (_canCollect)
        {
            //Handle updating coin UI here.
            _canCollect = true;
            print("Got Coin");
            SoundManager.Instance.PlayCoinSound();
            CoinManager.Instance.IncrementCollectedCoinCount();
        }
    }

    private void Update()
    {
        transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime);
    }

    private IEnumerator BobCo()
    {
        transform.DOMoveY(_initialYPosition + bobDistance, bobDuration).SetEase(ease);
        yield return new WaitForSeconds(bobDuration);
        transform.DOMoveY(_initialYPosition - bobDistance, bobDuration).SetEase(ease);
        yield return new WaitForSeconds(bobDuration);
        StartCoroutine(BobCo());
    }
}
