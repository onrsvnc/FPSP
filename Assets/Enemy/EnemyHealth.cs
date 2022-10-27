using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float hitPoints = 100f;

    //create a public method which reduces by the amount of damage;


    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        Debug.Log("Healt: " + hitPoints);
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

}
