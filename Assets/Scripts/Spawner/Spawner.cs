using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spawner
{
    //TODO: creat BulletSpawn, Despawn
    public abstract class Spawner : CusMonoBehaviour
    {
        [SerializeField] protected List<Transform> listPrefabs;

        protected virtual void GetObjectsInPrefabs()
        {
            if (listPrefabs.Count > 0) return;
            
            Transform prefabs = transform.Find("Prefabs");
            foreach (Transform prefab in prefabs)
            {
                listPrefabs.Add(prefab);
            }

            HidePrefabs();
        }

        protected virtual void HidePrefabs()
        {
            foreach (Transform prefab in listPrefabs)
            {
                prefab.gameObject.SetActive(false);
            }
        }

        public virtual Transform Spawn(Vector3 spawnPos, Quaternion rotation)
        {
            Transform prefab = listPrefabs[0];
            Transform newPrefab = Instantiate(prefab, spawnPos, rotation);
            return newPrefab;
        }
    }
}