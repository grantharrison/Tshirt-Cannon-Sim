// CannonController Script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour {

	// Rotation Variables
	public int speed;
	public float friction;
	public float lerpSpeed;
	float xDegrees;
	float yDegrees;
	Quaternion fromRotation;
	Quaternion toRotation;
	Camera camera;

	// Firing Variables
	public GameObject cannonBall;
	Rigidbody cannonballRB;
	public Transform shotPos;
	public GameObject explosion;
	public float firePower;
	public int powerMultiplier = 100;
    
    public InputField xCord;
    public InputField yCord;
    
    float xDegreeCord;
	float yDegreeCord;

	// Use this for initialization
    GameObject prefab;
	void Start() {
		camera = Camera.main;
		firePower *= powerMultiplier;
        prefab = Resources.Load("CannonBall") as GameObject;
	}
    
    public void setget() {
        
        xDegreeCord = float.Parse(xCord.text);
        yDegreeCord = float.Parse(yCord.text);
        
    }

	// Update is called once per frame
	void Update() {
		RaycastHit hit;
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit)) {
			if (hit.transform.gameObject.tag == "Cannon") {
//				xDegrees -= -(Input.GetAxis("Mouse Y") * speed * friction);
//				yDegrees += -(Input.GetAxis("Mouse X") * speed * friction);
//				fromRotation = transform.rotation;
//				toRotation = Quaternion.Euler(xDegrees, yDegrees, 0);
//				transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * lerpSpeed);
                xDegrees = -(xDegreeCord);
	            yDegrees = (yDegreeCord);
                transform.rotation = Quaternion.Euler(xDegrees, yDegrees, 0);
			}
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			FireCannon();
		}

	}

	public void FireCannon() {
		GameObject projectile = Instantiate(prefab, shotPos.position, transform.rotation) as GameObject;
            
        projectile.transform.position = transform.position+transform.forward * 2;
            
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 40;
        
	}
}