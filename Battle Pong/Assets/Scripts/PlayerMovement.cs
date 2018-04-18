using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Bounds
{
	public float xMin, xMax;
}

public class PlayerMovement : MonoBehaviour {
	public float speed = 0.5f;
	public GameObject boundingLine;
	public Bounds bounds;
	private Rigidbody rb;
	public float zVal;
	private int score;
	public Text scoreText;




	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
		score = 0;
		setScore (0);
	}

	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = Vector3.zero;
		float horizontal = Input.GetAxis (this.gameObject.name + "Strafe");
		rb.position += (this.transform.right * horizontal * speed * Time.deltaTime);
		//this.transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision col)
	{
		
		if(col.gameObject.tag == "Wall")
		{
			//rb.velocity = Vector3.zero;
		}
	}

	public void setScore(int val) {
		if (val < 0)
			val = 0;
		score = val;
		scoreText.text = "Score : " + score.ToString ();
	}

	public int getScore() {
		return score;
	}
}
