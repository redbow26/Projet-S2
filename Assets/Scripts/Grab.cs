using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public GameObject grabObject;
    public Transform grabPos;

    public void grab(GameObject obj)
    {
        print("test");
        grabObject = obj;
    }

    public void release()
    {
        grabObject = null;
    }

    public void teleport()
    {
        if (grabObject) grabObject.transform.position = grabPos.position;
    }

    private void Update()
    {
        if (grabObject)
        {
            grabObject.GetComponent<Rigidbody>().velocity = 10 * (grabPos.position - grabObject.transform.position);
        }
    }
}
