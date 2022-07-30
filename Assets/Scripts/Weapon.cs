using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 25f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] Ammo ammoSlot;

    bool canShoot = true;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot == true) 
        {
           StartCoroutine(Shoot());
        } 
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.getCurrentAmmo() > 0) 
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot=true;
    }
    private void PlayMuzzleFlash() 
    {

        muzzleFlash.Play();
    
    }
    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            Debug.Log("I hit this thing: " + hit.transform.name);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
            {
                return;
            }

            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit) 
    {

       GameObject impact =  Instantiate(hitEffect, hit.point, Quaternion.identity);
       Destroy(impact, .1f);

    }
}
