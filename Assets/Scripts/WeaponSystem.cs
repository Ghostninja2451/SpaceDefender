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
    [SerializeField] AudioSource laserEffects1;

    public void Fire()
    {
        
        GameObject bullets = Instantiate(bulletPrefabs, fireLocation.position, fireLocation.rotation);
        GameObject bullets2 = Instantiate(bulletPrefabs, fireLocation2.position, fireLocation2.rotation);
        bullets.GetComponent<Rigidbody>().AddForce(fireLocation.forward * forcer , ForceMode.Impulse);
        bullets2.GetComponent<Rigidbody>().AddForce(fireLocation2.forward * forcer , ForceMode.Impulse);
        laserEffects1.Play();
    }
}
