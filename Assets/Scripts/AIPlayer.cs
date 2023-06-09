using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class AIPlayer : MonoBehaviour
{
    public static AIPlayer instance;
    public float maxhealth;
    private float health;
    [SerializeField] float damage;
    public float maxSpeed;
    private float speed;
    private Collider[] hitColliders;
    private RaycastHit hitRays;
    
    [SerializeField] float sightRange;
    [SerializeField] float detectionRange;

    [SerializeField] Rigidbody rg;
    [SerializeField] GameObject target;



    private bool playerSpotted;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        health = maxhealth;
        speed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (!playerSpotted)
        {
            hitColliders = Physics.OverlapSphere(transform.position, detectionRange);
            foreach (var collider in hitColliders)
            {
                if (collider.tag == "Player")
                {
                    target = collider.gameObject;
                    playerSpotted = true;
                }
            }
        }
        else
        {
            if (Physics.Raycast(transform.position, (target.transform.position - transform.position), out hitRays, sightRange))
            {
                if (hitRays.collider.tag == "Player")
                {
                    playerSpotted = false;
                }
                else
                {
                    var head = target.transform.position - transform.position;
                    var distance = head.magnitude;
                    var direction = head / distance;

                    Vector3 move = new Vector3(direction.x * speed, 0, direction.z * speed);
                    rg.velocity = move;
                    transform.forward = move;
                }
            }
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Healths.Instance.Damage(damage);
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            TextModification.Instance.AddKill();
            ParticleSystemArray.instance.playAllParticleSystem();
            Destroy(gameObject);

        }
    }


}
