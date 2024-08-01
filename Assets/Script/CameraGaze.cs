using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class CameraGaze : MonoBehaviour
{
 List<InfoBehavior> infos= new List<InfoBehavior>();
    GameObject InfoObj;

    void Start()
    {
        infos = FindObjectsOfType<InfoBehavior>().ToList();
    }
    
    void Update()
    {
        if(Physics.Raycast(transform.position,transform.forward,out RaycastHit hit))
        {
            InfoObj = hit.collider.gameObject;
            if (InfoObj != null)
            {
                OpenInfo(InfoObj.GetComponent<InfoBehavior>());
            }
            else
            {
                CloseAll();
            }
        }
    }

    void OpenInfo(InfoBehavior desiredInfo)
    {
        foreach(InfoBehavior info in infos)
        {
            if(info==desiredInfo)
            {
                info.OpenInfo();
            }
            else
            {
                info.CloseInfo();
            }
        }
    }
    void CloseAll()
    {
        foreach(InfoBehavior info in infos)
        {
            info.CloseInfo();
        }
    }
}
