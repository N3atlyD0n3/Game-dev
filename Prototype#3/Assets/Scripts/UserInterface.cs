using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using UnityEngine.SceneManagement; 
public class UserInterface : MonoBehaviour
{   //Get player 
    [Header("Player UI")]
    //set text for ammo and score
    public Text ammoText;
    public Text Score;
    //Set image for healthbar
    public Image healthbarfill;
    //New header for pause menu 
    [Header("Pause Menu")]
    public GameObject pauseMenu;
    //New header for end game screen 
    [Header("End Screen")]
    public GameObject EndGameScreen; 
    public TextMeshProUGUI endGameHeadertext; 
    public TextMeshProUGUI endGameScoreText; 
    public static UserInterface instance;
    void Awake()
    {
        instance = this; 
    }
    void Start(){
    }
    // Update is called once per frame
    void Update()
    {   //get player current ammo and change text based off how much ammo
        //healthbar.transform.position = ;


    }
    public void Updatehealth(int curHP, int maxHP){
        healthbarfill.fillAmount = (float)curHP / (float)maxHP;
    }
    public void UpdateAmmo(int curAmmo,int maxAmmo){
        ammoText.text = "Ammo - " + curAmmo + "/" + maxAmmo;
    }
    public void SetEndGameScreen(bool won, int score){
        EndGameScreen.SetActive(true);
        endGameHeadertext.text = won == true ? "You Win, You have enough pills for diseasea..." : "You lose, no pills";
        endGameHeadertext.color = won == true ? Color.green : Color.red;
        endGameScoreText.text = "<b>Score</b>\n" + score; 
    }
    public void UpdateScore(int currentscore){
        Score.text = "Score - " + currentscore.ToString();
    }
    public void onResumeButton(){
        GameManager.instance.TogglePausedGame();
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
