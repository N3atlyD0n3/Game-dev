using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaceHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject planet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    transform.position = Vector3.Lerp(transform.position, Player.transform.position, 0.1f);
    Vector3 gravDir = (transform.position - planet.transform.position).normalized;
    Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravDir) * transform.rotation;
    transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 0.1f);
    }
    public void NewPlanet(GameObject newPlanet){
        planet = newPlanet;
    }
}
