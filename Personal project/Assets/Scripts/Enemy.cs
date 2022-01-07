using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
public class Enemy : MonoBehaviour
{
    [Header("Settings")]
	public float moveSpeed = 6;
    //set path offset
    public float yPathOffset;
    private List<Vector3> path; 
    private GameObject target;
	//set gravity acceleration 
	public float gravityac = -9.8f;
	//set raycast length
	public float height;
	//set private goundobject
	private GameObject groundObject;
	//layer mask
	public LayerMask groundedMask;
	// Make ray cast var
	bool grounded;
	bool ableJump;
	bool abletoEnter;
	[Header("Stats")]
    public int currentHP;
    public int maxHP;
    public int scoretogive;
    public float attackRange;
	//GameObject[] celestials;
	// Make move amount Var
	Vector3 moveAmount;
	// Make movement smooth
	Vector3 smoothMoveVelocity;
	//Make ground normal with vector 3
	Vector3 groundnormal;
	// 
    private Weapon weapon; 
	// Set rigidbody
	Rigidbody rb;
	//
	// Awake is simalar to start
	void Awake()
	{
		// Set rigidbody = to rigidbody (more modern way)
		rb = GetComponent<Rigidbody>();
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;
        InvokeRepeating("updatePath", 0.0f, 0.5f);
	}
    void updatePath(){
        //Calculate path to the set target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);
        //save path as list
        path = navMeshPath.corners.ToList();
    }
    void chaseTarget(){
        //testing new method for chasing target
        //Vector3 Direction = target.transform.position - transform.position;
        //rb.MovePosition((Vector3)transform.position + (Direction * moveSpeed * Time.deltaTime)); 
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
        GameManager.instance.AddScore(scoretogive);
        Destroy(gameObject);

    }
	// Start the updating sequence
	void Update()
	{

		//Make the rays 
		Ray Gravyray = new Ray(transform.position, -transform.up);
		Ray JumpRay = new Ray(transform.position, -transform.up);
		Ray EnterShip = new Ray(transform.position, transform.forward);
		//Set raycast hit called hit
		RaycastHit hit;
		//Draw ray on screen
		Debug.DrawRay(transform.position, -transform.up * height,Color.red);
		Debug.DrawRay(transform.position, -transform.up * 5,Color.blue);
		Debug.DrawRay(transform.position, transform.forward * 5);
		//
		//If ground ray hit gravity yes
		//
		if (Physics.Raycast(Gravyray, out hit, height, groundedMask)) {
			grounded = true;
			if(hit.rigidbody != null){
				groundObject = hit.transform.gameObject;
			}
				Vector3 gravDir = (transform.position - groundObject.transform.position).normalized;
				rb.AddForce(hit.normal * gravityac);
				Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravDir) * transform.rotation;
				transform.rotation = toRotation;
			}
			else {
			 grounded = false;
			}
		// If move buttons pressed move
		//Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
		//Vector3 targetMoveAmount = moveDir * walkSpeed;
		//moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

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
	// Set fixed update to handle physics 
	void FixedUpdate()
	{

	}
}
