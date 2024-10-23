using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAndSmells : MonoBehaviour
{

    public GameObject smellParticle;
    public GameObject soundParticle;

    public Unit unit;
    public float timeBTWparticles;
    public float currentTimeBTWparticles;
    void Start()
    {
        
    }
    void Update()
    {
        currentTimeBTWparticles += Time.deltaTime;
        if(currentTimeBTWparticles>=timeBTWparticles)
        {
            currentTimeBTWparticles = 0;
            Instantiate(smellParticle, gameObject.transform.position, gameObject.transform.rotation);
            Instantiate(soundParticle, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
