using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class MenuUI : MonoBehaviour
{
    //make function for the play button
    public void OnPlayButton(){
        SceneManager.LoadScene("Game");
    }
    //make function for the quit button
    public void OnQuitButton(){
        Application.Quit();
    }
}
