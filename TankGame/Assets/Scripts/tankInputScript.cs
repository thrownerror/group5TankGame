using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankInputScript : MonoBehaviour {
    bool stageChange = false;
    int stageCount = 2;
    public GameObject barrel;
    bool rotateUp;
    bool powerUp;
    float powerLevel = 0.0f;
    bool inputChange;
    bool triggerInUse;
	Camera cam;
	Vector3 mousePos;
    // Use this for initialization
    void Start() {
        rotateUp = true;
        inputChange = false;
		cam = Camera.main;
    }

    // Update is called once per frame
    void Update() {

		mousePos = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
		Debug.Log (mousePos.x);
        //Debug.Log(Input.GetAxis("Fire"));
		if (Input.GetAxisRaw("Fire") != 0.0f ||  Input.GetMouseButtonDown(0))
        {
            triggerInUse = true;
            //  Debug.Log("test");
        }
		if (Input.GetAxisRaw("Fire") == 0.0f || Input.GetMouseButtonUp(0))
        {
            triggerInUse = false;
            //    Debug.Log("other test");
        }
        if (triggerInUse)
        {
            if (!stageChange && !inputChange)
            {
                stageChange = true;
            }
            if (stageChange)
            {
                if (stageCount != 2) { stageCount++; }
                else { stageCount = 0; }
                print("here");
                stageChange = false;
                //   inputChange = true;
            }
        }
        //if (inputChange)
        //{
        if (!triggerInUse)
        {
            if (stageCount == 0)
            {
                //   Debug.Log("Angle");
              //  rotateUp = true;
                AngleStage();
            }
            else if (stageCount == 1)
            {
            //    powerLevel = 0.0f;
                PowerStage();
             //   Debug.Log("Power");
            }
            else if (stageCount == 2)
            {
               // Debug.Log("error");
               //wait
            }
            inputChange = false;
        }
    }

    void AngleStage()
    {
        if (rotateUp)
        {
            barrel.transform.Rotate(Vector3.forward * 10 * Time.deltaTime);
            Debug.Log(barrel.transform.rotation.z);
            if (barrel.transform.rotation.z >= .69)
            { rotateUp = false; }
        }
        else if (!rotateUp)
        {
            barrel.transform.Rotate(-Vector3.forward * 10 * Time.deltaTime);
            Debug.Log(barrel.transform.rotation.z);
            if (barrel.transform.rotation.z <= 0) { rotateUp = true; }
        }
    }
    void PowerStage()
    {
        if (powerUp)
        {
            powerLevel = powerLevel + 2 * Time.deltaTime;
            //Debug.Log(barrel.transform.rotation.z);
            Debug.Log("power");
            if (powerLevel > 100) { powerUp = false; }
        }
        else if (!powerUp)
        {
            powerLevel = powerLevel + 2 * Time.deltaTime;
            //arrel.transform.Rotate(-Vector3.forward * 10 * Time.deltaTime);
            Debug.Log("power");
            if (powerLevel < 0) { powerUp = true; }//if (barrel.transform.rotation.z <= 0) { powerUp = true; }
        }
    }
}
