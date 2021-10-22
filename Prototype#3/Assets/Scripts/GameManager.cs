using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasPill;
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
        }
    }
}
