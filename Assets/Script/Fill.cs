using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fill : MonoBehaviour
{
    public Renderer rend;
    public ParticleSystem particleSystem;


    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }

    public void fillAcid(float floatvalue)
    {

        rend.material.SetFloat("Fill", floatvalue);
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
