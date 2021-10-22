using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Set speed of porjectile to 2
    public float speed = 2.0f;
    //
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        // Move projectile
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        //
    }
}
