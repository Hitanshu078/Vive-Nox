using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class EnemyAIShoot : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform gunPoint;
    [SerializeField] float damage = 6f;
    [SerializeField] float range = 100f;
    [SerializeField] float shootRange = 8f;
    [SerializeField] float timer = 1f;
    [SerializeField] ParticleSystem muzzle;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] GameObject hitFX;
    float bulletTime;
    float distanceToTarget = Mathf.Infinity;
    bool isShooting = false;

    void CreateHitImpact(RaycastHit hit) 
    {
        GameObject impact = Instantiate(hitFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        
        if (isShooting) 
        {
            Shoot();
        }
        
        if (distanceToTarget <= shootRange)
        {
            isShooting = true;
            FaceTarget();
        }
        else 
        {
            isShooting = false;
        }
    }
    
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    // TODO: ADD BULLET HIT EFFECT ON OBJECT HIT
    // TODO: NEED TO ADD A SCHEDULED HITTING METHOD (HIT AFTER EVERY X SECONDS)
    void Shoot()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = timer;
        muzzle.Play();

        if (Physics.Raycast(gunPoint.position, gunPoint.forward, out RaycastHit hit, range))
        {
            CreateHitImpact(hit);
            PlayerHealth ph = hit.transform.GetComponent<PlayerHealth>();
            if (ph == null) return;
            ph.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootRange);
    }
}
