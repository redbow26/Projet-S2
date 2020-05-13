using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent activateMethod;
    public UnityEvent desactivateMethod;

    private bool activate = false;

    public void Active()
    {
        if (!activate) activateMethod.Invoke();
        else desactivateMethod.Invoke();

        activate = !activate;
    }
}
