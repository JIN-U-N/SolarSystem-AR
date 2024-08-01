using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Indicator : MonoBehaviour
{
    public ARRaycastManager aRRaycastManager;
    public GameObject indicator;
    private List<ARRaycastHit>hits= new List<ARRaycastHit>();

    void Start()
    {
        indicator.SetActive(false);
    }

    public void IsIndicator()
    {
        var ray= new Vector3(Screen.width/2,Screen.height/2);
        if(aRRaycastManager.Raycast(ray,hits,TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose= hits[0].pose;
            transform.position=hitPose.position;  
            if(!indicator.activeInHierarchy)
            {
                indicator.SetActive(true);
            }
        }

    }


    void Update()
    {
        IsIndicator();
    }
}
