using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverOverButton: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite buttonSelectedSprite;
    public Sprite buttonNonSelectedSprite;
    public Image button;


    public void OnPointerEnter(PointerEventData eventData)
    {
        button.sprite = buttonSelectedSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.sprite = buttonNonSelectedSprite;
    }
}