using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{

    public UnityEvent activateMethod;
    public UnityEvent desactivateMethod;
    private Animator animator;

    private bool activate = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other);
        if (!activate) 
        {
            animator.SetTrigger("Press");
            activateMethod.Invoke();
            activate = !activate;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (activate)
        {
            animator.SetTrigger("Release");
            desactivateMethod.Invoke();
            activate = !activate;
        }
    }
}
