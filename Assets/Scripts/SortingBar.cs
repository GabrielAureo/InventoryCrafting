using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SortingBar: MonoBehaviour{
    [SerializeField]
    Image orderIcon;
    [SerializeField]
    TextMeshProUGUI nameLabel;
    [SerializeField]
    GameObject valuePrefab;
    

    void Awake(){
        if(!orderIcon){
            orderIcon = transform.Find("ORDER_ICON").GetComponent<Image>();
        }
        if(!nameLabel){
            nameLabel = transform.Find("NAME_BTN").GetComponent<TextMeshProUGUI>();
        }
        
        
    }

    public void setSortingBar(){

    }

}