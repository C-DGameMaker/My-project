using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 5;
    [SerializeField] float _jumpForce = 5;
    [SerializeField] Vector2 _moveInput;
    [SerializeField] Animator _playerAnimator;
    private int isWalking = Animator.StringToHash("isWalking");
    private Rigidbody _playerRigidBody;

    private void Awake()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandlePlayerAnimation();
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerAnimation()
    {
        if (_moveInput != Vector2.zero)
        {
            _playerAnimator.SetBool(isWalking, true);
        }
        else
        {
            _playerAnimator.SetBool(isWalking, false);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump()
    {
        if (Mathf.Abs(_playerRigidBody.linearVelocity.y) < 0.01f)
            _playerRigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private void HandlePlayerMovement()
    {
        Vector3 move = new Vector3(_moveInput.x, 0, _moveInput.y) * _movementSpeed * Time.deltaTime;
        _playerRigidBody.MovePosition(_playerRigidBody.position + move);
    }
}