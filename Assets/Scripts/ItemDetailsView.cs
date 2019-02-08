using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemDetailsView : MonoBehaviour{
    [SerializeField]
    Item item;
    [SerializeField]
    TMP_Text itemName;
    [SerializeField]
    Image itemSprite;
    [SerializeField]
    TMP_Text weightField;
    [SerializeField]
    TMP_Text valueField;

    [SerializeField]
    TMP_InputField inputField;

    void Start(){
        if(item == null){
            HideView();
        }else{
            ReloadView();
        }
    }

    public void setItem(Item item){
        
        this.item = item;
        item.onNameChange += ReloadView;
        ReloadView();

    }

    public void RenameItem(string name){
        item.changeDisplayName(name);
        ReloadView();
    }
    public void ReloadView(){
        gameObject.SetActive(true);
        inputField.text = this.item.getDisplayName();
        weightField.text = this.item.weight.ToString();
        valueField.text = this.item.value.ToString();
        itemSprite.sprite = this.item.icon.icon;

    }

    public void HideView(){
        gameObject.SetActive(false);
    }


}