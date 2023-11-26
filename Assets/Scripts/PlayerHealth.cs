using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
   
    // PUBLIC METHOD TO REDUCE HIT POINTS

    public void TakeDamage(float damage) 
    {
        health -= damage;
        Debug.Log("HEALTH KAM HOGAYI");
        if (health <= 0) 
        {
            //LOGIC TO RESPAWN HERE
        }
    }
}
