using System;
using System.Threading;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float _moveSpeed = 10f;
    Rigidbody _rb;
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.Log(_rb.velocity);
        
        if (Input.GetKey(KeyCode.W))
        {
            //use rigidbody to move forward
            //_rb.AddForce(Vector3.forward * _moveSpeed);
            _rb.velocity = Vector3.forward * (_moveSpeed * Time.deltaTime); 
            Debug.Log("Moving forward");
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rb.velocity = Vector3.back * (_moveSpeed * Time.deltaTime); 
            Debug.Log("Moving backwards");
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rb.velocity = Vector3.left * (_moveSpeed * Time.deltaTime); 
            Debug.Log("Moving left");
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb.velocity = Vector3.right * (_moveSpeed * Time.deltaTime); 
            Debug.Log("Moving right");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jumped");
        }
    }


}



