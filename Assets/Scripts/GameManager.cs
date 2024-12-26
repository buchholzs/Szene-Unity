using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject _pauseMenu = null;

    private bool _isPaused = false;

    private InputAction cancelAction;

    public void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    public void Start()
    {
        cancelAction = InputSystem.actions.FindAction("Cancel");
        _pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        if (cancelAction.WasPerformedThisFrame())
        {
            if ( _isPaused)
            {
                Time.timeScale = 1;
                _pauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked; // Sperrt den Cursor in der Mitte des Bildschirms
            }
            else
            {
                Time.timeScale = 0;
                _pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None; // Löst den Cursor vom Bildschirm
            }
            _isPaused = !_isPaused;
        }
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
