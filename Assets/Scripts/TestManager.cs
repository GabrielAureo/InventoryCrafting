using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class TestManager : MonoBehaviour{
    public string[] startingItems;
    public Container inventory;

    public GameObject display;

    [SerializeField]
    SaveMessage saveMessage;

    void Start(){
        Load();

        display.GetComponent<InventoryDisplay>().setInventory(ref inventory);
  
    }

    void Update(){
        if(InputManager.IsUIElementActive()) return;
        if(Input.GetKey(KeyCode.P)){
            string path = Path.Combine(Application.streamingAssetsPath, "data.json");
            //string data = JsonUtility.ToJson(testt);
            string data = JsonConvert.SerializeObject(inventory, Formatting.Indented);
            File.WriteAllText(path, data);
            saveMessage.onSave();
        }
    }

    void Load(){
        string path = Path.Combine(Application.streamingAssetsPath, "data.json");
        if(File.Exists(path)){
            string data = File.ReadAllText(path);
            
            //inventory = JsonUtility.FromJson<Container>(data);
            inventory = JsonConvert.DeserializeObject<Container>(data, new ItemCreationConverter());
        }else{
            inventory = new Container(startingItems);
        }
    }


}

public abstract class Test{
    public virtual string text(){
        return "this is an test";
    }
}

public class DTest : Test{
    public override string text(){
        return "this is an DTest";
    }
}

