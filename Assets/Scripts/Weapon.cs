using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // [SerializeField] GameObject gunPoint;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 15f;
    [SerializeField] ParticleSystem muzzle;
    [SerializeField] GameObject hitFX;
    [SerializeField] int ammo = 20;

    // Update is called once per frame
    void Update()
    {
        if (ammo > 0) 
        {
            if (Input.GetButtonDown("Shoot")) 
            {
                Shoot();
                ammo--;
            }
        }
    }

    public void CollectAmmo(int val) 
    {
        ammo += val;
    }

    void CreateHitImpact(RaycastHit hit) 
    {
        GameObject impact = Instantiate(hitFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.5f);
    }

    void Shoot() 
    {
        muzzle.Play();
        // - transform.forward since weapon is rotated 180 deg
        if (Physics.Raycast(transform.position, -transform.forward, out RaycastHit hit, range)) 
        {
            CreateHitImpact(hit);
            Debug.Log("I hit this thing: " + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
    }
}
