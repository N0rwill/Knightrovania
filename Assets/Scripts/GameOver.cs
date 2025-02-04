using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
  public void restartbutton()
    {
        SceneManager.LoadScene("testScene");
        Time.timeScale = 1;
    }

    public void quitbutton()
    {
        Application.Quit();
    }
}
