using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float speed;

    [Foldout("Main Stats")]
    public float maxHP;
    [Foldout("Main Stats")]
    public float currentHP;
    [Foldout("Main Stats")]
    public float hpRegen;
    [Foldout("Main Stats")]
    public float stamina;

    private void Update()
    {
        if(currentHP <= maxHP)
        {
            currentHP += hpRegen * Time.deltaTime;
        }
    }
    public void GetDamage(float damage)
    {
        currentHP -= damage;
        if(currentHP<=0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
