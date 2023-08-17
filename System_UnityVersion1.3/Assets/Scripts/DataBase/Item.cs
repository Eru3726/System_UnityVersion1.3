using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "DataBase/CreateItem")]
public class Item : ScriptableObject
{
    public Type itemType;               //Ží—Þ
    public String itemName;             //–¼‘O
    public Sprite itemSprite;           //‰æ‘œ
    public int itemResilience;          //‰ñ•œ—Í

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