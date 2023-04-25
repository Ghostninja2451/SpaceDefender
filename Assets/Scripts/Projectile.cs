using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    public void Update()
    {
        Destroy(gameObject, 1);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Hit");
        Destroy(gameObject);
    }
}
