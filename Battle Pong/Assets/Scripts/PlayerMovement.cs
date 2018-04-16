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
	public float speed = 5f;
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
	void Update () {

		float horizontal = Input.GetAxis ("Horizontal");
		rb.position = new Vector3 (Mathf.Clamp (rb.position.x, bounds.xMin, bounds.xMax),
								   0.0f,
								   zVal
								  );

		this.transform.localPosition = new Vector3 (Mathf.Clamp (this.transform.localPosition.x + horizontal * speed * Time.deltaTime, bounds.xMin, bounds.xMax),
												    0.0f,
													zVal
												   );
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
