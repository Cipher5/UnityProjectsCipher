﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bleedOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ragdollTrigger") { 
            ParticleSystem bleed;
            bleed = this.GetComponent<ParticleSystem>();
            bleed.Play();
        }
    }
}
