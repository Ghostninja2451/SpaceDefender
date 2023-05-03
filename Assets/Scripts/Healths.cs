using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healths : MonoBehaviour
{
    public static Healths Instance;
    [SerializeField] float maxHealth;
    private float health;

    public HealthBar healthBar;
    void Start()
    {
        health = maxHealth;
        healthBar.SetSliderMax(maxHealth);
        Instance = this;
    }

    public void Damage(float damage)
    {
        
        health -= damage;
        healthBar.SetSlider(health);

        if (health <= 0) 
        {
            Destroy(gameObject);
            //Gameover screen
        }

    }


}
