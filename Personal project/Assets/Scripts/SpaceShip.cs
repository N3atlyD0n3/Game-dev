using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeforwardSpeed, activestrafeSpeed, activehoverSpeed; 
    //set grounded mask
    public LayerMask groundedMask; 
    //setraycast length for gravity.
    public float height = 2.0f;
    //set private groundedobject
    private GameObject groundObject; 
    //set bool for grounded
    bool grounded; 
    //set bool for if your in the ship 
    bool inShip; 
    //get rigid body.
    Rigidbody shipRigid;
    //get player script
    private GameObject PlayerController; 
    // Start is called before the first frame update
    void Start()
    {
        shipRigid = GetComponent<Rigidbody>();
        PlayerController = FindObjectOfType<PlayerController>().gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        Ray GravyRay = new Ray(transform.position,-transform.up);
        RaycastHit hit;
        if (Physics.Raycast(GravyRay, out hit, height, groundedMask)){
            grounded = true;
            if(hit.rigidbody != null){
                groundObject = hit.transform.gameObject;
            }
            Vector3 gravDir = (transform.position - groundObject.transform.position).normalized;
            shipRigid.AddForce(hit.normal * -9.8f);
            Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravDir) * transform.rotation;
            transform.rotation = toRotation; 
        }
        else{
            grounded = false; 
        }
        //if your in the ship
        //if (abletoEnter = true){
        //set ship controls 
        //activeforwardSpeed = Input.GetAxisRaw("Vertical") * forwardSpeed;
        //activestrafeSpeed = Input.GetAxisRaw("Horizontal") * strafeSpeed;
        //activehoverSpeed = Input.GetAxisRaw("Hover") * hoverSpeed; 
        //ship movement
        //transform.position += transform.forward * activeforwardSpeed * Time.deltaTime; 
        //transform.position += transform.right * activestrafeSpeed * Time.deltaTime; 
        //transform.position += transform.up * activehoverSpeed * Time.deltaTime; 
        //}
    }
}
