using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject _Menu = null;
    public int targetFrameRate = 60; // Ziel-Framerate

    [SerializeField]
    private bool _hasPauseMenu = true;

    private bool _isPaused = false;
    public bool IsPaused => _isPaused; // Öffentliche Eigenschaft, um den Pausenstatus abzurufen


    private InputAction cancelAction;

    public void Start()
    {
        Application.targetFrameRate = targetFrameRate; // Setzt die Ziel-Framerate
        cancelAction = InputSystem.actions.FindAction("Cancel");
        setPause(!_hasPauseMenu);
    }

    public void Update()
    {
        if (cancelAction.WasPerformedThisFrame() && _hasPauseMenu)
        {
            setPause(!_isPaused);
            _isPaused = !_isPaused;
        }
    }
    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnLevel1ButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnLevel2ButtonClick()
    {
        SceneManager.LoadScene(2);
    }

    private void setPause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
            _Menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None; // Löst den Cursor vom Bildschirm
        } else
        {
            Time.timeScale = 1;
            _Menu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked; // Sperrt den Cursor in der Mitte des Bildschirms
        }

    }
}
