using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupAmmo : MonoBehaviour
{
    [SerializeField] Weapon weapon;

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            weapon.CollectAmmo(20);
            Destroy(gameObject);
        }
    }
}
