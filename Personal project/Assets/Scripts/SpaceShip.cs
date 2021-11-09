using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    //set grounded mask
    public LayerMask groundedMask; 
    //setraycast length for gravity.
    public float height = 2.0f;
    //set private groundedobject
    private GameObject groundObject; 
    //set bool for grounded
    bool grounded; 
    //get rigid body.
    Rigidbody shipRigid;
    // Start is called before the first frame update
    void Start()
    {
        shipRigid = GetComponent<Rigidbody>();
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
    }
}
