using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{// Start is called before the first frame update
    void Start(){    
    }
    // Update is called once per frame
    void Update(){
    }
    void onTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Projectile")){
            Destroy(gameObject);
        }
    }
}
