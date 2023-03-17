using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public float OnFiring { get; private set; }
    public Vector3 MouseWorldPos { get; private set; }

    private void Awake()
    {
        if(InputManager.Instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.Instance = this;
    }

    private void Update()
    {
        GetMouseDown();
    }

    void FixedUpdate()
    {
        GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        MouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetMouseDown()
    {
        OnFiring = Input.GetAxis("Fire1");
    }
}
