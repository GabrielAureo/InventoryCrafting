using UnityEngine;
[CreateAssetMenu(menuName = "Item/Weapon")]
public class Weapon: Item, ICraftable {
    [SerializeField]
    Item[] recipe;
    [SerializeField]
    private float baseDamage;
    [HideInInspector]
    private float addDamage;


    public float getDamage(){
        return addDamage + baseDamage;
    }

    public Item[] getRecipe()
    {
        return recipe;
    }

    public void increaseDamage(float amount){
        addDamage += amount;
    
    }

}