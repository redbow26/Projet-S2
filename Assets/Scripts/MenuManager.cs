using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private InputManager inputActions;
    private GameObject _gameManager;
    private GameManager gameManager;

    private SaveVariable variable;

    private bool menuIsActive = false;

    public GameObject menu;
    public GameObject crosshair;

    [Header("Menu")]
    public GameObject mainMenu;
    public GameObject optionMenu;

    [Header("Slider")]
    public Slider volume;
    public Slider sensitivity;

    private void Awake()
    {
        inputActions = new InputManager();
        inputActions.GamePlay.Menu.performed += _ => Menu();

        _gameManager = GameObject.FindGameObjectWithTag("GameController");
        variable = GameObject.FindGameObjectWithTag("Variable").GetComponent<SaveVariable>();

        if (_gameManager)
        {
            gameManager = _gameManager.GetComponent<GameManager>();
        }
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void Menu()
    {
        if (!menuIsActive)
        {
            gameManager.deactivateMove();
            crosshair.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            Time.timeScale = 0.0f;

            menu.SetActive(true);
        }
        else
        {
            gameManager.activateMove();
            crosshair.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Time.timeScale = 1.0f;

            menu.SetActive(false);
            mainMenu.SetActive(true);
            optionMenu.SetActive(false);
        }
        menuIsActive = !menuIsActive;
    }

    public void DisplayOption()
    {
        optionMenu.SetActive(true);
        mainMenu.SetActive(false);
        if (variable)
        {
            sensitivity.value = variable.sensitivity;
            volume.value = variable.volume;
        }
    }

    public void QuitOption()
    {
        gameManager.changeSensitivity(sensitivity.value);
        gameManager.changeVolume(volume.value);

        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
