using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Camera_Follow : MonoBehaviour
{
    public GameObject tank;
    private Vector3 offset = new Vector3(0,5,-12);
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //set camera position to the player position
        transform.position = tank.transform.position + offset; 
        //transform.rotation = tank.transform.rotation; 
    }
}
