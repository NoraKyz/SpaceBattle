using System.Collections;
using System.Collections.Generic;
using Spawner;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    protected override void DespawnObject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
