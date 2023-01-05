using System;
using System.Threading;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] float _jumpHeight = 2.0f;
    [Range(0.1f, 6.0f)] [SerializeField] float _fallSpeed = 2f;

    [SerializeField] bool _isGrounded;
    CharacterController _characterController;
    float _gravity = -9.81f;
    Vector3 _jumpVelocity;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _isGrounded = _characterController.isGrounded;
        MoveCharacter();
        ResetGravityIfGrounded();
        CheckForJumpInput();
        ApplyGravity();
        ApplyJumpVelocity();
    }

    void ApplyJumpVelocity()
    {
        _characterController.Move(_jumpVelocity * Time.deltaTime);
    }

    void ApplyGravity()
    {
        _jumpVelocity.y += _gravity * Time.deltaTime * _fallSpeed;
    }

    void CheckForJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            CalculateJumpVelocity();
        }
    }

    void CalculateJumpVelocity()
    {
        _jumpVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);
    }

    void ResetGravityIfGrounded()
    {
        if (_isGrounded)
        {
            _jumpVelocity.y = -.2f;
        }
    }

    void MoveCharacter()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float forward = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = new Vector3(horizontal, 0, forward);

        _characterController.Move(movementDirection * Time.deltaTime * _moveSpeed);
    }
}



