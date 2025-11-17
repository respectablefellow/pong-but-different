using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject pauseMenu;
    public GameObject hud;

    public GameObject redPanel;
    public GameObject bluePanel;



    public void ShowStartMenu()
    {
        startMenu.gameObject.SetActive(true);

    }
    public void HideStartMenu()
    {
        startMenu.gameObject.SetActive(false);
    }

    public void ShowPauseMenu()
    {
        pauseMenu.gameObject.SetActive(true);
    }
    public void HidePauseMenu()
    {
        pauseMenu.gameObject.SetActive(false);
    }

    public void ShowHUD()
    {
        hud.gameObject.SetActive(true);
    }
    public void HideHUD()
    {
        hud.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; 
    }

}

