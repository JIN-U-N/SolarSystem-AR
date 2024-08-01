using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class OpenInfoOnclick : MonoBehaviour
{
    public SolarSystemSet solarSystemSet;
    public GameObject currentInfoObj;

    Vector3 Up =new Vector3(0,1.5f,0);
    Vector3 InfoMaxScale=new Vector3(0.0015f,0.0015f,0.0015f);
    const float Speed= 2f;

    
    public void SetSelectedPrefab(GameObject InfoObj)
    {
        if(currentInfoObj!=null)
        {
            Destroy(currentInfoObj);
        }
        currentInfoObj=Instantiate(InfoObj);
        currentInfoObj.SetActive(true);
        currentInfoObj.transform.localScale=new Vector3(0,0,0);
        currentInfoObj.transform.position=solarSystemSet.SolarSystemTransform.position+Up;
        Handheld.Vibrate();
    }

    void Update()
    {
        currentInfoObj.transform.localScale=Vector3.Lerp(currentInfoObj.transform.localScale,InfoMaxScale,Time.deltaTime*Speed);
    }

}
