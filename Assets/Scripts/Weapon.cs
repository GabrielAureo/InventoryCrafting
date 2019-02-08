using UnityEngine;
[CreateAssetMenu(menuName = "Item/Weapon")]
public class Weapon: Item, ICraftable {
    [SerializeField]
    private Item[] recipe;
    [SerializeField]
    private float damage;


    public float getDamage(){
        return damage;
    }

    public Item[] getRecipe()
    {
        return recipe;
    }

    public void increaseDamage(float amount){
        damage += amount;
    
    }

}