using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float damage;
    public void Update()
    {
        Destroy(gameObject, 1);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Hit");
        if (collision.gameObject.TryGetComponent<AIPlayer>(out AIPlayer enemyComponent))
        {
            enemyComponent.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
