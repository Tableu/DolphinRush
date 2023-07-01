using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private PlayerData data;
    [SerializeField] private GameObject model;
    private PlayerInputActions _inputActions;
    private Vector3 _speed;
    private void Start()
    {
        _speed = new Vector3(0, data.Speed,0);
        _inputActions = new PlayerInputActions();
        _inputActions.Enable();
        _inputActions.Movement.Down.started += delegate(InputAction.CallbackContext context)
        {
            _speed = new Vector3(0, (-1)*data.Speed, 0);
        };
        _inputActions.Movement.Down.canceled += delegate(InputAction.CallbackContext context)
        {
            _speed = new Vector3(0, data.Speed, 0);
        };
    }

    private void Update()
    {
        model.transform.rotation = Quaternion.Euler(data.Angle*-1*(rigidbody.velocity.y/data.MaxSpeed),model.transform.rotation.eulerAngles.y,model.transform.rotation.eulerAngles.z);
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(_speed, ForceMode.Force);
        if (Mathf.Abs(rigidbody.velocity.y) > data.MaxSpeed)
        {
            rigidbody.velocity = new Vector3(0, Mathf.Sign(rigidbody.velocity.y)*data.MaxSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (rigidbody.velocity.y > 0)
        {
            _speed = new Vector3(0, (-1) * data.Speed, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (rigidbody.velocity.y < 0)
        {
            _speed = new Vector3(0, data.Speed, 0);
        }
    }
}
