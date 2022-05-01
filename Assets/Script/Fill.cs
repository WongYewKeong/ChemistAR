using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fill : MonoBehaviour
{
    public Renderer rend, rend1;
    public ParticleSystem particleSystem;

    public void fillAcid(float floatvalue)
    {
        rend.material.SetFloat("Fill", floatvalue);
    }

    public void fill(float floatvalue)
    {
        rend1.material.SetFloat("Fill", floatvalue);
    }

    public void playParticle()
    {
        particleSystem.Play();
        var emission = particleSystem.emission;
        emission.enabled = true;
    }

    public void stopParticle()
    {
        particleSystem.Stop();
        var emission = particleSystem.emission;
        emission.enabled = false;
    }
}
