using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [Header("Method")]
    public UnityEvent activateMethod;
    public UnityEvent deactivateMethod;

    [Header("Animator")]
    public string triggerActivate;
    public string triggerDeactivate;
    private Animator animator;
    private bool activate = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();  
    }

    public void Active()
    {
        if (!activate)
        {
            if (animator) animator.SetTrigger(triggerActivate);
            activateMethod.Invoke();
        }
        else
        {
            if (animator) animator.SetTrigger(triggerDeactivate);
            deactivateMethod.Invoke();
        }

        activate = !activate;
    }
}
