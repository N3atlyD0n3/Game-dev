using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    //set player speed and turn speed
    public float speed = 40.0f;
    public float turnSpeed = 200f;
    //set player input 
    private float hInput;
    private float vInput;
    //set max y and x range player can move
    public float xRange = 10.025f;
    public float yRange = 4.49f; 
    // Update is called once per frame
    void Update()
    {
        //Sets variable Hinput and vInput to unitys controlls
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        // Makes Player Character rotate left and right
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime * hInput);
        //Makes Player Character Move Forward and Backward
        transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);
        //if player is past max range for x or y it stops the player
            // X
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
            // Y
        if(transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
        if(transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }

    }
}
