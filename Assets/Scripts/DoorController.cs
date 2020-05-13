using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public GameObject Door;
    private bool doorIsOpening = true;
    private InputManager inputActions;
    CharacterController characterController;

    void Awake()
    {

        characterController = GetComponent<CharacterController>();
        inputActions = new InputManager();
        inputActions.GamePlay.Use.performed += _ => Opening();
    }

    public void Opening()
    {
        if (doorIsOpening == true)
        {
            Door.transform.Translate(Vector3.up * 7);
            doorIsOpening = false;
        }

        else
        {
            Door.transform.Translate(Vector3.down * 7);
            
            doorIsOpening = true;
        }
        
    }
}
