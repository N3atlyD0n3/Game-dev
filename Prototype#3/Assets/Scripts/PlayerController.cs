using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6;
    private float rotX;
    public float jumpforce;
    public float mouseSens = 5;

    public float maxLookX = -45;
    public float minLookX = 45;

    public float maxLookY = 0;
    public float minLookY = 0;


    private Camera cam;
    private Rigidbody rb;


    void Awake(){
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();

    }
    // Start is called before the first frame update
    void Update(){
        Move();
        CameraLook();
        if(Input.GetButton("Jump"))
            Jump();
    }
    void Move(){
        float X  = Input.GetAxis("Horizontal") * moveSpeed;
        float Z = Input.GetAxis("Vertical") * moveSpeed;
        //get current direction / face direciton of the camera
        Vector3 dir = transform.right * X + transform.forward * Z;
        //Jump direction
        dir.y = rb.velocity.y;
        //Move in the direction of the camera
        rb.velocity = dir;

    }
    void Jump(){
        Ray ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray,1.1f)){
            rb.AddForce(Vector3.up * jumpforce,ForceMode.Impulse);
        }
    }
    void CameraLook(){
        float Y = Input.GetAxis("Mouse X") * mouseSens;

        rotX += Input.GetAxis("Mouse Y") * mouseSens;
        //Clamp Camera
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        //Apply
        cam.transform.localRotation = Quaternion.Euler(-rotX,0,0);
        transform.eulerAngles += Vector3.up * Y;
    }
}