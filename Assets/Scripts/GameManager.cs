using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _pauseMenu = null;

    private bool _isPaused = false;

    public void Start()
    {
        _pauseMenu.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if ( _isPaused)
            {
                _isPaused = false;
                Time.timeScale = 1;
                _pauseMenu.SetActive(false);
            }
            else
            {
                _isPaused = true;
                Time.timeScale = 0;
                _pauseMenu.SetActive(true);
            }
        }
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
