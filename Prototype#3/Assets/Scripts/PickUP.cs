using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PickUpType{
    Health,
    Ammo,

    Points
}
public class PickUP : MonoBehaviour
{
    public PickUpType type;
    public int value; 
    [Header("Bobbing Head")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;
    private Vector3 StartPOS;
    private bool bobingUP;
    void Start(){
        //set the start position
        StartPOS = transform.position;
    }
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            PlayerController player = other.GetComponent<PlayerController>();
            switch(type){
                case PickUpType.Health:
                player.giveHealth(value);
                break; 

                case PickUpType.Ammo:
                player.giveAmmo(value);
                break;

                case PickUpType.Points:
                player.givepoints(value);
                break;
            }
            Destroy(gameObject); 
        }
    }
    void Update(){
        //rotate
        transform.Rotate(Vector3.up,rotationSpeed * Time.deltaTime);
        //Bobbing up and down
        Vector3 offset = (bobingUP == true ? new Vector3(0,bobHeight /2, 0): new Vector3(0,-bobHeight /2,0));
        transform.position = Vector3.MoveTowards(transform.position, StartPOS + offset, bobSpeed * Time.deltaTime); 
        if(transform.position == StartPOS + offset){
            bobingUP = !bobingUP; 
        }
    }
}
