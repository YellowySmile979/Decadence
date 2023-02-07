using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpParticles : MonoBehaviour
{
    ParticleSystem particleSystemm;

    // Start is called before the first frame update
    void Start()
    {
        particleSystemm = GetComponent<ParticleSystem>();

        particleSystemm.Stop();
    }

    //plays the power up particles
    public void PlayPowerUpParticles()
    {
        if(!particleSystemm.isPlaying)
        {
            particleSystemm.Play();
        }
    }
}
