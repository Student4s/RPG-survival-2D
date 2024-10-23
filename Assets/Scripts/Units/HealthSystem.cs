using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private Unit unit;
    [SerializeField] private EffectSystem es;

    // resist using %. 
    [Foldout("Resists")]
    public float armor;
    [Foldout("Resists")]
    public float bleedResist;
    [Foldout("Resists")]
    public float toxicResist;

    void Start()
    {
        unit = gameObject.GetComponent<Unit>();
        es = gameObject.GetComponent<EffectSystem>();
    }

    public void GetDamage(float damage, string damageType)
    {
        float totalDamage = 0f;

        if(damageType=="kinetic")
        {
            totalDamage = damage * armor;
        }
        if (damageType == "poison")
        {
            totalDamage = damage * toxicResist;
            Intoxication(totalDamage / 3);// every toxic attack can intoxicate player with chance in 1/3*damage*100%
        }

        unit.GetDamage(totalDamage);

        if(unit.currentHP <= unit.maxHP/2)
        {
            Bleeding((unit.currentHP/ unit.maxHP) *100);
        }
    }

    public void BrokeLeg(float chanse)
    {
        int A = Random.Range(0, 100);
        if(A <= chanse)
        {
            es.BrokeLeg();
            Debug.Log("Faggot leg broken");
        }
    }
    public void BrokeArm(float chanse)
    {
        int A = Random.Range(0, 100);
        if (A <= chanse)
        {
            es.BrokeArm();
            Debug.Log("Faggot arm broken");
        }
    }
    public void Bleeding(float chanse)
    {
        int A = Random.Range(0, 100);
        if (A <= chanse* bleedResist)
        {
            es.Bleeding();
            Debug.Log("Faggot bleeding");
        }
    }
    public void Intoxication(float chanse)
    {
        int A = Random.Range(0, 100);
        if (A <= chanse* toxicResist)
        {
            es.Intoxication();
            Debug.Log("Faggot Intoxicated");
        }
    }

}
