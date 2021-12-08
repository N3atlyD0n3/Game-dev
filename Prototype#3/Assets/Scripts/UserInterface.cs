using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using UnityEngine.SceneManagement; 
public class UserInterface : MonoBehaviour
{   //Get player 
    public GameObject Player;
    [Header("Player UI")]
    //set text for ammo and score
    public Text ammoText;
    public Text Score;
    //Set image for healthbar
    public Image healthbarfill;
    //Set ammo, hp , and score as private
    private float currentammo;
    private float maxammo;
    private int points; 
    private int currenthp;
    private int maxhp;
    //Get current ammo, current hp, and current points from player script and weapon script
    private Weapon curammo;
    private PlayerController curhealth;
  
    private PlayerController currentpoints;

    //New header for pause menu 
    [Header("Pause Menu")]
    public GameObject pauseMenu;
    //New header for end game screen 
    [Header("End Screen")]
    public GameObject EndGameScreen; 
    public TextMeshProUGUI endGameHeadertext; 
    public TextMeshProUGUI endGameScoreText; 
    void Awake()
    {
    //get player script
    curammo = Player.GetComponent<Weapon>();
    currentpoints = Player.GetComponent<PlayerController>(); 
    curhealth = Player.GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {   //get player current ammo and change text based off how much ammo
        currentammo = curammo.CurAmmo;
        maxammo = curammo.maxAmmo; 
        ammoText.text = "Ammo - " + currentammo + "/" + maxammo;
        //Current points
        points = currentpoints.curpoints; 
        Score.text = "Score - " + points.ToString();
        //get player current health and change text based off how much ammo
        currenthp = curhealth.curHP;
        maxhp = curhealth.maxHP;
        //healthbar.transform.position = ;
        updatehealth(currenthp,maxhp);
        TogglePause();
        SetEndGameScreen();

    }
    void updatehealth(int curHP, int maxHP){
        healthbarfill.fillAmount = (float)curHP / (float)maxHP;
    }
    public void SetEndGameScreen(bool won, int score){
        EndGameScreen.SetActive(true);
        endGameHeadertext.text = won == true ? "You Win, You have enough polls for diseasea..." : "You lose, no polls";
        endGameHeadertext.text = won == true ? Color.green : Color.red;
        endGameScoreText.text = "<b>Score</b>\n" + score; 
    }
    public void onResumeButton(){

    }
    public void onRestartButton(){
        SceneManager.LoadScene("Game");
    }
    public void OnMenuButton(){
        SceneManager.LoadScene("menu");
    }
    public void TogglePause(bool paused){
        pauseMenu.SetActive(paused);
    }
}
