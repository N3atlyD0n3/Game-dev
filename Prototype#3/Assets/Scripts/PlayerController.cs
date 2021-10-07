using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6;

    public float mouseSens = 5;

    public float maxLookX = -45;
    public float minLookX = 45;

    public float maxLookY = -45;
    public float minLookY = 45;

    private Camera cam;
    private Rigidbody rb;


    void Awake(){
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();

    }
    // Start is called before the first frame update
    void Start(){
        
    }
    // Update is called once per frame
    void Update(){
        Move();
    }
    void Move(){
        float X  = Input.GetAxis("Horizontal") * moveSpeed;
        float Z = Input.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector3(X,rb.velocity.y,Z);

    }
    void CameraLook(){
        float Y = Input.GetAxis("Mouse X") * mouseSens;

        rotX = Input.GetAxis("Mouse Y") * mouseSens;
        //Clamp Camera
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        
        //Apply Clamp
        cam.transform.localRotation = Quaternion.Euler(-rotX,0,0);
        transfor.eulerAngles += Vector3.Up + Y;
    }
}
