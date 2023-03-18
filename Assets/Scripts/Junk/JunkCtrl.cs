using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : CusMonoBehaviour
{
    public JunkSpawner JunkSpawner { get; private set; }
    public SpawnPoints SpawnPoints { get; private set; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkSpawner();
        LoadSpawnPoints();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (JunkSpawner != null) return;
        JunkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }

    protected virtual void LoadSpawnPoints()
    {
        if (SpawnPoints != null) return;
        SpawnPoints = FindObjectOfType<SpawnPoints>();
        Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
    }
}
