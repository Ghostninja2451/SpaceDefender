using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemArray : MonoBehaviour
{
    [SerializeField] ParticleSystem[] particleSystems;
    public static ParticleSystemArray instance;
    
    private void Start()
    {
        instance = this;
    }

    public void playAllParticleSystem()
    {
        foreach (var particleSystem in particleSystems)
        {
            if (particleSystem != null) 
            {
                particleSystem.Play();
            }
        }
    }
}
