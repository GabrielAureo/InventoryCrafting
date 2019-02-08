/* using UnityEngine;
[CreateAssetMenu(menuName = "Base Item")]
public class BaseItem: ScriptableObject{
    [SerializeField]
    private Item item;

    public Item getItem(){
        return item;
    }
    public string getDisplayName(){
        return item.getDisplayName();
    }

    
    public virtual Item Clone(){
        var clone = new Item();

        clone.displayName = item.displayName;
        clone.icon = item.icon;
        clone.value = item.value;
        clone.weight = item.weight;

        return clone;
    }
} */