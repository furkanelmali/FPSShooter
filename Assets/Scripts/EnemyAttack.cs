using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 40f;
    public PlayerHealth PlayerHealth;
    void Start()
    {
        
    }

    public void AttackHitEvent() 
    {
        if(target == null ) return;
        
        PlayerHealth.TakeDamage(damage);
        Debug.Log("Bang Bang");
    
    }
    
}
