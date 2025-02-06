using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] GameObject GameWinScreen;
    public void WinScreenActive(Collider2D Player)
    {
        if (Player.tag == "Player")
        {
            Time.timeScale = 0;
            GameWinScreen.SetActive(true);
        }
    }
    public void StartMenuAgain()
    {
        SceneManager.LoadSceneAsync("startScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
