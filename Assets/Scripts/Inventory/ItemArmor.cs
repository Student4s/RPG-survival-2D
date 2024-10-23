using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/ItemArmor")]
public class ItemArmor : Item
{
    public float armor;
    public float toxicResist;
    public float bleedingResist;
}
