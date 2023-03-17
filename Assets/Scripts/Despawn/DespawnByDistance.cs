using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit;
    [SerializeField] protected float distance;
    [SerializeField] protected Transform mainCamera;

    protected override void LoadComponents()
    {
        LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if(mainCamera != null) return;
        mainCamera = FindObjectOfType<Camera>().transform;
    }

    protected override bool Despawnable()
    {
        distance = Vector3.Distance(mainCamera.position, transform.position);
        if (distance > disLimit) return true;
        return false;
    }
}
