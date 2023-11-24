using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject gunPoint;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 15f;
    [SerializeField] ParticleSystem muzzle;
    [SerializeField] GameObject hitFX;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shoot")) 
        {
            Shoot();
        }
    }

    void CreateHitImpact(RaycastHit hit) 
    {
        GameObject impact = Instantiate(hitFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.5f);
    }

    void Shoot() 
    {

        muzzle.Play();
        if (Physics.Raycast(gunPoint.transform.position, gunPoint.transform.forward, out RaycastHit hit, range)) 
        {
            CreateHitImpact(hit);
            Debug.Log("I hit this thing: " + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
    }
}
