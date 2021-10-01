using UnityEngine;
using System.Collections;

//[RequireComponent (typeof (GravityBody))]
public class PlayerController : MonoBehaviour {
	// Set mouse sensitivity
	public float mouseSensitivityX = 1;
	public float mouseSensitivityY = 1;
    // Set walk speed to 6
	public float walkSpeed = 6;
    // Set jump to power to 220
	public float jumpForce = 220;
    //
	public LayerMask groundedMask;
	// Make grounded Var
	bool grounded;
    // Make move amount Var
	Vector3 moveAmount;
    // Make movement smooth
	Vector3 smoothMoveVelocity;
    // Make Vertivle look Var
	float verticalLookRotation;
    // Set Camera
	Transform cameraTransform;
    // Set rigidbody
	Rigidbody rigidbody;
    // Awake is simalar to start
	void Awake() {
        //Set Cursor to disappear when started
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
        // Set Camera to whatever camera is there
		cameraTransform = Camera.main.transform;
        // Set rigidbody = to rigidbody (more modern way)
		rigidbody = GetComponent<Rigidbody> ();
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
		// If move buttons pressed move
		Vector3 moveDir = new Vector3(inputX,0, inputY).normalized;
		Vector3 targetMoveAmount = moveDir * walkSpeed;
		moveAmount = Vector3.SmoothDamp(moveAmount,targetMoveAmount,ref smoothMoveVelocity,.15f);
		// Jump
		if (Input.GetButtonDown("Jump")) {
			if (grounded) {
				GetComponent<Rigidbody>().AddForce(transform.up * jumpForce);
			}
		}
		// Check if your on the ground
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask)) {
			grounded = true;
		}
		else {
			grounded = false;
		}
	}
	// Set fixed update to handle physics
	void FixedUpdate() {
		// Apply movement to rigidbody
		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + localMove);
	}
}