using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
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
