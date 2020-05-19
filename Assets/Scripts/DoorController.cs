using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public GameObject Door;
    private bool doorIsOpen = false;
    public int timeOpen = 0;


    public void Open()
    {
        if (!doorIsOpen)
        {
            Door.transform.Translate(Vector3.down * 7);
            doorIsOpen = true;
            if (timeOpen != 0)
            {
                Invoke("Close", timeOpen);
            }
        }
    }

    public void Close()
    {
        if (doorIsOpen)
        {
            Door.transform.Translate(Vector3.up * 7);
            doorIsOpen = false;
        }
    }
}
