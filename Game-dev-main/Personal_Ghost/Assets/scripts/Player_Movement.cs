using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_Movement : MonoBehaviour
{       
    private float speed = 25.0f; 
    private float turn_speed = 25.0f;
    private float hInput;
    private float vInput;
    // Start is called before the first frame update
    void Start()
    {
   
    }
    // Update is called once per frame
    void Update()
    {
        //Get horivontal and Vertical input from unity
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        //Moves Tank forward and back
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vInput);
        //Move Tank right and left
        transform.Rotate(Vector3.up, turn_speed * hInput * Time.deltaTime);

    }
}
