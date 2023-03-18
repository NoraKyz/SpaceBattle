using UnityEngine;

namespace Junk
{
    public class JunkRandom : CusMonoBehaviour
    {
        [SerializeField] protected JunkCtrl junkCtrl;
        protected override void LoadComponents()
        {
            base.LoadComponents();
            LoadJunkCtrl();
        }

        protected virtual void LoadJunkCtrl()
        {
            if (junkCtrl != null) return;
            junkCtrl = GetComponent<JunkCtrl>();
            Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
        }

        protected override void Start()
        {
            JunkSpawning();
        }

        protected virtual void JunkSpawning()
        {
            Transform randomPoint = junkCtrl.SpawnPoints.GetRandom();
            Vector3 spawnPos = randomPoint.position;
            Quaternion rotation = transform.rotation;
            
            Transform obj = junkCtrl.JunkSpawner.Spawn(JunkSpawner.SmallAsteroid1, spawnPos, rotation);
            obj.gameObject.SetActive(true);
            
            Invoke(nameof(this.JunkSpawning), 1f);
        }
    }
}
