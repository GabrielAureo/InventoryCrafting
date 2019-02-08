using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;


[CreateAssetMenu(menuName="Databases/Items Databases")]
public class ItemDatabase : ScriptableObject{
    [System.Serializable]
    public class I_DB : SerializableDictionaryBase<string, Item>{}

    [SerializeField]
    public I_DB data; 

    public Item GetItem(string itemID){
        Item baseItem;
        data.TryGetValue(itemID, out baseItem);
        return baseItem;
    }

}