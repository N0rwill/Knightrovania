using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Room_1");
    }

    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadSceneAsync("Room_1");
        }
    }
}
