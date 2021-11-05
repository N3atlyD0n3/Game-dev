using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
public class Enemy : MonoBehaviour{
    //set header for enemy stats
    [Header("Stats")]
    //set current hp
    public int currentHP;
    //set max hp 
    public int maxHP;
    
    //set header for movement
    [Header("Movement")]
    //set movespeed
    public float moveSpeed;
    //set enemy attack range
    public float attackRange;
    //Set path offset
    public float yPathOffset;
    //make private list to keep track of position
    private List<Vector3> path;
    //set enemy weapon
    private Weapon weapon;
    //set enemy target
    private GameObject target;
    // Start is called before the first frame update
    void Start(){
        //gather components
        //set health
        currentHP = maxHP;
        //set weapon
        weapon = GetComponent<Weapon>();
        //find player
        target = FindObjectOfType<PlayerController>().gameObject;
        //Create invoke, repeats at set interval. |method, start delay, delay between intervals| 
        InvokeRepeating("updatePath", 0.0f, 0.5f);
    }
    //Create update path function/method
    void updatePath(){
        //Calculate path to the set target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);
        //save path as list
        path = navMeshPath.corners.ToList();
    }
    //Create chase function/method
    void chaseTarget(){
        //if the path list is empty
        if(path.Count == 0){
            return;
        }
        //Move towards closest path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed * Time.deltaTime);

        if(transform.position == path[0] + new Vector3( 0, yPathOffset, 0)){
            path.RemoveAt(0);
        }
    }
    public void TakeDamage(int damage){
        currentHP -= damage;
        if(currentHP <= 0 ){
            Die();
        }
    }
    void Die(){
        Destroy(gameObject);
    }
    void Update(){
        //Look at target
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x,dir.z) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * angle; 
        //Get distance from enemy to target
        float dist = Vector3.Distance(transform.position, target.transform.position);
        //if weapon is able to fire fire
        if(dist <= attackRange){
            if(weapon.CanShoot()){
                weapon.Shoot();
            }
            else{
                chaseTarget();
            }
        }
    }
}
