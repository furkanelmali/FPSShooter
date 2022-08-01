using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public bool isDead = false;

    public void TakeDamage(float damage) 
    {
        BroadcastMessage("AmIGetShoot");
        hitPoints -= damage;
        if(hitPoints <= 0) 
        {
            Die();       
        }
    }

    private void Die() 
    {
        if (isDead) { return; }
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
       //GetComponent<EnemyAI>().target = null;
       // GetComponent<EnemyAI>().enabled = false;
    }
}
