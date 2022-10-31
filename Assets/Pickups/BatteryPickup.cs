using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] int batteryAmount = 10;
    [SerializeField] AmmoType ammoType;
    Ammo ammo;

    void Start() 
    {
       ammo = FindObjectOfType<Ammo>();    
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            ammo.IncreaseCurrentAmmo(batteryAmount, ammoType);
            Destroy(gameObject);
        }
    }
}
