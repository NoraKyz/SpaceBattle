using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spawner
{
    //TODO: creat BulletSpawn, Despawn
    public abstract class Spawner : CusMonoBehaviour
    {
        [SerializeField] protected Transform holder;
        [SerializeField] protected List<Transform> listPrefabs;
        [SerializeField] protected List<Transform> poolObjects;

        protected override void LoadComponents()
        {
            LoadPrefabs();
            LoadHolder();
        }

        protected virtual void LoadHolder()
        {
            if (holder != null) return;
            holder = transform.Find("Holder");
            Debug.Log(transform.name + ": LoadHolder", gameObject);
        }

        protected virtual void LoadPrefabs()
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

        public virtual Transform Spawn(string prefabName,Vector3 spawnPos, Quaternion rotation)
        {
            Transform prefab = GetPrefabByName(prefabName);
            if (prefab == null)
            {
                Debug.LogWarning("Prefab not found" + prefabName);
                return null;
            }

            Transform newPrefab = GetObjectFromPool(prefab);
            newPrefab.SetPositionAndRotation(spawnPos, rotation);

            newPrefab.parent = holder;
            return newPrefab;
        }

        public virtual void Despawn(Transform obj)
        {
            poolObjects.Add(obj);
            obj.gameObject.SetActive(false);
        }

        protected virtual Transform GetObjectFromPool(Transform prefab)
        {
            foreach (Transform obj in poolObjects)
            {
                if (obj.name == prefab.name)
                {
                    poolObjects.Remove(obj);
                    return obj;
                }
            }

            Transform newObject = Instantiate(prefab);
            newObject.name = prefab.name;
            return newObject;
        }

        public virtual Transform GetPrefabByName(string prefabName)
        {
            foreach (Transform prefab in listPrefabs)
            {
                if (prefab.name == prefabName) return prefab;
            }

            return null;
        }
    }
}