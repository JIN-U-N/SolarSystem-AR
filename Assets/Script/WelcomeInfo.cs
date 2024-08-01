using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class WelcomeInfo : MonoBehaviour
{
    public GameObject WelcomeUI;
    public GameObject InfoUI;
    
    public void Hide()
    {
        WelcomeUI.SetActive(false);
        InfoUI.SetActive(true);
    }
}
