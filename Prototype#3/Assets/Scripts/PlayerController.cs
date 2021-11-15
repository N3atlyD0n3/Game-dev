using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Set header for stats
    [Header("Stats")]
    //Set Player speed
    public float moveSpeed = 6;
    //Set jump multiplyer
    public float jumpforce;
    //Set max and min HP
    public int curHP;
    public int maxHP;
    //Make header for settings
    [Header("Settings")]
    //Declare mouse x rotation
    private float rotX;
    //Set Mouse sensitivity
    public float mouseSens = 5;
    //Set max and min camera look
    public float maxLookX = -45;
    public float minLookX = 45;
    //Set Private cam
    private Camera cam;
    //Declate player rigidbody
    private Rigidbody rb;
    //Declare weapom
    private Weapon Weapon;
    private OddPill OddPill; 
    //Start
    void Awake(){
    //Set player camera to camera
    cam = Camera.main;
    //Get player rigidbody
    rb = GetComponent<Rigidbody>();
    //Get weapon
    Weapon = GetComponent<Weapon>();
    //get odd pill
    OddPill = GetComponent<OddPill>(); 
    //Hide cursor
    Cursor.lockState = CursorLockMode.Locked;
    }
    // Start is called before the first frame update
    void Update(){
    //Call Move function
    Move();
    //Call CameraLook Function
    CameraLook();
    //If space is pressed call jump function
    if(Input.GetButton("Jump"))
    Jump();
    //If mouse 1 button pressed fire weapon
    if(Input.GetButton("Fire1")){
    if(Weapon.CanShoot()){
    Weapon.Shoot();
            }
        }
    }
    void Move(){
    //Get player x and z axis and * by move speed
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
    //Check to see if player is on ground if so jump
    Ray ray = new Ray(transform.position, Vector3.down);
    if(Physics.Raycast(ray,1.1f)){
    rb.AddForce(Vector3.up * jumpforce,ForceMode.Impulse);
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
    public void TakeDamage(int damage){
        curHP -= damage; 
        if (curHP <= 0){
            Die();
        }
    }
    void Die(){
        print("You suck");
    }
    public void giveHealth(int amountToGive){
        curHP = Mathf.Clamp(curHP + amountToGive,0,maxHP);
    }
    public void giveAmmo(int amountToGive){
        Weapon.CurAmmo = Mathf.Clamp(Weapon.CurAmmo + amountToGive,0,Weapon.maxAmmo);
    }
}