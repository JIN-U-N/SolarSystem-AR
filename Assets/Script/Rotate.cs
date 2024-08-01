using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Rotate : MonoBehaviour
{
    Transform transform_;
    public bool Rotate_layer=false;
    public bool Rotate_Belt=false;
    public bool Rotate_Planet=false;

    void Start()
    {
        transform_=this.GetComponent<Transform>();
    }

    void Update()
    {
        if(Rotate_layer)
        {
            Rotate_AsteroidsLayer();
        }

        if(Rotate_Belt)
        {
            Rotate_AsteroidsBelt();
        }

        if(Rotate_Planet)
        {
            Rotate_Planets();
        }
        
    }

    void Rotate_AsteroidsLayer()
    {
        Vector3 Rotate_layer=new Vector3(2f,2f,0);
        transform.Rotate(Rotate_layer*1f*Time.deltaTime);
    }

    void Rotate_AsteroidsBelt()
    {
        Vector3 Rotate_Belt=new Vector3(0,2f,0);
        transform.Rotate(Rotate_Belt*1f*Time.deltaTime);
    }

    void Rotate_Planets()
    {
        Vector3 Rotate_Plt= new Vector3(0,1f,0);
        transform.Rotate(Rotate_Plt*1f*Time.deltaTime);
        
    }
}
