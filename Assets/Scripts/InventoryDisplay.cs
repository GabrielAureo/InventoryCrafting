using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class InventoryDisplay: MonoBehaviour{
    private Container targetInventory;
    private WeaponTab weaponSort;
    [SerializeField]
    private GameObject itemPrefab;
    [SerializeField]
    private Transform listContent;
    [SerializeField]
    TMP_InputField searchBar;
    [SerializeField]
    ItemDetailsView detailsView;
    SimpleObjectPool itemPool;

    public void setInventory(ref Container inventory){
        targetInventory = inventory;
        targetInventory.ItemAddition += addItem;
        targetInventory.ItemRemoval += removeItem;
        itemPool = new SimpleObjectPool(itemPrefab, listContent);

        for(int i = 0; i < targetInventory.items.Count; i++){
            var obj = itemPool.GetObject(listContent, false);
            var menuItem = obj.GetComponent<MenuListItem>();
            var itemRef = targetInventory.items[i];

            menuItem.Initialize(ref itemRef, new MenuListItemEvents(
                leftClickAction,rightClickAction,
                x => detailsView.setItem(x)
            ));
        }
    }

    private void leftClickAction(Item item){
        Debug.Log("Left Click on " + item.displayName);
        
    }

    private void hoverAction(Item item){
        detailsView.setItem(item);
    }

    private void rightClickAction(Item item){
        Debug.Log("Right Click on " + item.displayName);
    }

    public void openInventory(){
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, .3f);
        
    }

    public void closeInventory(){
        GetComponent<CanvasGroup>().DOFade(0, .3f).onComplete += () => gameObject.SetActive(false);
    }

    private void addItem(Item item, int count){
        
    }

    private void removeItem(string name, int count){

    }

    private void SortList(){
        listContent.DetachChildren();
    }



    
    
}

