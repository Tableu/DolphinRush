using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameStart : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private ObstacleSpawner obstacleSpawner;
    [SerializeField] private AudioSource menuSource;
    [SerializeField] private AudioClip startAudio;
    [SerializeField] private AudioSource gameSource;
    [SerializeField] private AudioSource soundEffectSource;
    [SerializeField] private float menuMusicDelay;
    [SerializeField] private TextMeshProUGUI spaceText;
    [SerializeField] private MoveTitle title;

    private PlayerInputActions _inputActions;
    // Start is called before the first frame update
    void Start()
    {
        _inputActions = new PlayerInputActions();
        _inputActions.Enable();
        _inputActions.Movement.Space.started += delegate(InputAction.CallbackContext context)
        {
            StartCoroutine(OnStart());
        };
    }

    private IEnumerator OnStart()
    {
        menuSource.Stop();
        soundEffectSource.clip = startAudio;
        soundEffectSource.Play();
        _inputActions.Disable();
        _inputActions.Dispose();
        Destroy(spaceText.gameObject);
        title.enabled = true;
        yield return new WaitForSeconds(menuMusicDelay);
        movement.enabled = true;
        gameSource.Play();
        StartCoroutine(SpeedManager.Instance.StartSpeed());
        Destroy(title.gameObject);
        yield return new WaitForSeconds(5);
        obstacleSpawner.enabled = true;
    }
}
