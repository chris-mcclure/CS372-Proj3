
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour {
	public float speed;
	private Rigidbody rb;
	private AudioSource audioSource;
	private int score;
	private int winPoints = 10;
	public Text scoreText;
	public bool usingController;
	public string inputIdentifier;
	bool canMove;
	public GameObject gravField;
	bool gravUsable;
	private Vector3 initialPos;
	public AudioClip[] audioClip;


	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
		inputIdentifier = GameInfo.inputMap[gameObject.name];
		audioSource = GetComponent<AudioSource> ();
		initialPos = rb.position;
		score = 0;
		setScore (0);
		canMove = true;
		gravUsable = true;
		speed = 55;
		//set these here just in case someone forgot to do something in the GUI
		rb.drag = 10;
		rb.mass = 500;
		rb.isKinematic = false;
		scoreText.resizeTextMaxSize = 1;
	}

	void Update() {
		if (score > winPoints)
			WinnerMode ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		movement ();
	}

	void movement() {
		float horizontal;
		
		horizontal = Input.GetAxis (inputIdentifier + "Strafe");
		if (Mathf.Abs(horizontal) > 0.1 && canMove)
			rb.position += (this.transform.right * horizontal * speed * Time.deltaTime);

		if(Input.GetButtonDown(inputIdentifier + "Push") && canMove)
		{
			canMove = false;
			StartCoroutine(push());
		}
		if(Input.GetButtonDown(inputIdentifier + "Grav") && gravUsable)
		{
			gravUsable = false;
			StartCoroutine(grav());
		}
	}

	public void playSound(int clip)
	{
		audioSource.clip = audioClip [clip];
		audioSource.Play ();

	}


	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Goal")
		rb.position += (this.transform.forward * 1);
	}

	IEnumerator grav()
	{
		Instantiate(gravField, initialPos, transform.rotation);
		yield return new WaitForSeconds(5f);
		gravUsable = true;

	}
	IEnumerator push()
	{
		int force  = 30000;
		rb.velocity = Vector3.zero;
		Vector3 initialPos = rb.position;
		Vector3 newPos = transform.forward;
		
		rb.AddForce(newPos.x * force, 0 , newPos.z * force, ForceMode.Impulse);
		yield return new WaitForSeconds(0.3f);
		force += 1000;
		rb.AddForce(newPos.x * force *-1 , 0, newPos.z * force * -1 , ForceMode.Impulse);
		yield return new WaitForSeconds(0.3f);
		rb.velocity = Vector3.zero;
		rb.position = initialPos;
		canMove = true;
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

	public int getWinPoints(){
		return winPoints;
	}

	public void WinnerMode() {
		
		Color winColor = Random.ColorHSV (0f, 1f, 1f, 1f, 0.5f, 1f);
		RectTransform textRect = scoreText.GetComponent<RectTransform> ();
		GameObject floor = GameObject.Find ("Floor");
		GetComponent<Renderer>().material.color = winColor;
		floor.GetComponent<Renderer> ().material.color = winColor;
		scoreText.color = winColor;
		scoreText.text = this.gameObject.name + " is winner !!!";
		//playSound (1);
		//textRect.anchoredPosition = new Vector3 (0,0,0);
		textRect.anchoredPosition = rb.position;
		scoreText.fontSize = 100;
		Time.timeScale = 0f;

	}
}
