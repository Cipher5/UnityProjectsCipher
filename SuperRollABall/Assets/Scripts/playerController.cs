using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    Rigidbody rb;
	canvasController cc;
    Vector3 offset;
    public float moveSpeed = 1000f;
	Vector3 resetPosition;
	bool canMove = true;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
		cc = GameObject.Find ("Canvas").GetComponent<canvasController>();
        offset = Camera.main.transform.position - rb.transform.position;
		resetPosition = rb.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

		Move();

        Camera.main.transform.position = rb.transform.position + offset;

		if (this.transform.position.y < -0.7f) {
			ReturnToCheckpoint ();
		}
       
    }

	void Move()
	{
		if (canMove) {

			float hdir = Input.GetAxisRaw ("Horizontal");
			float vdir = Input.GetAxisRaw ("Vertical");
			//float TimeToWaitInSeconds = 5f;

			Vector3 directionVector = new Vector3 (hdir, 0, vdir);
			Vector3 unitVector = directionVector.normalized;
			Vector3 forceVector = unitVector * moveSpeed * Time.deltaTime;

			rb.AddForce (forceVector);
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

		if (other.gameObject.tag == "LandMine") {

			Invoke ("ReturnToCheckpoint", 1.5f);
			rb.velocity = new Vector3(0, 0, 0);
			rb.AddForce (Vector3.up * 700f);
			canMove = false;
			ParticleSystem explode;
			explode = other.GetComponent<ParticleSystem> ();
			explode.Play ();
			//rb.AddForce (this.transform.forward * -100f);


		}

		if (other.gameObject.tag == "LandmineSmokeEffect") {
			ParticleSystem smoke;
			smoke = other.GetComponent<ParticleSystem> ();
			smoke.Play ();
		}

		if (other.gameObject.tag == "Boost") {
			rb.velocity = new Vector3 (0, 0, 0);
			rb.AddForce (Vector3.forward * 10000f);
			cc.IncreaseScore (400);
		}
		if (other.gameObject.tag == "Blade") {
			Invoke ("ReturnToCheckpoint", 1.5f);
			rb.velocity = new Vector3 (0, 0, 0);
			rb.AddForce (Vector3.left * 1000f);
			rb.AddForce (Vector3.up * 300f);
			canMove = false;
		}
    }

	void ReturnToCheckpoint ()
	{
		rb.transform.position = resetPosition;
		canMove = true;
	}
}



