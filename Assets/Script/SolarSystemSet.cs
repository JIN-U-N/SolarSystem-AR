using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SolarSystemSet : MonoBehaviour
{
    public Indicator indicator_;
    public ARRaycastManager aRRaycastManager; 
    public List<ARRaycastHit> hits= new List<ARRaycastHit>();
    public GameObject SolarSystem;
    public GameObject ShadowPlane;
    public Transform SolarSystemTransform;
    public AudioSource audioSource;
    bool IsObj=true;

    Vector3 Up =new Vector3(0,0.5f,0);


    public void RayInstant() //태양계 생성 
    {
        Vector2 TouchPoint= Input.GetTouch(0).position;
        if(IsPointOverUIObject(TouchPoint))
        {
            return;
        }
        if(aRRaycastManager.Raycast(TouchPoint,hits,TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose= hits[0].pose;
            SolarSystem=Instantiate(SolarSystem,indicator_.indicator.transform.position+Up,indicator_.indicator.transform.rotation);
            ShadowPlane=Instantiate(ShadowPlane,hitPose.position,hitPose.rotation);
            SolarSystemTransform=SolarSystem.transform;
            GameObject IndicatorManager= GameObject.Find("Indicator Manager");
            IndicatorManager.SetActive(false);
            IsObj=false;
            Handheld.Vibrate();
            audioSource.Play();
        }
    }

    public bool IsPointOverUIObject(Vector2 pos)
    {
        PointerEventData eventDataCurPosition =new PointerEventData(EventSystem.current);
        eventDataCurPosition.position=pos;
        List<RaycastResult> results= new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurPosition,results);
        return results.Count>1;
    }

    void Update()
    {
        if(IsObj==true)
        {
            RayInstant();
        }
    }

}

