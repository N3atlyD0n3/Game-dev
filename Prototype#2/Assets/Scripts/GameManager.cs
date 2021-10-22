using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasKey;
    public bool isdoorLocked;
    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        isdoorLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasKey && !isdoorLocked){
            print("Door unlocked");
            
        }
    }
}
