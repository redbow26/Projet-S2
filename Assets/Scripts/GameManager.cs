using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    private Player player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        player = _player.GetComponent<Player>();
    }

    public void activateTeleport()
    {
        player.canTeleport = true;
    }

    public void deactivateTeleport()
    {
        player.canTeleport = false;
    }

    public void activateMove()
    {
        player.canMove = true;
    }

    public void deactivateMove()
    {
        player.canMove = false;
    }
}
