using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMovement : MonoBehaviour {

	Camera cam;
	// Use this for initialization

	[SerializeField]
	GameObject Bullet;

	[SerializeField]
	Transform shootingPoint;

	// force to fire at
	//public float fireForce;

	//
	//float fireAngle;
	public float firePower = 1000f;
	GameObject reticle;

	void Start () {
		cam = Camera.main;
		//fireAngle = 45.0f;
		//firePower = minFirePower;
		reticle = GameObject.FindGameObjectWithTag("reticle");
	}

	// Update is called once per frame
	void Update () {
		Vector3 mousePos;
		mousePos = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - transform.position.z));
		transform.parent.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - transform.position);



	/*	if (Input.GetKey(KeyCode.Space))
		{
			if (firePower < 1.0f)
			{
				firePower += 0.01f;
				//Debug.Log(firePower);
			}
			else
			{
				firePower = 1.0f;
			}
		}*/

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Vector3 pos =new Vector3(reticle.GetComponent<SocketClient>().xPos, reticle.GetComponent<SocketClient>().yPos, 0);
			Fire (pos);
		}
	}

	void Fire(Vector3 mPos)
	{
		GameObject _bulletholder = Instantiate (Bullet) as GameObject;
		_bulletholder.transform.position = shootingPoint.transform.position;
		_bulletholder.transform.rotation = shootingPoint.transform.rotation;
		Vector3 dir = Vector3.Normalize( mPos - transform.position);
		print ("x" + dir.x + "y" + dir.y);
		Vector2 force = new Vector2(dir.x,dir.y) * firePower;
		//print ("x" + force.x + "y" + force.y);
		_bulletholder.GetComponent<Rigidbody2D> ().AddRelativeForce (force, ForceMode2D.Impulse);

		//Vector2 dir = (Vector2)(Quaternion.Euler(0, 0, fireAngle) * Vector2.right);
		//Debug.Log(dir);

		//Vector2 force = dir * (firePower * fireForce);

		//_bulletholder.GetComponent<Rigidbody2D>().AddForce(force,ForceMode2D.Impulse);

		//firePower = minFirePower;
	}

}
