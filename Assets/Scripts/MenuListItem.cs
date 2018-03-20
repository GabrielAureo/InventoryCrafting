using UnityEngine;
public class MenuListItem : MonoBehaviour{
    private GameObject itemMenuInstance;
    private IContainable item;

    
    public void shouldFilter(string query){
        itemMenuInstance.SetActive(query != string.Empty && item.getDisplayName().Contains(query));
        
    }

    public void setIndex(int index){
        itemMenuInstance.transform.SetSiblingIndex(index);
    }

}