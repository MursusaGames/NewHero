using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseView;
    [SerializeField] private GameObject popUpExit;
    [SerializeField] private GameObject joystic;

    public void Pause()
    {
        Time.timeScale = 0;
        joystic.Hide();
        pauseView.Show();
    }

    public void Resume()
    {
        pauseView.Hide();
        Time.timeScale = 1;
        joystic.Show();
    }

    public void ExitPopUpShow()
    {
        popUpExit.Show();
    }

    public void ExitPopUpHide()
    {
        popUpExit.Hide();
    }
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    


}
