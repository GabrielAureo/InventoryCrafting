using UnityEngine;
using Newtonsoft.Json.Converters;
using System;

//Classe necessária para que os Items seja criados por CreateInstance, em vez do construtor
//Não parece que há outra necessidade disso além de suprimir um zilhão de erros que a Unity lança
//pra cada objecto derivado de ScriptableObject criado através de construtor.
public class ItemCreationConverter : CustomCreationConverter<Item>
{
    public override Item Create(Type objectType)
    {
        Item item = ScriptableObject.CreateInstance(typeof(Item)) as Item;
        Sprite sp;
        return item;
    }
}