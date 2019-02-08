using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
using System.Collections.Generic;

[ExecuteAlways]
public class DatabaseManager: MonoBehaviour, ISerializationCallbackReceiver{
    public static SpriteDatabase spriteData{get; private set;}
    public static ItemDatabase itemsData{get; private set;}
    [SerializeField]
    private SpriteDatabase _spriteData;
    [SerializeField]
    private ItemDatabase _itemsData;

    void Awake(){
        spriteData = _spriteData;
        itemsData = _itemsData;
    }

    public void OnBeforeSerialize()
    {
        _spriteData = spriteData;
        _itemsData = itemsData;
    }   

    public void OnAfterDeserialize()
    {
        spriteData = _spriteData;
        itemsData = _itemsData;
    }
}

