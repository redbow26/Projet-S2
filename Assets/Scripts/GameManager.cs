using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    private Player player;

    private GameObject _audioSource;
    private AudioSource audioSource;

    private SaveVariable variable;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _audioSource = GameObject.FindGameObjectWithTag("MainAudio");
        variable = GameObject.FindGameObjectWithTag("Variable").GetComponent<SaveVariable>();


        if (_player != null)
        {
            player = _player.GetComponent<Player>();
            if (variable != null)
                changeSensitivity(variable.sensitivity);
        }
        
        if (_audioSource)
        {
            audioSource = _audioSource.GetComponent<AudioSource>();
            if (variable != null)
                changeVolume(variable.volume);
        }
    }


    public void changeVolume(float volume)
    {
        if (_audioSource)
        {
            audioSource.volume = volume;
        }
        if (variable != null)
            variable.volume = volume;
    }

    public void QuitGame()
    {
        Debug.LogError("Quit");
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void changeSensitivity(float sensitivity)
    {
        if (_player != null)
        {
            player.lookSpeed = sensitivity / 10;
        }
        if (variable != null)
            variable.sensitivity = sensitivity;
    }

    public void activateTeleport()
    {
        if (_player != null)
        {
            player.canTeleport = true;
        }
    }

    public void deactivateTeleport()
    {
        if (_player != null)
        {
            player.canTeleport = false;
        }
    }

    public void activateMove()
    {
        if (_player != null)
        {
            player.canMove = true;
        }
    }

    public void deactivateMove()
    {
        if (_player != null)
        {
            player.canMove = false;
        }
    }
}
