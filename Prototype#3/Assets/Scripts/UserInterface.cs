using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{   //Get player controller
    public GameObject Player;

    public GameObject gamem;
    //set text
    public Text ammoText;
    //Get score
    public Text Score;
    //Get health bar
    public Image healthbar;
    // Start is called before the first frame update
    private float currentammo;
    private Weapon curammo;
    private float currenthp;

    private GameManager currentpoints; 
    private float points;
    private PlayerController curhealth;
    void Start()
    {
    //get player script
    curammo = Player.GetComponent<Weapon>();
    currentpoints = gamem.GetComponent<GameManager>(); 
    curhealth = Player.GetComponent<PlayerController>();
    
    }

    // Update is called once per frame
    void Update()
    {   //get player current ammo and change text based off how much ammo
        currentammo = curammo.CurAmmo;
        ammoText.text = "Ammo - " + currentammo.ToString();
        //Current points
        points = currentpoints.points; 
        Score.text = "Score - " + points.ToString();
        //get player current health and change text based off how much ammo
        currenthp = curhealth.curHP;

        //healthbar.transform.position = ; 
    }
}
