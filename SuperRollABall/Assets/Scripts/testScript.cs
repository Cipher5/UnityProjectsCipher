using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour {

	Transform thing;
	bool spikes;


	// Use this for initialization
	void Start () {
		thing = this.GetComponent <Transform> ();
		spikes = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (spikes) {
			Vector3 upVector = new Vector3 (0, 1, 0);
			thing.transform.Translate (upVector);
		}
	}

	void OnTriggerEnter (Collider other) {
		
		if (other.gameObject.tag == "Player") {
			spikes = true;


		}
	}
}
