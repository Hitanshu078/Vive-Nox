using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // [SerializeField] GameObject gunPoint;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 15f;
    [SerializeField] ParticleSystem muzzle;
    [SerializeField] GameObject hitFX;
    [SerializeField] int ammo = 20;

    AudioMan am;

    void Start()
    {
        am = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioMan>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ammo > 0 && Input.GetButtonDown("Shoot")) 
        {
            Shoot();
            ammo--;
        } 
        else if (ammo <= 0 && Input.GetButtonDown("Shoot"))
        {
            am.PlaySFX(am.emptyGun);
        }
    }

    public void CollectAmmo(int val) 
    {
        ammo += val;
        am.PlaySFX(am.ammoPick);
    }

    void CreateHitImpact(RaycastHit hit) 
    {
        GameObject impact = Instantiate(hitFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.5f);
    }

    void Shoot() 
    {
        muzzle.Play();
        am.PlaySFX(am.shoot);
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
