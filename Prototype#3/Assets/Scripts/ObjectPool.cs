using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objPrefab;
    public int CreateOnStart; 
    private List<GameObject> pooledObjs = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < CreateOnStart; x ++ ){
            CreateNewObj();
        }
    }

    // creates new object then deactivates it  
    GameObject CreateNewObj(){
        GameObject obj = Instantiate(objPrefab);
        obj.SetActive(false);
        pooledObjs.Add(obj);
        return obj;
    }
    //Get the object
    public GameObject GetObject(){
        GameObject obj = pooledObjs.Find(x => x.activeInHierarchy == false);
        if(obj == null){
            obj = CreateNewObj();
        }
        obj.SetActive(true); 

        return obj;
    }
    void Update(){

    }
}
