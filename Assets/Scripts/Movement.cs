using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float VerticalSpeed;
    public float SwitchSpeed;
    [SerializeField] private new Rigidbody rigidbody;
    private PlayerInputActions _inputActions;
    private Vector3 _speed;

    private void Start()
    {
        _speed = new Vector3(0, VerticalSpeed,0);
        _inputActions = new PlayerInputActions();
        _inputActions.Enable();
        _inputActions.Movement.Down.started += delegate(InputAction.CallbackContext context)
        {
            _speed = new Vector3(0, (-1)*VerticalSpeed, 0);
            Debug.Log("debug");
        };
        _inputActions.Movement.Down.canceled += delegate(InputAction.CallbackContext context)
        {
            _speed = new Vector3(0, VerticalSpeed, 0);
        };
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(_speed, ForceMode.Impulse);
        if (Mathf.Abs(rigidbody.velocity.y) > VerticalSpeed)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, Mathf.Sign(rigidbody.velocity.y)*VerticalSpeed);
        }
    }
}
