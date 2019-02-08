using UnityEngine;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;

public class ItemSpriteConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(ItemSprite);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var itemSprite = new ItemSprite();
        JObject obj = JObject.Load(reader);
        JToken token;
        
        obj.TryGetValue("id", out token);
        string key = token.ToString();
        Sprite sprite;
        DatabaseManager.spriteData.data.TryGetValue(key, out sprite);

        itemSprite.id = key;
        itemSprite.icon = sprite;

        return itemSprite;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var itemSprite = value as ItemSprite;
        writer.WriteStartObject();
        writer.WritePropertyName("id");
        serializer.Serialize(writer, itemSprite.id);
        writer.WriteEndObject();

    }
}