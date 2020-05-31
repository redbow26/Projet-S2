using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider volume;
    private GameObject _gameManager;
    private GameManager gameManager;

    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController");

        if (_gameManager)
        {
            gameManager = _gameManager.GetComponent<GameManager>();
        }
    }
    private void Update()
    {
        gameManager.changeVolume(volume.value);
    }
}