using System;
using UnityEngine;

namespace OtherScripts
{
    public class ParentFly : CusMonoBehaviour
    {
        [SerializeField] protected float speed;

        protected Rigidbody2D rb;

        protected override void LoadComponents()
        {
            rb = GetComponentInParent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            Fly();
        }

        private void Fly()
        {
            rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        }
    }
}
