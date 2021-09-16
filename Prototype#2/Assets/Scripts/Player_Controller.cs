using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed = 15.0f;
    public float turnSpeed = 15.0f;
    private float hInput;
    private float vInput;
    // Update is called once per frame
    void Update()
    {
        //Sets variable Hinput and vInput to unitys controlls
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        // Makes Player Character rotate left and right
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime * vInput);
        //Makes Player Character Move Forward and Backward
        transform.Translate(Vector3.forward * speed * Time.deltaTime * hInput);
    }
}
