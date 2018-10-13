using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectiblesController : MonoBehaviour {
	
	public bool isCollected;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		
		isCollected = false;
		rb = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isCollected) 
		{
			Destroy(this.gameObject, 1.5f);
			Disappear();

		}
	}

	void Disappear() {
		this.transform.Rotate(Vector3.up, 720 * Time.deltaTime);
		this.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
		this.transform.localScale += new Vector3(.25f, .25f, .25f) * Time.deltaTime;
	}
}
