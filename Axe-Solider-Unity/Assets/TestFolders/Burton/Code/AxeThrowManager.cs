using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrowManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _initialSprite;
    [SerializeField] private SpriteRenderer _axeThrowSprite;
    [SerializeField] private List<Sprite> _axeThrowSprites;
    [SerializeField] private float _secondsBetweenFrames;
    [SerializeField] private ThrownAxe _axe;

    public void ThrowAxe()
    {
        StartCoroutine(nameof(ThrowAxeCo));
    }

    private IEnumerator ThrowAxeCo()
    {
        ToggleThrowAnimation(true);

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

    }

    public void RetrieveAxe()
    {
        StopCoroutine(nameof(ThrowAxeCo));
        ToggleThrowAnimation(false);
        _axe.isThrown = false;
    }

    void ToggleThrowAnimation(bool isThrowing)
    {
        _initialSprite.enabled = !isThrowing;
        _axeThrowSprite.enabled = isThrowing;
    }
}
