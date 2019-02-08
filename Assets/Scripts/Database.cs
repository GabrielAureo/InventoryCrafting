using UnityEngine;
using System.Collections.Generic;

public class Database: MonoBehaviour{
    public static Dictionary<string, Item> Items{ get; private set;}
    public ItemDatabase DB;

    void Awake(){
        Initialize();
        DontDestroyOnLoad(this);
    }

    void Start(){
        printDictionary();
    }

    public void Initialize(){
        Items = DB.data.Clone();
        /*/Items = new Dictionary<string, BaseItem>(System.StringComparer.InvariantCultureIgnoreCase);
        BaseItem[] itemsObj = Resources.LoadAll<BaseItem>("Items");
        foreach(BaseItem itemObj in itemsObj){
            Items.Add(itemObj.getID(), itemObj);
        }*/
        printDictionary();
    }

    public void printDictionary(){
        foreach(var kvp in Items){
            Debug.Log(kvp.Value.getDisplayName() + " is a " + kvp.Value.GetType().ToString());
        }
    }


    public static List<Item> RequestItems(string[] ids){
        List<Item> itemList = new List<Item>();
        foreach(string id in ids){
            Item temp;
            if(Items.TryGetValue(id, out temp)){
                itemList.Add(ScriptableObject.Instantiate(temp));
            }
        }
        return itemList;
    }

}