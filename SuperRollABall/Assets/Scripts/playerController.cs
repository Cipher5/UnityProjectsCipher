﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    Rigidbody rb;
    Vector3 offset;
    public float moveSpeed = 1000f;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
        offset = Camera.main.transform.position - rb.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        float hdir = Input.GetAxisRaw("Horizontal");
        float vdir = Input.GetAxisRaw("Vertical");

        Vector3 directionVector = new Vector3(hdir, 0, vdir);
        Vector3 unitVector = directionVector.normalized;
        Vector3 forceVector = unitVector * moveSpeed * Time.deltaTime;

        rb.AddForce(forceVector);

        Camera.main.transform.position = rb.transform.position + offset;
       
    }
}
