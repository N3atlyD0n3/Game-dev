using System.Collections;
using UnityEngine;
//[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour
{
    GravityAttract planet;
    Rigidbody rigidbody;

    void Awake() {
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttract>();
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void fixedUpdate(){
        //void OnTriggerEnter(Collider other){
            //if(other.CompareTag("Player")){
                        planet.Attract(rigidbody);
               // }
           // }
        }
    }
