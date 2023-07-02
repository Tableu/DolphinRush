using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private PlayerData data;
    [SerializeField] private GameObject model;
    private PlayerInputActions _inputActions;
    private Vector3 _speed;
    private bool _jumping;
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
            _speed = new Vector3(0, data.Speed*Mathf.Max((float)context.duration/data.ChargeTime,1f), 0);
            _jumping = true;
        };
    }

    private void Update()
    {
        model.transform.rotation = Quaternion.Euler(data.Angle*-1*(rigidbody.velocity.y/data.MaxSpeed),model.transform.rotation.eulerAngles.y,model.transform.rotation.eulerAngles.z);
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(_speed, ForceMode.Force);
        var maxSpeed = _inputActions.Movement.Down.IsPressed() || _jumping ? data.MaxSpeed : data.IdleMaxSpeed;
        var correctionSpeed = _inputActions.Movement.Down.IsPressed() || _jumping ? data.CorrectionSpeed : data.IdleCorrectionSpeed;
        if (Mathf.Abs(rigidbody.velocity.y) > maxSpeed)
        {
            rigidbody.velocity = new Vector3(0, Mathf.Sign(rigidbody.velocity.y)*maxSpeed);
        }

        if (_jumping)
        {
            if (rigidbody.velocity.y < 0)
            {
                _jumping = false;
            }
        }

        if (transform.position.y > data.MaxHeight)
        {
            if (rigidbody.velocity.y > 0)
            {
                _speed = new Vector3(0, (-1) * correctionSpeed, 0);
            }
        }else{ 
            if ((rigidbody.velocity.y < 0 && !_inputActions.Movement.Down.IsPressed() || transform.position.y < data.MinHeight))
            {
                _speed = new Vector3(0, correctionSpeed, 0);
            }
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}