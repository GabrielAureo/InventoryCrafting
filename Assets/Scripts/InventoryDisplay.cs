using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class InventoryDisplay: MonoBehaviour{
    private Container targetInventory;
    private WeaponTab weaponSort;
    [SerializeField]
    private GameObject itemPrefab;
    [SerializeField]
    private Transform listContent;
    [SerializeField]
    InputField searchBar;
    SimpleObjectPool itemPool;




    public void setInventory(Container inventory){
        targetInventory = inventory;
        targetInventory.ItemAddition += addItem;
        targetInventory.ItemRemoval += removeItem;
        itemPool = new SimpleObjectPool(itemPrefab, listContent);

        for(int i = 0; i < targetInventory.items.Count; i++){
            var obj = itemPool.GetObject();
            var item = obj.GetComponent<MenuListItem>();
            searchBar.onValueChanged.AddListener(item.shouldFilter);
        }
    }

    private void addItem(IContainable item, int count){
        

    }

    private int removeItem(string name, int count){
        return 1;

    }

    private void SortList(){

    }



    
    
}

