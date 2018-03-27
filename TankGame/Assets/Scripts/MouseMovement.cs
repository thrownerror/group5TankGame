using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour {

	// Use this for initialization
	Camera cam;
	public float speed = 5f;
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		Vector2 direction = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;

		float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;

		Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);

		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, speed * Time.deltaTime);
		*/
		Vector3 mousePos;
		mousePos = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
		transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - transform.position);
		//Debug.Log (angle);
		
	}
}
