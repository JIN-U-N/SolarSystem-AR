using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToFaceCam : MonoBehaviour
{
    Transform cam;
    Vector3 targetAngle= Vector3.zero;
    Vector3 Y_angle= new Vector3(0,180,0);


    void Start()
    {
        cam=Camera.main.transform;
    }
    
    void Update()
    {
        this.transform.LookAt(cam);
        targetAngle=transform.localEulerAngles;
        targetAngle.x=0f;
        targetAngle.z=0f;
        transform.localEulerAngles=targetAngle+Y_angle;
    }
}
