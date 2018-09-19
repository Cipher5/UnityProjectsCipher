using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	Rigidbody rb;
	public float moveSpeed = 40f;
	// Use this for initialization
	void Start () {

		rb = this.GetComponent<Rigidbody>();
	}
	
	//  once per frame
	void Update () {

		rb.AddForce(forceVector);
		float hdir = Input.GetAxisRaw ("Horizontal");
		float vdir = Input.GetAxisRaw ("Vertical");

		Vector3 directionVector = new Vector3 (hdir, 0, vdir);
		Vector3 unitVector = directionVecter.normalized;
		Vector3 forceVector = unitVector * moveSpeed * Time.deltaTime;
	}
}
