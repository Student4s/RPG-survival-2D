using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectSystem : MonoBehaviour
{
    [SerializeField] private List<StatusEffect> activeEffects = new List<StatusEffect>();
    [SerializeField] private List<TickEffects> activeTickEffects = new List<TickEffects>();
    public Unit unit;

    private void Start()
    {
        unit = gameObject.GetComponent<Unit>();
        //ApplySlowEffect(0.1f,3);
        //Bleeding();
    }
    void Update()//update every effect status
    {
        for (int i = activeEffects.Count - 1; i >= 0; i--)
        {
            activeEffects[i].UpdateEffect(Time.deltaTime);
            if (activeEffects[i].IsExpired())
            {
                activeEffects.RemoveAt(i);
            }
        }
        for (int i = activeTickEffects.Count - 1; i >= 0; i--)
        {
            activeTickEffects[i].UpdateEffect(Time.deltaTime);
            if (activeTickEffects[i].IsExpired())
            {
                activeTickEffects.RemoveAt(i);
            }
        }
    }
    public void AddEffect(StatusEffect effect)
    {
        effect.onApply?.Invoke();
        activeEffects.Add(effect);
    }
    public void AddEffect2(TickEffects effect)
    {
        effect.onApply?.Invoke();
        activeTickEffects.Add(effect);
    }


    public void ApplySlowEffect(float effectPower, float duration)
    {
        float originalSpeed = unit.speed;
        AddEffect(new StatusEffect(
            "Slow",
            duration,
            effectPower,
            () => unit.speed = originalSpeed * effectPower,
            () => unit.speed = originalSpeed // Return speed after end
        ));
    }
    public void BrokeLeg()
    {
        float originalSpeed = unit.speed;
        AddEffect(new StatusEffect(
            "BrokeLeg",
            9999f,
            0.55f,
            () => unit.speed = originalSpeed * 0.55f, 
            () => unit.speed = originalSpeed //Return speed after end
        ));
    }
    public void BrokeArm()
    {
        float originalSpeed = unit.speed;
        AddEffect(new StatusEffect(
            "BrokeArm",
            9999f,
            0.55f,
            () => unit.stamina -= 10,
            () => unit.stamina += 10
        ));
    }

    // TICK EFFECTS
    public void Bleeding()
    {
        float originalSpeed = unit.speed;
        AddEffect2(new TickEffects(
            "Bleeding",
            9999f,
            1f,
            () => unit.speed = originalSpeed,
            () => unit.speed = originalSpeed,
            () => unit.GetDamage(1 * Time.deltaTime)
        ));
    }
    public void Intoxication()
    {
        float originalSpeed = unit.speed;
        AddEffect2(new TickEffects(
            "Intoxication",
            9999f,
            0.55f,
            () => unit.speed = originalSpeed,
            () => unit.speed = originalSpeed,
            () => unit.currentHP -= 1f * Time.deltaTime
        ));
    }
}
