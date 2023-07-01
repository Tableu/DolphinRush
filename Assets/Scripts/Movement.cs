using System;
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
        float angle = model.transform.eulerAngles.x;
        if (_speed.y != 0)
        {
            if (_speed.y > 0)
            {
                if (angle >= 360 - data.Angle ||
                    angle <= data.Angle + 3)
                {
                    model.transform.Rotate(Vector3.left, data.RotationSpeed * Time.deltaTime);
                }
            }
            else
            {
                if (angle <= data.Angle ||
                    angle >= 360 - data.Angle - 3)
                {
                    model.transform.Rotate(Vector3.right, data.RotationSpeed * Time.deltaTime);
                }
            }
        }
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
        rigidbody.velocity = Vector3.zero;
        _speed = Vector3.zero;
    }

    private void OnCollisionEnter(Collision other)
    {
        rigidbody.velocity = Vector3.zero;
        _speed = Vector3.zero;
    }
}
