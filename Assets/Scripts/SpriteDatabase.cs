using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
[System.Serializable]

[CreateAssetMenu(menuName = "Databases/Sprite Database")]
public class SpriteDatabase : ScriptableObject{
    [System.Serializable]
    public class SPRITE_DIC : SerializableDictionaryBase<string, Sprite>{}

    [SerializeField]
    public SPRITE_DIC data;
}