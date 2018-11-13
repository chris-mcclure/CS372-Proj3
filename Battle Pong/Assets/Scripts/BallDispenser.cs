using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDispenser : MonoBehaviour {
	//private GameObject[] ballz = new GameObject[12];
	public GameObject ball;
	private int playerCount;
	private int ballCount;
	private bool ballWait;
	// Use this for initialization
	void Awake () {
		Instantiate (ball, transform.position, transform.rotation);
		playerCount = GameInfo.playerCount;
	}

	// Update is called once per frame
	void Update () {
		//		if (GameObject.Find("BallPrefab(Clone)") == null) {
		//			spawnBall ();
		//		}
		ballCount = GameObject.FindGameObjectsWithTag ("Ball").Length;
		if (ballCount == 0)
			Instantiate (ball, transform.position, transform.rotation);
		if (ballCount < playerCount && !ballWait) {
			ballWait = true;
			StartCoroutine ("SpawnBall");
		}
	}

	IEnumerator SpawnBall() {
		float randTime = Random.Range (1.0f, 5.0f);
		yield return new WaitForSeconds (randTime);
		Instantiate (ball, transform.position, transform.rotation);
		Debug.Log (ballCount);
		ballWait = false;
	}
}
