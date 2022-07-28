using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    public Camera mainCam;

    public float normalFOV=60f;
    public float zoomedFOV=30f;

    public float normalSensivity = 2f;
    public float zoomedSensivity = .5f;
    RigidbodyFirstPersonController rfpc;

    bool zoomedInToggle = false;

    private void Start()
    {
        rfpc = GetComponent<RigidbodyFirstPersonController>();  
    }
    private void Update()
    {
        Zooming();
    }
    public void Zooming() 
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            if (zoomedInToggle == false) 
            {
                zoomedInToggle = true;
                mainCam.fieldOfView = zoomedFOV;
                rfpc.mouseLook.XSensitivity = zoomedSensivity;
                rfpc.mouseLook.YSensitivity = zoomedSensivity;
            }
            else 
            {
                zoomedInToggle = false;
                mainCam.fieldOfView = normalFOV;
                rfpc.mouseLook.XSensitivity = normalSensivity;
                rfpc.mouseLook.YSensitivity = normalSensivity;
            }
           
        
        }
    
    }
}