using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerPivot : MonoBehaviour
{
    public bool shouldTurnSideways;
    public float rotateSpeed;
    private Vector3 _sideways;
    public KeyCode turnKey;
    private bool _isSideways;

    private void Start()
    {
        _isSideways = false;
        _sideways = new Vector3(0f, 90f, 0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(turnKey))
        {
            if (_isSideways)
            {
                TurnForward();
            }
            else
            {
                TurnSideways();
            }
        }
    }

    void TurnForward()
    {
        transform.DOLocalRotate(Vector3.zero, 0.5f, RotateMode.Fast);
        _isSideways = false;
    }

    void TurnSideways()
    {
        transform.DOLocalRotate(_sideways, 0.5f, RotateMode.Fast);
        _isSideways = true;
    }
}
