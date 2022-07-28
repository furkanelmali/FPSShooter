using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour   
{
    [SerializeField] float health = 100f;

    DeathHandler handler;


    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            handler = GetComponent<DeathHandler>();
            handler.handleDeath();
            Debug.Log("U'r Dead :/");
        }
    } 


}
