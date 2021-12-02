using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{   //Get player controller
    public GameObject Player;
    //set text
    public Text ammoText;
    // Start is called before the first frame update
    private float currentammo;
    private Weapon curammo;
    private float currenthp;
    void Start()
    {
    //get player script
    curammo = Player.GetComponent<Weapon>();
    curhealth = Player.curHP;
    
    }

    // Update is called once per frame
    void Update()
    {   //get player current ammo and change text based off how much ammo
        currentammo = curammo.CurAmmo;
        ammoText.text = "Ammo - " + currentammo.ToString();
        //get player current health and change text based off how much ammo
        currenthp = curhealth;
        
    }
}
