using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotGun : InventorySlot
{
    public MainInventory inventory;
    public ItemGun itemGun;

    public ItemGun[] gunList;

    private void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<MainInventory>();
    }
    public override void AddItem(Item newItem)
    {
        if (newItem != null)
        {
            currentItem = newItem;
            icon.sprite = newItem.icon;
            Debug.Log(newItem.id);
            itemGun = gunList[newItem.id];//crutch cause idk how to make it straight
            inventory.UpdateWeapon(itemGun.gun);
        }
    }
}
