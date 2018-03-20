using UnityEngine;
using System.Collections.Generic;

public class TestManager : MonoBehaviour{
    public string[] startingItems;
    public Container inventory;



    void Start(){
        inventory = new Container(startingItems);
  
    }

    void Update(){
        if(Input.GetKey(KeyCode.W)){
            Weapon veras = (Weapon)inventory.items[3];
            veras.displayName = "eae";
        }
    }


}