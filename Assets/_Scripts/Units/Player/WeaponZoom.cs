using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomInFov = 50f;
    [SerializeField] float zoomOutFov = 90f;
    [SerializeField] float zoomOutSens = 3f;
    [SerializeField] float zoomInSens = 0.5f;
    [SerializeField] float zoomInSpeed = 10f;
    [SerializeField] float zoomOutSpeed = 10f;

    Vector3 originalPos;
    Vector3 originalRotation;
    

    SFPSC_FPSCamera fpsCam;
    Camera mainCam;

    void Start()
    {
        originalPos = GameObject.Find("Laptop").transform.localPosition;
        originalRotation = GameObject.Find("Laptop").transform.localEulerAngles;
        mainCam = FindObjectOfType<Camera>();
        fpsCam = FindObjectOfType<SFPSC_FPSCamera>();
    }

    void OnDisable() 
    {
        ZoomOutOnWeaponSwitch();
    }

    void Update()
    {
        SwitchZoom();
    }

    void SwitchZoom()
    {
        if(Input.GetButton("Fire2"))  
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, zoomInFov, Time.deltaTime * zoomInSpeed);
            GameObject.Find("Laptop").transform.localPosition = GameObject.Find("Zoomed").transform.localPosition;
            GameObject.Find("Laptop").transform.localEulerAngles = GameObject.Find("Zoomed").transform.localEulerAngles;
            fpsCam.sensitivity = zoomInSens;
        }

        else
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, zoomOutFov, Time.deltaTime * zoomOutSpeed);
            GameObject.Find("Laptop").transform.localPosition = originalPos;
            GameObject.Find("Laptop").transform.localEulerAngles = originalRotation;
            fpsCam.sensitivity = zoomOutSens; 
        }
        
    }

    void ZoomOutOnWeaponSwitch()
    {
        mainCam.fieldOfView = zoomOutFov;
        fpsCam.sensitivity = zoomOutSens;
    }
}
