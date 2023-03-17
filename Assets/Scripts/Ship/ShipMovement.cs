using UnityEngine;

namespace Ship
{
    public class ShipMovement : MonoBehaviour
    {
        [SerializeField] protected float moveSpeed = 0.1f;
        protected Vector3 targetPosition;

        private Transform _transformParent;

        private void Awake()
        {
            _transformParent = transform.parent;
        }

        void FixedUpdate()
        {
            GetTargetPosition();
            LookAtTarget();
            Moving();
        }

        protected void LookAtTarget()
        {
            Vector3 diff = targetPosition - _transformParent.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            _transformParent.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }

        protected virtual void GetTargetPosition()
        {
            targetPosition = InputManager.Instance.MouseWorldPos;
            targetPosition.z = 0;
        }

        protected virtual void Moving()
        {
            Vector3 newPos = Vector3.Lerp(_transformParent.position, targetPosition, moveSpeed);
            _transformParent.position = newPos;
        }
    }
}
