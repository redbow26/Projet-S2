using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileManager : MonoBehaviour
{
    public bool isMobile;

    public GameObject mobileUI;

    private void Awake()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
            isMobile = true;
        else
            isMobile = false;
    }

    private void Start()
    {
        if (isMobile)
        {
            mobileUI.SetActive(true);
        }
    }
}
