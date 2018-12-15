using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawController : MonoBehaviour {

	Transform thing;
	//public float speed = 0f;
	bool sawLeft;
	bool sawRight;


	// Use this for initialization
	void Start () {
		thing = this.GetComponent <Transform> ();
		sawLeft = true;
		sawRight = false;
	}
	
	// Update is called once per frame
	void Update () {



		if (sawLeft) {
			Vector3 leftVector = new Vector3 (0.1f, 0f, 0f);
			thing.transform.Translate (leftVector);
		}
		if (sawRight) {
			Vector3 rightVector = new Vector3 (-0.1f, 0f, 0f);
			thing.transform.Translate (rightVector);
		}
		//transform.Rotate (Vector3.up * Time.deltaTime);
	}
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "SawBladeRightTrigger") {
			sawRight = true;
			sawLeft = false;
		}
		if (other.gameObject.tag == "SawBladeLeftTrigger") {
			sawRight = false;
			sawLeft = true;
		}
	}
}
