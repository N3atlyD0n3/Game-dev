using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMechanics : MonoBehaviour
{
    readonly float g = 5f;
    //float radius = 5; 

    GameObject[] celestials;
    // Start is called before the first frame update
    void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestial");
        InitialVelocity();
    }
   private void FixedUpdate()
    {
        Gravity();
    }
    void Gravity()
    {
        foreach(GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (g * (m1 * m2) / (r * r)));
                }
            }
        }
    }
    void InitialVelocity()
    {
        foreach (GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    a.transform.LookAt(b.transform);
                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((g * m2) / r);
                }
              }
           }
        }
    }