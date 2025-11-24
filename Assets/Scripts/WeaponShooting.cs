using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    public int damage = 10;
    public float impactForce = 100f;
    public float range = 100f;
    public float firingRate = 15f;

    public Camera cam;
    private float nextTimetoFire = 0f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1f / firingRate;
            Shoot();
        }

    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            ZombieStats zombie = hit.transform.GetComponent<ZombieStats>();
            if(zombie != null)
            {
                zombie.TakeDamage(damage);
            }
        }
    }
}


