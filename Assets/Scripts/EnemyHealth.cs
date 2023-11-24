using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
   
    // PUBLIC METHOD TO REDUCE HIT POINTS

    public void TakeDamage(float damage) 
    {
        health -= damage;
        Debug.Log("ENEMY KI HEALTH KAM HOGAYI");
        if (health <= 0) 
        {
            //END GAME? DESTROY OBJECT
        }
    }
}
