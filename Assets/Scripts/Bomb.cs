using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float radius = 3f;
    [SerializeField] ParticleSystem explosion;

    void Update() 
    {
        //TODO CAN GIVE A WARNING WHEN PLAYER IS NEARBY
    }

    void OnTriggerEnter(Collider other) 
    {
        
        if (other.gameObject.CompareTag("Player")) 
        {   
            Instantiate(explosion, transform);
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            ph.TakeDamage(10f);
            
            Destroy(gameObject, 10f);
        }
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
