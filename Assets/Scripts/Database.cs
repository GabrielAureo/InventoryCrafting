using UnityEngine;
using System.Collections.Generic;

public class Database: MonoBehaviour{
    public static Dictionary<string, Item> Items{ get; private set;}

    void Awake(){
        Initialize();
        DontDestroyOnLoad(this);
    }

    void Start(){
        printDictionary();
    }

    public void Initialize(){
        Items = new Dictionary<string, Item>(System.StringComparer.InvariantCultureIgnoreCase);
        Item[] itemsObj = Resources.LoadAll<Item>("Items");
        foreach(Item itemObj in itemsObj){
            Items.Add(itemObj.getID(), itemObj);
        }
    }

    public void printDictionary(){
        foreach(var kvp in Items){
            Debug.Log(kvp.Value.displayName + " is a " + kvp.Value.GetType().ToString());
        }
    }

    public static List<Item> RequestItems(string[] ids){
        List<Item> itemList = new List<Item>();
        foreach(string id in ids){
            Item temp;
            if(Items.TryGetValue(id, out temp)){
                itemList.Add(Object.Instantiate(temp));
            }
        }
        return itemList;
    }

}