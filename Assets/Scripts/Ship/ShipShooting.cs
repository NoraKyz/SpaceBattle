using System;
using System.Collections;
using System.Collections.Generic;
using Bullet;
using Spawner;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting;
    [SerializeField] protected float shootDelay;
    protected float shootTimer;

    private void Update()
    {
        IsShooting();
    }

    private void FixedUpdate()
    {
        Shooting();
    }

    protected virtual void Shooting()
    {
        if (!isShooting) return;

        shootTimer += Time.fixedDeltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0;

        Transform cacheTranform = transform;
        Quaternion rotation = cacheTranform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.FireballBlueBig, cacheTranform.position, rotation);
        if (newBullet == null) return;
        
        newBullet.gameObject.SetActive(true);
    }

    protected virtual void IsShooting()
    {
        isShooting = InputManager.Instance.OnFiring == 1;
    }
}
