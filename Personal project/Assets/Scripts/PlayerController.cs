using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour {
	// Set mouse sensitivity
	public float mouseSensitivityX = 1;
	public float mouseSensitivityY = 1;
    // Set walk speed to 6
	public float walkSpeed = 6;
    // Set jump to power to 220
	public float jumpForce = 220;
    //
	public float gravityac = -9.8f;
	
	public GameObject planet;
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
	Rigidbody playerrigidbody;
    // Awake is simalar to start
	void Awake() {
        //Set Cursor to disappear when started
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
        // Set Camera to whatever camera is there
		cameraTransform = Camera.main.transform;
        // Set rigidbody = to rigidbody (more modern way)
		playerrigidbody = GetComponent<Rigidbody> ();
		//get planet rigidbody
		planet = CompareTag("Planet");
		planetRigid = planet.GetComponent<Rigidbody>();
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
				playerrigidbody.AddForce(transform.up * jumpForce);
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
		playerrigidbody.MovePosition(playerrigidbody.position + localMove);
		// use raycast for gravity
		Ray gravray = new Ray(transform.position, Vector3.forward);
        if (Physics.Raycast(gravray,10.1f)){
			Gravity();
            
        }
	}
	void Gravity(){
		playerrigidbody.useGravity = false;
        //playerrigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        //Vector3 gravityUp = (playerrigidbody.position - transform.position).normalized;
        //Vector3 localUp = playerrigidbody.transform.up;
        //playerrigidbody.rotation = Quaternion.FromToRotation(localUp, gravityUp) * playerrigidbody.rotation;
        //playerrigidbody.AddForce((planetRigid.position - transform.position).normalized * gravityac);
		// rigidbody.AddForce((planet.position - transform.position).normalized * acceleration);
	}
}