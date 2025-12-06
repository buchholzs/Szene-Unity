using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.STP;

public class GameManager : MonoBehaviour
{
    public GameObject _Menu = null;
    public GameObject _ToggleMobile = null;
    public int targetFrameRate = 60; // Ziel-Framerate
    public static bool isMobile = Application.platform == RuntimePlatform.Android;

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
        if (_ToggleMobile != null)
        {
            Toggle _mobileToggle = _ToggleMobile.GetComponent<Toggle>();
            if (_mobileToggle != null)
            {
                // aktuellen globalen Wert setzen
                _mobileToggle.isOn = isMobile;
            }
        }
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
    public void OnMainMenuToggleClick()
    {
        if (_ToggleMobile != null)
        {
            Toggle _mobileToggle = _ToggleMobile.GetComponent<Toggle>();
            if (_mobileToggle != null)
            {
                // aktuellen globalen Wert setzen
                isMobile = _mobileToggle.isOn;
            }
        }
    }

    private void setPause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
            _Menu.SetActive(true);
            if (!isMobile)
            {
                Cursor.lockState = CursorLockMode.None; // Löst den Cursor vom Bildschirm
            }
        }
        else
        {
            Time.timeScale = 1;
            _Menu.SetActive(false);
            if (!isMobile)
            {
                Cursor.lockState = CursorLockMode.Locked; // Sperrt den Cursor in der Mitte des Bildschirms
            }
        }
    }
}
