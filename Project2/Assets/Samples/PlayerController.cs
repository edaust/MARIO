using UnityEngine;

namespace Project2.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed = 5f;
        [SerializeField] float jumpForce = 10f;

        float _horizontal;
        bool _isJumping;
        Animator _animator;
        Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");

            if (Input.GetButtonDown("Jump") && !_isJumping)
            {
                _isJumping = true;
                _animator.SetBool("isJump", true);
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            }
        }

        private void FixedUpdate()
        {
            _animator.SetFloat("MoveSpeed", Mathf.Abs(_horizontal));

            transform.Translate(Vector2.right * _horizontal * Time.deltaTime * speed);

            //if (_horizontal != 0)
            //{
            //    transform.localScale = new Vector2(Mathf.Sign(_horizontal), 1f);
            //}

            if (_rigidbody2D.velocity.y <= 0.1f && _isJumping)
            {
                _isJumping = false;
                _animator.SetBool("isJump", false);
            }
        }
    }
}