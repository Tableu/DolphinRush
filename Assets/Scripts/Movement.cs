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
    private bool _hitBarrier;
    private void Start()
    {
        _speed = new Vector3(0, data.Speed,0);
        _inputActions = new PlayerInputActions();
        _inputActions.Enable();
        _inputActions.Movement.Down.started += delegate(InputAction.CallbackContext context)
        {
            //rigidbody.velocity = new Vector3(0, rigidbody.velocity.y * (-1));
            _speed = new Vector3(0, (-1)*data.Speed, 0);
        };
        
        _inputActions.Movement.Down.canceled += delegate(InputAction.CallbackContext context)
        {
            //rigidbody.velocity = new Vector3(0, rigidbody.velocity.y * (-1));
            _speed = new Vector3(0, data.Speed, 0);
        };
    }

    private void Update()
    {
        var eulerAngles = model.transform.rotation.eulerAngles;
        if (!_hitBarrier)
        {
            model.transform.rotation = Quaternion.Euler(data.Angle * -1 * (rigidbody.velocity.y / data.MaxSpeed),
                eulerAngles.y, eulerAngles.z);
        }else
        {
            model.transform.rotation = Quaternion.Slerp(model.transform.rotation, Quaternion.Euler(0f, eulerAngles.y, eulerAngles.z), data.RotateSpeed * Time.deltaTime);
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

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            _hitBarrier = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            _hitBarrier = false;
        }
    }
}