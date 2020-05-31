using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveVariable : MonoBehaviour
{
    public float sensitivity = 1.5f;
    public float volume = 0.01f;

    private static SaveVariable variableInstance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (variableInstance == null)
        {
            variableInstance = this;
        }
        else
        {
            DestroyObject(this.gameObject);
        }
    }
}
