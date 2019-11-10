using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    //Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        if (GameIsPaused)
    //        {
    //            Resume();
    //        }
    //        else
    //        {
    //            Pause();
    //        }
    //    }

    //}

    public void Resume()
    {
        if(Input.touchCount > 0)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
        
        
    }
    //void Pause()
    //{
    //    pauseMenuUI.SetActive(true);
    //    Time.timeScale = 0f;
    //    GameIsPaused = true;
    //}


    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("Quitting...");
            Application.Quit();
        }
        
    }
}
