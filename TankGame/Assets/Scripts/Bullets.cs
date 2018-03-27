﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

	// Use this for initialization

	[SerializeField]
	GameObject[] Bullet;

	[SerializeField]
	Transform shootingPoint;

	int bulletCounter = 0;

	public float power = 1000f;
	//public float angle = 50f;

	void Start () 
	{
		cam = Camera.main;
	}
	Camera cam;

	// Update is called once per frame
	void Update () 
	{
		Vector3 mousePos;
		if (Input.GetMouseButton (0)) {
			mousePos = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
			Vector2 direction = mousePos - transform.position;

			float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;

			Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);

			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, 5f * Time.deltaTime);
			Debug.Log (mousePos.x);
		}



		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{
			bulletCounter++;
			bulletCounter = bulletCounter % 5;
		}
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Fire (bulletCounter);
		}
	}

	private void Fire(int bulletCounter)
	{
		/*
		if (bulletCounter == 1) {
			GameObject _bulletholder = Instantiate (Bullet [bulletCounter]) as GameObject;
			_bulletholder.transform.position = shootingPoint.transform.position;
			_bulletholder.transform.rotation = shootingPoint.transform.rotation;
			_bulletholder.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (power, angle * 10f - 20f), ForceMode2D.Force);

			GameObject _bulletholder1 = Instantiate (Bullet [bulletCounter]) as GameObject;
			_bulletholder1.transform.position = shootingPoint.transform.position;
			_bulletholder1.transform.rotation = shootingPoint.transform.rotation;
			_bulletholder1.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (power, angle * 10f), ForceMode2D.Force);

			GameObject _bulletholder2 = Instantiate (Bullet [bulletCounter]) as GameObject;
			_bulletholder2.transform.position = shootingPoint.transform.position;
			_bulletholder2.transform.rotation = shootingPoint.transform.rotation;
			_bulletholder2.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (power, angle * 11f + 20f), ForceMode2D.Force);
		} 
		else if (bulletCounter == 4) {
			GameObject _bulletholder = Instantiate (Bullet [bulletCounter]) as GameObject;
			_bulletholder.transform.position = shootingPoint.transform.position;
			_bulletholder.transform.rotation = shootingPoint.transform.rotation;
			_bulletholder.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (power, angle * 8f - 20f), ForceMode2D.Force);

			GameObject _bulletholder1 = Instantiate (Bullet [bulletCounter]) as GameObject;
			_bulletholder1.transform.position = shootingPoint.transform.position;
			_bulletholder1.transform.rotation = shootingPoint.transform.rotation;
			_bulletholder1.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (power, angle * 9f - 10f), ForceMode2D.Force);

			GameObject _bulletholder2 = Instantiate (Bullet [bulletCounter]) as GameObject;
			_bulletholder2.transform.position = shootingPoint.transform.position;
			_bulletholder2.transform.rotation = shootingPoint.transform.rotation;
			_bulletholder2.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (power, angle * 10f), ForceMode2D.Force);

			GameObject _bulletholder3 = Instantiate (Bullet [bulletCounter]) as GameObject;
			_bulletholder3.transform.position = shootingPoint.transform.position;
			_bulletholder3.transform.rotation = shootingPoint.transform.rotation;
			_bulletholder3.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (power, angle * 11f + 10f), ForceMode2D.Force);

			GameObject _bulletholder4 = Instantiate (Bullet [bulletCounter]) as GameObject;
			_bulletholder4.transform.position = shootingPoint.transform.position;
			_bulletholder4.transform.rotation = shootingPoint.transform.rotation;
			_bulletholder4.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (power, angle * 12f + 20f), ForceMode2D.Force);
		}
		else {
			GameObject _bulletholder = Instantiate (Bullet [bulletCounter]) as GameObject;
			_bulletholder.transform.position = shootingPoint.transform.position;
			_bulletholder.transform.rotation = shootingPoint.transform.rotation;
			//_bulletholder.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (power, angle * 10f), ForceMode2D.Force);
			_bulletholder.GetComponent<Rigidbody2D> ().AddForceAtPosition (new Vector2 (power, angle), new Vector2(power, angle), ForceMode2D.Force);
		}
		*/
	}
}
