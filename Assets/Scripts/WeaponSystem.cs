using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Scripting;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefabs;
    [SerializeField] Transform fireLocation;
    [SerializeField] Transform fireLocation2;
    [SerializeField] float forcer = 20f;
    [SerializeField] float rof;
    [SerializeField] AudioSource laserEffects1;

    private void Update()
    {
        rof -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0)) 
        {
            Fire();
        }


    }

    public void Fire()
    {
        if (rof <= 0)
        {
            GameObject bullets = Instantiate(bulletPrefabs, fireLocation.position, fireLocation.rotation);
            GameObject bullets2 = Instantiate(bulletPrefabs, fireLocation2.position, fireLocation2.rotation);
            bullets.GetComponent<Rigidbody>().AddForce(fireLocation.forward * forcer, ForceMode.Impulse);
            bullets2.GetComponent<Rigidbody>().AddForce(fireLocation2.forward * forcer, ForceMode.Impulse);
            laserEffects1.Play();
            rof = .2f;
        }

        
    }
}
