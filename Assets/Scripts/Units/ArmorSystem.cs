using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using static UnityEngine.Rendering.DebugUI;
using Unity.VisualScripting;

public class ArmorSystem : MonoBehaviour
{
    public List<InventorySlotArmor> armorSlots;


    [Foldout("Native armor")]
    public float nArmor;
    [Foldout("Native armor")]
    public float nToxicResist;
    [Foldout("Native armor")]
    public float nBleedingResist;

    public HealthSystem hs;
    void Start()
    {
        hs = gameObject.GetComponent<HealthSystem>();
        UpdateTotalArmor();
    }
    public void UpdateTotalArmor()// recalculate armor
    {
        float armor=0;
        float toxicResist=0;
        float bleedingResist=0;
        for(int i =0; i< armorSlots.Count; i++)
        {
            if (armorSlots[i].currentItem!=null)
            {
                Debug.Log(i);
                armor += armorSlots[i].itemArmor.armor;
                toxicResist += armorSlots[i].itemArmor.toxicResist;
                bleedingResist += armorSlots[i].itemArmor.bleedingResist;
            }
        }
        hs.armor = 1-(nArmor+armor) /100;
        hs.toxicResist = 1-(nToxicResist+ toxicResist) /100;
        hs.bleedResist = 1-(nBleedingResist+ bleedingResist) /100;
    }
}

