using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;

public class InventoryDisplay{
    private Container targetInventory;
    //private List<IContainable> listDisplay;
    private TabFilter<IContainable> activeTab;
    private ItemTab itemSort;
    private WeaponTab weaponSort;


    public void setInventory(Container inventory){
        targetInventory = inventory;
        targetInventory.ItemAddition += addItem;
        targetInventory.ItemRemoval += removeItem; 
        activeTab = itemSort;
    }

    private void addItem(IContainable item, int count){
        

    }

    private int removeItem(string name, int count){
        return 1;

    }

    private void SortList(){

    }



    
    
}

