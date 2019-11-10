using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        if(Input.touchCount>0)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
