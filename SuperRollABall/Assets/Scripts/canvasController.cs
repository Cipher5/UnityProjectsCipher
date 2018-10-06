using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class canvasController : MonoBehaviour {

	public GameObject scoreText;
	int score;

	// Use this for initialization
	void Start () {
		score = 0;
		scoreText.GetComponent<Text>().text = "Score: 0";


	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space))
		{
			IncreaseScore(5);
		}
		
	}

	public void IncreaseScore(int amount)
	{
		score += amount;
		scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
	}

}
