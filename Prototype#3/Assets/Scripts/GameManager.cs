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
        //reset time
        Time.timeScale = 1.0f;
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
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;
        // toggle menu
        UserInterface.instance.TogglePause(gamePaused);
        //toggle mouse cursor
        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
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
    //make lose game function
    public void LoseGame(){
        //set end game screen
        UserInterface.instance.SetEndGameScreen(false,currentscore);
        Time.timeScale = 0.0f;
        gamePaused = true; 
    }
}
