using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameManager gameManager;
    public string pickUpName;
    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Player")){
            print("You Picked Up"+ amount + pickUpName);
            gameManager.hasKey = true;
            Destroy(gameObject);
        }
    }
}
