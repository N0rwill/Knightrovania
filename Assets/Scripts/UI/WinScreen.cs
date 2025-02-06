using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void StartMenuAgain()
    {
        SceneManager.LoadSceneAsync("startScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
