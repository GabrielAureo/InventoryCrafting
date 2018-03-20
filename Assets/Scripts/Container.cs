using System.Linq;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class Container{
    public List<Item> items;

    public delegate void ItemAdditionHandler(Item item, int count);
    public delegate void ItemRemovalHandler(string itemName, int count);

    public event ItemAdditionHandler ItemAddition;
    public event ItemRemovalHandler ItemRemoval;
    public Container(List<Item> items){
        this.items = items;
    }
    public Container(params string[] items){
        var list = Database.RequestItems(items).ToList();
        this.items = list;
    }

    public void addItem(Item item, int count){
        var itemClone = Object.Instantiate(item);
        for (int i =0; i < count; i++){
            items.Add(itemClone);
        }
        ItemAddition(itemClone, count);
    }

    public int removeItem(string itemName, int count){
        int removeCount = 0;

        foreach(var item in items){
            if(item.getID().Equals(itemName, System.StringComparison.CurrentCultureIgnoreCase)){
                items.Remove(item);
                removeCount++;
            }
        }
        ItemRemoval(itemName, removeCount);

  
        return removeCount;
        
    }


}
