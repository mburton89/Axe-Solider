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
        StartCoroutine(ThrowAxeCo());
    }

    private IEnumerator ThrowAxeCo()
    {
        _initialSprite.enabled = false;
        _axeThrowSprite.enabled = true;

        for (int i = 0; i < _axeThrowSprites.Count; i++)
        {
            if (i == _axeThrowSprites.Count - 1)
            {
                _axe.isThrown = true;
            }

            _axeThrowSprite.sprite = _axeThrowSprites[i];
            yield return new WaitForSeconds(_secondsBetweenFrames);
        }

        _initialSprite.enabled = true;
        _axeThrowSprite.enabled = false;
    }

    public void RetrieveAxe()
    {
        _axe.isThrown = false;
    }
}
