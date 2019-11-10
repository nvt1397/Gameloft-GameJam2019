using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public void Resume()
    {
        if(Input.touchCount > 0)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }    
        
    }


    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        if (Input.touchCount > 0)
        {
            Application.Quit();
        }
        
    }
}
