using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Behavoir : MonoBehaviour
{
    //set max y and x range player can move
    public float xRange = 10.025f;
    public float yRange = 4.49f; 
    // Update is called once per frame
    void Update()
    {
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
