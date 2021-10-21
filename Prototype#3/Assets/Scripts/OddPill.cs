using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OddPill : MonoBehaviour
{
    public GameManager Gamemanager;
    public string pickUpName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            print(pickUpName + "aquired");
            Gamemanager.hasPill = true;
            Destroy(gameObject);
        }
    }
}
