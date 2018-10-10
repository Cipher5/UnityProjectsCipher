using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectiblesController : MonoBehaviour {
	
	public bool isCollected;
	// Use this for initialization
	void Start () {
		
		isCollected = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (isCollected) 
		{
			Debug.Log ("Splut");
			Destroy (this.gameObject);
		}
	}
}
