using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasPill;
    private int points;
    // Start is called before the first frame update
    void Start()
    {
        hasPill = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasPill){
            print("Picked up");
            points += 1; 
        }
    }
    //void OnGUI(){
      //  GUILayout.Label("Points =" , points);
    //}
}
