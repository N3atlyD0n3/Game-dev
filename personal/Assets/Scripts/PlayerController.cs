using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour {
	public GameObject Planet;
	public GameObject Player;

	public float speed = 4;
	public float JumpHeight = 2f;

	float gravity = 9.8f;
	bool Onground = false;

	public float mouseSens = 5;

	float distancetoGround;
	Vector3 GroundNormal;

	private float rotX;
	public float maxLookX = -45;
	public float minLookX = 45;

	private Camera cam;

	private Rigidbody rb;

	void Awake(){
		cam = Camera.main;
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
	}
	void Update(){
		

	
	}
	void Move(){
		float X = Input.GetAxis("Horizontal")  * speed;
		float Z = Input.GetAxis("Vertical")  * speed;
		Vector3 dir = transform.right * X + transform.forward * Z;
		dir.y = rb.velocity.y;
		rb.velocity = dir;
	}
	void Jumpe(){
		Ray ray = new Ray(transform.position, Vector3.down);
		if(Physics.Raycast(ray,1.1f)){
			rb.AddForce(Vector3.up * JumpHeight, ForceMode.Impulse);
		}
	}
    void CameraLook(){
    //Get mouse position x and y
    float Y = Input.GetAxis("Mouse X") * mouseSens;
    rotX += Input.GetAxis("Mouse Y") * mouseSens;
    //Clamp Camera
    rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
    //Apply clamp
    cam.transform.localRotation = Quaternion.Euler(-rotX,0,0);
    transform.eulerAngles += Vector3.up * Y;
    }
}