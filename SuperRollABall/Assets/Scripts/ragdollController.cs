﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ragdoll;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("sda");
        this.gameObject.SetActive(false);
        Instantiate(ragdoll, this.transform.position, this.transform.rotation, null);

        if (other.gameObject.tag == "ragdollTrigger")
        {
            Debug.Log("sda");
            this.gameObject.SetActive(false);
            Instantiate(ragdoll, this.transform.position, this.transform.rotation, null);
        }
    }
}
