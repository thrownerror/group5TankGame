using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMovement : MonoBehaviour {

	Camera cam;
    bool firing;
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
    float powerLevel;
	GameObject reticle;
    bool powerUp;
    Rect powerRect;
	void Start () {
		cam = Camera.main;
		//fireAngle = 45.0f;
		//firePower = minFirePower;
		reticle = GameObject.FindGameObjectWithTag("reticle");
        firing = false;
        powerUp = true;
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

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetAxisRaw("Fire") != 0.0f) 
		{
            if (!firing)
            {
                Vector3 pos = new Vector3(reticle.GetComponent<SocketClient>().xPos, reticle.GetComponent<SocketClient>().yPos, 0);
                firing = true;
            }
            else
            {
                Fire(pos);
                firing = false;
                Debug.Log("Power shot" + powerLevel);
            }
		}
        if (firing)
        {
            PowerStage();
            Debug.Log("Powering");
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
		_bulletholder.GetComponent<Rigidbody2D> ().AddRelativeForce (force * powerLevel, ForceMode2D.Impulse);

		//Vector2 dir = (Vector2)(Quaternion.Euler(0, 0, fireAngle) * Vector2.right);
		//Debug.Log(dir);

		//Vector2 force = dir * (firePower * fireForce);

		//_bulletholder.GetComponent<Rigidbody2D>().AddForce(force,ForceMode2D.Impulse);

		//firePower = minFirePower;
	}
    void PowerStage()
    {
        if (powerUp)
        {
            powerLevel = powerLevel + 1.5f * Time.deltaTime;
            //Debug.Log(barrel.transform.rotation.z);
            Debug.Log("power " + powerLevel);
            if (powerLevel > 10) { powerUp = false; }
        }
        else if (!powerUp)
        {
            powerLevel = powerLevel - 1.5f * Time.deltaTime;
            //arrel.transform.Rotate(-Vector3.forward * 10 * Time.deltaTime);
            Debug.Log("power down " + powerLevel);
            if (powerLevel < 0) { powerUp = true; }//if (barrel.transform.rotation.z <= 0) { powerUp = true; }
        }
        powerRect = new Rect(30, 30, 10 * powerLevel + 5, 40);
    }
    private void OnGUI()
    {
        GUI.color = Color.red;
        GUI.Box(powerRect, "Power level");
    }
}
