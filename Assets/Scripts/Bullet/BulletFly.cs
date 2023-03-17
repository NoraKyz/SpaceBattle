using UnityEngine;

namespace Bullet
{
    public class BulletFly : MonoBehaviour
    {
        [SerializeField] protected float speed;

        protected Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponentInParent<Rigidbody2D>();
        }

        private void Start()
        {
            rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        }
    }
}
