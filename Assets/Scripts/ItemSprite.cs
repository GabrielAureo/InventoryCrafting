using UnityEngine;
using Newtonsoft.Json;

[JsonConverter(typeof(ItemSpriteConverter))]
[System.Serializable]
public class ItemSprite{
    [SerializeField]
    public string id;
    [JsonIgnore]
    [SerializeField]
    public Sprite icon;

}