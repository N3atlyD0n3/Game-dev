using System.Collections;
using UnityEngine;
[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour
{
    GravityAttract planet;
    Rigidbody rigidbody;
    
    //public GameObject playerrigid;
    void Awake() {
        RigidBody player = gameObject.GetComponent(typeof(Rigidbody)) as RigidBody;
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttract>();
        RigidBody.useGravity = false;
        RigidBody.constraints = RigidbodyConstraints.FreezeRotation;
    }
    void FixedUpdate(){
        planet.Attract(RigidBody);
    }
}
