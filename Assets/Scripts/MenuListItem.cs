using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MenuListItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler{
    [SerializeField]
    ItemDetailsView displayView;
    [SerializeField]
    private TextMeshProUGUI itemName;
    [SerializeField]
    private TextMeshProUGUI value;
    [SerializeField]
    private TextMeshProUGUI weight;

    private Item item;

    MenuListItemEvents events;


	public void Initialize(ref Item item, MenuListItemEvents events){
		this.events = events;
		setItem(ref item);
        item.onNameChange += ReloadView;

	}

    
    public void setItem(ref Item item){
        this.item = item;
        ReloadView();
    }

    private void ReloadView(){
        itemName.text = item.getDisplayName();
        value.text = item.value.ToString();
        weight.text = item.weight.ToString();
    }

    public void renameItem(string newName){
        item.displayName = newName;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
		if(eventData.button == PointerEventData.InputButton.Left){
			events.onLeftClick(item);
        }else if(eventData.button == PointerEventData.InputButton.Right){
			events.onRightClick(item);
		}
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        events.onHoverEnter(item);
    }
}
