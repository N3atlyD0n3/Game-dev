using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour {
	// Set mouse sensitivity
	public float mouseSensitivityX = 1;
	public float mouseSensitivityY = 1;
    // Set walk speed to 6
	public float walkSpeed = 6;
    // Set jump to power to 220
	public float jumpForce = 240.0f;
    //set gravity acceleration 
	public float gravityac = -9.8f;
	//set raycast length
	public float height;
	//set jump height
	public float jumpheight = 1.1f;
	//set private goundobject
	private GameObject groundObject; 
	//layer mask
	public LayerMask groundedMask;
	// Make ray cast var
	bool grounded;
	bool ableJump; 
    // Make move amount Var
	Vector3 moveAmount;
    // Make movement smooth
	Vector3 smoothMoveVelocity;
	//Make ground normal with vector 3
	Vector3 groundnormal;
    // Make Vertivle look Var
	float verticalLookRotation;
    // Set Camera
	Transform cameraTransform;
    // Set rigidbody
	public Rigidbody playerrigidbody;
    // Awake is simalar to start
	void Awake() {
        //Set Cursor to disappear when started
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
        // Set Camera to whatever camera is there
		cameraTransform = Camera.main.transform;
        // Set rigidbody = to rigidbody (more modern way)
		playerrigidbody = GetComponent<Rigidbody>();
	}
	// Start the updating sequence
	void Update() {
		// Look rotation:
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
		verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
		verticalLookRotation = Mathf.Clamp(verticalLookRotation,-60,60);
		cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;
		// Set movement to horizontal and vertical
		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");
		//Make ray for grounded and jump capability
		Ray ray = new Ray(transform.position, -transform.up);
		Ray JumpRay = new Ray(transform.position, -transform.up);
		//set hit var
		RaycastHit hit;
		//Draw ray on screen
		Debug.DrawRay(transform.position, -transform.up * height,Color.red);
		Debug.DrawRay(transform.position, -transform.up * jumpheight,Color.blue);
		//If ground ray hit gravity yes
		if (Physics.Raycast(ray, out hit, height, groundedMask)) {
			grounded = true;
			if(hit.rigidbody != null){
				groundObject = hit.transform.gameObject;
			}
				Vector3 gravDir = (transform.position - groundObject.transform.position).normalized;
				playerrigidbody.AddForce(hit.normal * gravityac);
				Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravDir) * transform.rotation;
				transform.rotation = toRotation;
			}
		else {
			grounded = false;
			Vector3 gravDir = (transform.position + groundObject.transform.position).normalized;
			//playerrigidbody.AddForce(hit.normal / gravityac);
			Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravDir) * transform.rotation;
			transform.rotation = toRotation;
		}
		//Able Jump ray
		if (Physics.Raycast(JumpRay, out hit, jumpheight, groundedMask)){
			ableJump = true;
		}
		else{
			ableJump = false; 
		}
		// If move buttons pressed move
		Vector3 moveDir = new Vector3(inputX,0, inputY).normalized;
		Vector3 targetMoveAmount = moveDir * walkSpeed;
		moveAmount = Vector3.SmoothDamp(moveAmount,targetMoveAmount,ref smoothMoveVelocity,.15f);
		// Jump
		if (Input.GetButtonDown("Jump")) {
			if (grounded == true) {
				if (ableJump == true){
				playerrigidbody.AddForce(transform.up * jumpForce);
				}
			}
		}
	}
	// Set fixed update to handle physics
	void FixedUpdate() {
		// Apply movement to rigidbody
		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		playerrigidbody.MovePosition(playerrigidbody.position + localMove);
		// if gravity is true print grounded
		if (grounded == true){
			print("Grounded");
			playerrigidbody.useGravity = false;
		//If gravity is false print grounded false
		}
		if (grounded == false){
			print("grounded false");
			playerrigidbody.useGravity = false;
		}
	}
}