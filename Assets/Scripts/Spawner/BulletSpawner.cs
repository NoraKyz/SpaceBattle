using UnityEngine;

namespace Spawner
{
    public class BulletSpawner : Spawner
    {
        public static BulletSpawner Instance { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            if(BulletSpawner.Instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
            BulletSpawner.Instance = this;
        }
        
        protected override void LoadComponents()
        {
            GetObjectsInPrefabs();
        }
    }
}
