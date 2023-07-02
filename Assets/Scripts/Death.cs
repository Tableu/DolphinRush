using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerInputActions inputActions = new PlayerInputActions();
        inputActions.Enable();
        inputActions.Movement.Space.started += delegate(InputAction.CallbackContext context)
        {
            inputActions.Disable();
            inputActions.Dispose();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        };
    }
}
