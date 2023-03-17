using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : CusMonoBehaviour
{
    protected virtual void FixedUpdate()
    {
        Despawning();
    }
    
    protected void Despawning()
    {
        if (!Despawnable()) return;
        DespawnObject();
    }
    
    protected virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }

    protected abstract bool Despawnable();
}
