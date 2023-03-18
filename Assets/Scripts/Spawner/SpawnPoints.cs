using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : CusMonoBehaviour
{
    [SerializeField] protected List<Transform> listPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPoints();
    }

    protected virtual void LoadPoints()
    {
        if (listPoints.Count > 0) return;
        foreach (Transform point in transform)
        {
            listPoints.Add(point);
        }
        Debug.Log(transform.name + ": LoadComponents", gameObject);
    }

    public virtual Transform GetRandom()
    {
        int rand = Random.Range(0, listPoints.Count);
        return listPoints[rand];
    }
}
