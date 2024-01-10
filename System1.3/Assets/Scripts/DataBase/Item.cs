using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "DataBase/CreateItem")]
public class Item : ScriptableObject
{
    public Type itemType;               //種類
    public String itemName;             //名前
    public Sprite itemSprite;           //画像
    public int itemResilience;          //回復力

    public enum Type
    {
        SmallHealingPotion,
        MediumHealingPotion,
        LargeHealingPotion,
    }

    public Item(Item item)
    {
        this.itemType = item.itemType;
        this.itemName = item.itemName;
        this.itemSprite = item.itemSprite;
        this.itemResilience = item.itemResilience;
    }
}