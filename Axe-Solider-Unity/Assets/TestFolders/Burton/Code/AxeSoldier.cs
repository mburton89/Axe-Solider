using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSoldier : MonoBehaviour
{
    [SerializeField] private Transform _pivot;
    [SerializeField] private Animator _animator;
    [SerializeField] private AxeThrowManager _axeThrowManager;
    [HideInInspector] public bool canThrowAxe;

    private void Start()
    {
        canThrowAxe = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canThrowAxe)
        {
            _axeThrowManager.ThrowAxe();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _axeThrowManager.RetrieveAxe();
        }
    }
}
