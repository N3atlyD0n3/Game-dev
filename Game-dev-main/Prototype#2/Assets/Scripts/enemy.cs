using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour{
    // Start is called before the first frame update
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    void Start(){  
        rb = this.GetComponent<Rigidbody2D>();  
    }
    // Update is called once per frame
    void Update(){
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate(){
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    void onTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Projectile")){
            Destroy(gameObject);
        }
    }
}
