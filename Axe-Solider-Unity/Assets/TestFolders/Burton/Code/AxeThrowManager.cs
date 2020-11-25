using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrowManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _axeThrowSprite;
    [SerializeField] private List<Sprite> _axeThrowSprites;
    [SerializeField] private float _secondsBetweenFrames;
    [SerializeField] private ThrownAxe _axe;
    [HideInInspector] public bool isThrowingAxe;

    void Awake()
    {
        _axe.controller = this;
    }

    public void ThrowAxe()
    {
        StartCoroutine(nameof(ThrowAxeCo));
    }

    private IEnumerator ThrowAxeCo()
    {
        ToggleThrowAnimation(true);
        AxeSoldier.Instance.withAxeSprite.enabled = false;
        AxeSoldier.Instance.noAxeSprite.enabled = false;
        isThrowingAxe = true;

        for (int i = 0; i < _axeThrowSprites.Count; i++)
        {
            if (i == _axeThrowSprites.Count - 1)
            {
                _axe.isThrown = true;
            }

            _axeThrowSprite.sprite = _axeThrowSprites[i];
            yield return new WaitForSeconds(_secondsBetweenFrames);
        }

        ToggleThrowAnimation(false);
        AxeSoldier.Instance.noAxeSprite.enabled = true;
        isThrowingAxe = false;
    }

    public void RetrieveAxe()
    {
        if (isThrowingAxe)
        {
            isThrowingAxe = false;
            AxeSoldier.Instance.withAxeSprite.enabled = false;
        }
        StopCoroutine(nameof(ThrowAxeCo));
        ToggleThrowAnimation(false);
        _axe.isThrown = false;

    }

    void ToggleThrowAnimation(bool isThrowing)
    {
        _axeThrowSprite.enabled = isThrowing;
    }
}
