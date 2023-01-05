using System;
using System.Threading;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Range(1f, 35.0f)] [SerializeField] float _moveSpeed = 10f;
    [Range(1f, 10.0f)] [SerializeField] float _jumpHeight = 2.0f;
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


    void MoveCharacter()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float forward = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = new Vector3(horizontal, 0, forward);

        _characterController.Move(movementDirection.normalized * Time.deltaTime * _moveSpeed);
    }
    
    void ResetGravityIfGrounded()
    {
        if (_isGrounded)
        {
            _jumpVelocity.y = -.2f;
        }
    }
    
    void CheckForJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            CalculateJumpVelocity();
        }
    }
    
    void ApplyGravity()
    {
        _jumpVelocity.y += _gravity * Time.deltaTime * _fallSpeed;
    }
    
    void ApplyJumpVelocity()
    {
        _characterController.Move(_jumpVelocity * Time.deltaTime);
    }
    
    void CalculateJumpVelocity()
    {
        _jumpVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);
    }
    
}



