using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Make Gamobject 
    public GameObject ProjectilePrefab;
    // Make Muzzle
    public Transform muzzle; 
    //Make public int for current ammo
    public int CurAmmo;
    //Make public int for max ammo
    public int maxAmmo;
    // Infinite Ammo yes
    public bool infiniteAmmo; 
    //Set the rate of the projectile 
    public float Rate;
    //Make Last time projectile shot
    private float lastShootTime;
    //Set public float for projectile speed
    public float projectileSpeed;
    // get player
    private bool isPlayer;
    // Awake is called before the first frame update
    void Awake()
    {
        //are we attached to the player
        if(GetComponent<PlayerController>()){
            isPlayer = true;
        }
    }
    // Make CanShoot function
    public bool CanShoot(){
        // If the time in game - the last time shot >= the rate of fire, if current ammo > 0 or infinite ammo is true, return false, if not all of that return false
        if(Time.time - lastShootTime >= Rate){
            if(CurAmmo > 0 || infiniteAmmo == true)
            return true;  
        }
        return false;
    }
    // Make Funciton to make projectile
    public void Shoot(){
        // Last shot is = time
        lastShootTime = Time.time;
        // Subtract from current ammo
        CurAmmo--;
        //Make a copy of the projectile and move it/
        GameObject projectile = Instantiate(ProjectilePrefab, muzzle.position, muzzle.rotation);
        projectile.GetComponent<Rigidbody>().velocity = muzzle.forward * projectileSpeed;
    }
}
