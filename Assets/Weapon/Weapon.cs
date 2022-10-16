using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float weaponDamage = 1f;
    [SerializeField] float shootingDelay = 1f; 
    [SerializeField] ParticleSystem muzzleEffect;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject mainCamera;

    bool isShooting = false;


    void Update()
    {
        if(Input.GetButton("Fire1") && isShooting != true)  
        {
            isShooting = true;
            StartCoroutine(AutoShoot());
        }

        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(AutoShoot());
            isShooting = false;
            muzzleEffect.Stop();
        }
        WeaponDamageReset();
    }

    void Shoot()
    {
        PlayMuzzleEffect();
        ProcessRaycast();
    }

    void PlayMuzzleEffect()
    {
        muzzleEffect.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) 
            {
                WeaponDamageReset(); 
                return; 
            }
            //todo we can add here another hit effect for enemy hits
            target.TakeDamage(weaponDamage);
        }
        else { return; }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, mainCamera.transform.rotation); //!!!Quaternion.LookRotation(hit.normal) can be used for other hit effects.!!!
        Destroy(impact, 1f);
    }

    IEnumerator AutoShoot()
    {
        while(isShooting)
        {
            weaponDamage *= 1.5f;
            Shoot();
            yield return new WaitForSeconds(shootingDelay);
        }
        
    }

    void WeaponDamageReset()
    {
        if(isShooting == false)
        {
            weaponDamage = 1f;
        }
    }
}
