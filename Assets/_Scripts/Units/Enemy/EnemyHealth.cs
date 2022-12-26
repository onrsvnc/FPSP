using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        Debug.Log("Healt: " + hitPoints);
        if(hitPoints <= 0)
        {
            if(isDead) return;
            StartCoroutine("EnemyDeath");
        }
    }

    IEnumerator EnemyDeath()
    {
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}
