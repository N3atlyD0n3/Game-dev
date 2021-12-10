using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   //score amount to win game
    public int scoretowin;
    //current score
    public int currentscore;
    //game faused true of false
    public bool gamePaused; 
    //Make instance of the script
    public static GameManager instance;
    // Start is called before the first frame update
    void Awake(){
        instance = this;
    }
    void Start() {
        
    }

    

    // Update is called once per frame
    void Update(){
        if(Input.GetButton("Cancel")){
            TogglePausedGame();
        }
    }
    public void TogglePausedGame(){
        gamePaused = !gamePaused;
        //time scale = gamepaused if it true time is 0 if not its 1 
        Time.timescale = gamePaused == true ? 0.0f : 1.0f;
        // toggle menu
        UserInterface.instance.TogglePause(gamePaused);  
    }
    public void AddScore(int score){
        currentscore += score; 
        //update score text
        UserInterface.instance.UpdateScore(currentscore);
        if(currentscore >= scoretowin){
            WinGame(); 
        } 

    }
    public void WinGame(){
        //set game screen
        UserInterface.instance.SetEndGameScreen(true,currentscore); 
    }
}
