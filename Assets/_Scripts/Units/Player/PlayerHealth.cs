using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        Debug.Log("PlayerHP: " + hitPoints);
        if(hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }        
    }
    
}
