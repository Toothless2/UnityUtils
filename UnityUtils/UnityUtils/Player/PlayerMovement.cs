using UnityEngine;
using ToothlessUtils.Input;

namespace ToothlessUtils.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerLook))]
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 3;
        
        public float jumpVelocity = 6;
        public float fallMultiplier = 2.5f;
        public float lowJumpMultiplier = 2f;
        public float? gravity;
        public float groundedDistance = 0.01f;

        private Rigidbody playerRigidbody;

        void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            Move();
        }

        public virtual void Move()
        {
            if (THInput.GetButton("Forward")) Forward();
            if (THInput.GetButton("Backwards")) Back();

            if (THInput.GetButton("Left")) Left();
            if (THInput.GetButton("Right")) Right();

            JumpBounce();
            if (THInput.GetButton("Jump") && IsGrounded()) Jump();
        }

        private void Forward()
        {
            transform.Translate(0, 0, speed * Time.fixedDeltaTime);
        }

        private void Back()
        {
            transform.Translate(0, 0, -speed * Time.fixedDeltaTime);
        }

        private void Left()
        {
            transform.Translate(-speed * Time.fixedDeltaTime, 0, 0);
        }

        private void Right()
        {
            transform.Translate(speed * Time.fixedDeltaTime, 0, 0);
        }

        private void Jump()
        {
            playerRigidbody.velocity += Vector3.up * Gravity() * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }

        private void JumpBounce()
        {
            if (playerRigidbody.velocity.y < 0) playerRigidbody.velocity += Vector3.up * Gravity() * (fallMultiplier - 1) * Time.fixedDeltaTime;
            else if (playerRigidbody.velocity.y > 0 && !THInput.GetButton("Jump")) playerRigidbody.velocity += Vector3.up * Gravity() * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }

        public bool IsGrounded()
        {
            Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit);
            return hit.distance < groundedDistance;
        }

        private float Gravity()
        {
            return gravity == null ? Physics.gravity.y : (float)gravity;
        }
    }
}
