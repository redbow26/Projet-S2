using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Slider volume;
    public Slider sensitivity;
    public GameManager gameManager;

    public GameObject mainMenu;
    public GameObject optionMenu;

    public void Jouer ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame ()
    {
        Application.Quit();
    }

    public void DisplayOption()
    {
        optionMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void QuitOption()
    {
        gameManager.changeSensitivity(sensitivity.value);
        gameManager.changeVolume(volume.value);

        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}