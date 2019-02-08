using UnityEngine;
using System;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Item/Item")]
[Serializable]
public class Item : ScriptableObject, IContainable{
    string idName;
    public string displayName = "";
    public ItemSprite icon;
    public float value = 0.0f;
    public float weight = 0.0f;

    [NonSerialized]
    public UnityAction onNameChange;

    public string getID(){
        return idName;
    }
    public virtual string getDisplayName(){
        return displayName;
    }
    public void changeDisplayName(string newName){
        displayName = newName;
        onNameChange();
    }

}

