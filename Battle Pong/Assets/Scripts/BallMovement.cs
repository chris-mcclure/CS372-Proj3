using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
	private Rigidbody _rb;
	public float _speed;
	private float _moveIntialX;
	private float _moveIntialZ;

	private Vector3 _movement;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody> ();
		_moveIntialX = Random.Range (-1.0f, 1.0f);
		_moveIntialZ = Random.Range (-1.0f, 1.0f);

		_movement = new Vector3(_moveIntialX, 0, _moveIntialZ);
	}

	// Update is called once per frame
	void Update () {
		_rb.MovePosition (_rb.position + _movement * Time.deltaTime * _speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Walls"))
		{
			_movement = -1 * _movement;
		}
	}
}
