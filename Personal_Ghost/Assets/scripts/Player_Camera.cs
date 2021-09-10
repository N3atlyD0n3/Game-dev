using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_Camera : MonoBehaviour
{
    public GameObject capsule;
    private Vector3 offset = new Vector3(1,2,3);
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //set camera position to the player position
        transform.position = capsule.transform.position + offset; 
        transform.rotation = capsule.transform.rotation; 
    }
}