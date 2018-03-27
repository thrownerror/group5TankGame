using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {
    
    // min power to fire at (can be 0)
    public float minFirePower;

    // max angle
    float maxFireAngle = 180.0f;
    // min angle
    float minFireAngle = 0.0f;

    // force to fire at
    public float fireForce;

    //
    float fireAngle;
    float firePower;

    public GameObject bullet;

	// Use this for initialization
	void Start () {
        fireAngle = 45.0f;
        firePower = minFirePower;
	}
	
	// Update is called once per frame
	void Update () {

        // hold down to fire
        if (Input.GetKey(KeyCode.Space))
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
        }

        // aim right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.W))
        {
            if (fireAngle > minFireAngle)
            {
                fireAngle -= 0.1f;
            }
        }

        // aim left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (fireAngle < maxFireAngle)
            {
                fireAngle += 0.1f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Fire();
        }

	}

    void Fire()
    {
        GameObject b = Instantiate(bullet);

        b.GetComponent<Bullet>().owner = this.gameObject;

        b.transform.position = this.transform.position;

        Vector2 dir = (Vector2)(Quaternion.Euler(0, 0, fireAngle) * Vector2.right);
        Debug.Log(dir);

        Vector2 force = dir * (firePower * fireForce);

        b.GetComponent<Rigidbody2D>().AddForce(force,ForceMode2D.Impulse);

        firePower = minFirePower;
    }
}
