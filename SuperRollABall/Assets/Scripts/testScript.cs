using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour {

	Transform thing;
	bool upSpikes;
	bool downSpikes;


	// Use this for initialization
	void Start () {
		thing = this.GetComponent <Transform> ();
		upSpikes = false;
		downSpikes = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (upSpikes) {
			Vector3 upVector = new Vector3 (0, 1, 0);
			thing.transform.Translate (upVector);
		}
		if (downSpikes) {
			Vector3 downVector = new Vector3 (0, -1, 0);
			thing.transform.Translate (downVector);
		}
	}

	void OnTriggerEnter (Collider other) {
		
		if (other.gameObject.tag == "CrusherTrigger1") {
			upSpikes = true;
			downSpikes = false;


		}
		if (other.gameObject.tag == "CrusherTrigger2") {
			upSpikes = false;
			downSpikes = true;

		}
	}
}
