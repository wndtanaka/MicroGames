using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WendiTanaka
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        public float movementSpeed = 15f;
        public float jumpSpeed = 25f;
        public Transform groundCheck;
        public LayerMask checkGround;

        private bool canJump = false;
        private bool isGrounded = false;
        float groundRadius = 0.2f;
        private Rigidbody2D rb;

        // Use this for initialization
        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        void Update()
        {
            Move();
        }
        void FixedUpdate()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius,checkGround);
        }
        void Move()
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
                //transform.eulerAngles = new Vector2(0, 180);

            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.velocity = new Vector2(0, jumpSpeed);
            }
        }
        void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.tag == "Platform")
            {
                transform.parent = other.transform;
            }
            if (other.gameObject.tag == "Finish")
            {
                StirlingMulvey.GlobalGameManager.gameWon = true;
            }
        }

        void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.tag == "Platform")
            {
                transform.parent = null;
            }
        }
    }
}