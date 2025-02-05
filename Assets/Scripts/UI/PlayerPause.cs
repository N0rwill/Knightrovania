using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPause : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject VolumePanel;
    [SerializeField] GameObject ControlPanel;
    [SerializeField] GameObject BackButton;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Controls()
    {
        ControlPanel.SetActive(true);
    }

    public void Sound()
    {
        VolumePanel.SetActive(true);
        PausePanel.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void ReturnVolume()
    {
        VolumePanel.SetActive(false);
        PausePanel.SetActive(true);
    }

    public void ReturnControl()
    {
        ControlPanel.SetActive(false);
    }
}
