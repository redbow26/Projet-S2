using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{

    public UnityEvent activateMethod;
    public UnityEvent desactivateMethod;

    private bool activate = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!activate) {
            activateMethod.Invoke();
            activate = !activate;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (activate)
        {
            desactivateMethod.Invoke();
            activate = !activate;
        }
    }
}
