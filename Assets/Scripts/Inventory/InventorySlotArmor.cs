using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventorySlotArmor : InventorySlot
{
    public ArmorSystem armorSystem;
    public ItemArmor itemArmor;

    public ItemArmor[] armorList;

    private void Start()
    {
        armorSystem= GameObject.Find("Player").GetComponent<ArmorSystem>();
    }
    public override void AddItem(Item newItem)
    {
        if (newItem != null)
        {
            currentItem = newItem;
            icon.sprite = newItem.icon;
            //itemArmor = newItem.GetComponent<ItemArmor>();
            itemArmor = armorList[newItem.id];//crutch cause idk how to make it straight
            armorSystem.UpdateTotalArmor();
        }
    }
}
