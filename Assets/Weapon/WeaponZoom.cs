using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomIn = 50f;
    [SerializeField] float zoomOut = 90f;
    [SerializeField] float zoomOutSens = 3f;
    [SerializeField] float zoomInSens = 0.5f;

    SFPSC_FPSCamera fpsCam;
    Camera mainCam;

    void Start()
    {
        mainCam = FindObjectOfType<Camera>();
        fpsCam = FindObjectOfType<SFPSC_FPSCamera>();
    }

    void Update()
    {
        SwitchZoom();
    }

    void SwitchZoom()
    {
        if(Input.GetButton("Fire2"))  
        {
            mainCam.fieldOfView = zoomIn;
            fpsCam.sensitivity = zoomInSens;
        }

        if(Input.GetButtonUp("Fire2"))
        {
            mainCam.fieldOfView = zoomOut;
            fpsCam.sensitivity = zoomOutSens;
        }
        
    }

    public void ZoomOutOnWeaponSwitch()
    {
        mainCam.fieldOfView = zoomOut;
    }
}
