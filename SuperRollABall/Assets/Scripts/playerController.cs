using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    Rigidbody rb;
	canvasController cc;
    Vector3 offset;
    public float moveSpeed = 1000f;
	Vector3 resetPosition;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
		cc = GameObject.Find ("Canvas").GetComponent<canvasController>();
        offset = Camera.main.transform.position - rb.transform.position;
		resetPosition = rb.transform.position;
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

		if (this.transform.position.y < -0.7f) {
			ReturnToCheckpoint ();
		}
       
    }
    void OnTriggerEnter(Collider other) 
        {

		if (other.gameObject.tag == "Checkpoint") 
		{
			if (resetPosition != other.transform.position) 
			{
				resetPosition = other.transform.position;
			}
		}
        
        if (other.gameObject.tag == "Collectible") 
        {
            
			cc.IncreaseScore (150);
			other.GetComponent<collectiblesController> ().isCollected = true;
        }
    }

	void ReturnToCheckpoint ()
	{
		rb.transform.position = resetPosition;
	}
}



