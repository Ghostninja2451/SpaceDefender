using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healths : MonoBehaviour
{
    [SerializeField] float maxHealth;
    private float health;

    public HealthBar healthBar;
    void Start()
    {
        health = maxHealth;
        healthBar.SetSliderMax(maxHealth);
    }

    public void Damage(float damage)
    {
        
        health -= damage;
        healthBar.SetSlider(health);

        if (health <= 0) 
        {
            Destroy(gameObject);
        }

    }


}
