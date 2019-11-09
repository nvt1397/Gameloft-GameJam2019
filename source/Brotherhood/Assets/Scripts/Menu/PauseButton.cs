using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;
    bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    public void GamePause()
    {
        if (Input.touchCount > 0)
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0;
            }

            if (!isPaused)
            {
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
        
            
    }
    void OnApplicationPause()
    {
        isPaused = true;
        Time.timeScale = 0;
    }
}
