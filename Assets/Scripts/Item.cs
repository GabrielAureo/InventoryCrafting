using UnityEngine;
using System.Linq;
public abstract class Item: ScriptableObject, IContainable{
    private string idName;
    public string displayName;
    public Sprite icon;
    public float value;

    public float weight;

    public string getID(){
        return idName;
    }
    public virtual string getDisplayName(){
        return displayName;
    }

   


}