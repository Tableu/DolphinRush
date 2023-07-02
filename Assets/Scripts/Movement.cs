using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private PlayerData data;
    [SerializeField] private GameObject model;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathAudio;
    [SerializeField] private GameObject deathPrefab;
    [SerializeField] private GameObject spacePrefab;
    [SerializeField] private Death death;
    [SerializeField] private ObstacleSpawner spawner;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private AudioClip collectableAudio;
    private PlayerInputActions _inputActions;
    private Vector3 _speed;
    private bool _hitBarrier;
    private int _scoreTick = 4;
    private int _tick = 4;
    private void Start()
    {
        _speed = new Vector3(0, data.Speed,0);
        _inputActions = new PlayerInputActions();
        _inputActions.Enable();
        _inputActions.Movement.Space.started += delegate(InputAction.CallbackContext context)
        {
            //rigidbody.velocity = new Vector3(0, rigidbody.velocity.y * (-1));
            _speed = new Vector3(0, (-1)*data.Speed, 0);
        };
        
        _inputActions.Movement.Space.canceled += delegate(InputAction.CallbackContext context)
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
            rigidbody.velocity = new Vector3(0, Mathf.Sign(rigidbody.velocity.y) * data.MaxSpeed);
        }

        if (_tick*SpeedManager.Instance.SpeedMultiplier > _scoreTick){
            score.text = (Convert.ToInt32(score.text) + 1).ToString();
            _tick = 0;
        }
        else
        {
            _tick++;
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
            audioSource.clip = deathAudio;
            audioSource.Play();
            deathPrefab.SetActive(true);
            spacePrefab.SetActive(true);
            death.enabled = true;
            spawner.enabled = false;
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectible"))
        {
            score.text = (Convert.ToInt32(score.text) + 100).ToString();
            audioSource.clip = collectableAudio;
            audioSource.Play();
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