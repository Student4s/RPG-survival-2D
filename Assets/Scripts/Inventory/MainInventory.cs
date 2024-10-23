using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInventory : MonoBehaviour
{
    public List<InventorySlot> slots;
    public List<Weapon> weapons;
    [SerializeField] private PlayerShootComponent shootComponent;

    public int[] currentAmmo;// 0 - pistol
    public int[] maxAmmo;

    public void FindItemInInventory(string itemName)
    {
        for(int i=0; i<slots.Count; i++)
        {
            if (slots[i].currentItem.name== itemName)
            {
                Debug.Log("Aboba");
            }
        }
    }
    public void UpdateWeapon (Weapon weapon)
    {
        weapons.Add(weapon);
        shootComponent.weapon= weapons[0];
    }
    public int GetAmmo(int ammoType, int count)
    {
        if (currentAmmo[ammoType]>= count)
        {
            currentAmmo[ammoType] -= count;
            return count;
        }
        else
        {
            int a = currentAmmo[ammoType];
            currentAmmo[ammoType] = 0;
            return (a);
        }
    }
}
