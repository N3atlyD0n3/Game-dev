using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Set damage var
    public int damage;
    //Set var for how long projectile lives for
    public float LifeTime;
    //Set var for shootime
    private float shootTime;
    public GameObject hitParticle; 
    void onEnable(){
        shootTime = Time.time;
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    void OnTriggerEnter(Collider other){
        //Did we hit target
        if (other.CompareTag("Player")){
            other.GetComponent<PlayerController>().TakeDamage(damage);
        }
        else{
            if(other.CompareTag("Enemy"))
            other.GetComponent<Enemy>().TakeDamage(damage);
            //disable projectile
        gameObject.SetActive(false);
        //create particle affect
        GameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
        //destroys particle with 0.5 delay
        Destroy(obj,1.0f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Check to see how long life has been
        if (Time.time - shootTime >= LifeTime){
            gameObject.SetActive(false);

        }
    }
}