using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OddPill : MonoBehaviour
{
    public GameObject Gamemanager;
    public string hasPiLL;
    public string pickUpName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hasPiLL = GameManager.GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            print(pickUpName + "aquired");
            hasPiLL.hasPill = true;
            Destroy(gameObject);
        }
    }
}
