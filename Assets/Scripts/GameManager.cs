using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject _pauseMenu = null;
    public GameObject _startMenu = null;
    public int targetFrameRate = 60; // Ziel-Framerate

    private bool _isPaused = true;
    public bool IsPaused => _isPaused; // Öffentliche Eigenschaft, um den Pausenstatus abzurufen


    private InputAction cancelAction;

    public void Start()
    {
        Application.targetFrameRate = targetFrameRate; // Setzt die Ziel-Framerate
        cancelAction = InputSystem.actions.FindAction("Cancel");
        _pauseMenu.SetActive(false);
        _startMenu.SetActive(true);
        Time.timeScale = 0;
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
    public void OnStartButtonClick()
    {
        _isPaused = false;
        _startMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnLevel0ButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnLevel1ButtonClick()
    {
        SceneManager.LoadScene(1);
    }
}
