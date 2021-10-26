using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletprefab;

    public Transform muzzle; 

    public int CurInt;

    public int maxInt;

    public bool infiniteInt; 

    public float speedInt;

    private float lastShootTime;

    public float projectileSpeed;

    private bool isPlayer;
    // Start is called before the first frame update
    void Awake()
    {
        //are we attached to the player
        if(GetComponent<PlayerController>()){
            isPlayer = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public bool CanShoot(){
        if(Time.time - lastShootTime >= speedInt){
            if(CurInt > 0 || infiniteInt == true){
                return true;
            }
        return false;
        }
    }
    public void Shoot(){
        lastShootTime = Time.time;
        CurInt--;
        GameObject projectile = Instatiate(projectilePrefab, muzzle.position, muzzle.rotation);
        projectile.GetComponent<Rigidbody>().velocity = muzzle.forward * projectileSpeed;


    }
}
