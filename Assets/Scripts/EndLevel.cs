using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public string nextScene;
    void OnTriggerEnter(Collider col)
    {
        if (col.name == "FPSPlayer")
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
