using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] GameObject GameWinScreen;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
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
