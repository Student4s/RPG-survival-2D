using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour
{
    public string effectName; // Название эффекта
    public float duration; // Длительность эффекта в секундах
    public float effectPower; // Длительность эффекта в секундах
    public System.Action onApply; // Действие при активации эффекта
    public System.Action onExpire; // Действие при истечении времени

    private float remainingTime; // Время, оставшееся до окончания эффекта

    public StatusEffect(string name, float duration,float effectPower, System.Action apply, System.Action expire)
    {
        effectName = name;
        this.duration = duration;
        this.effectPower = effectPower;
        onApply = apply;
        onExpire = expire;
        remainingTime = duration;
    }

    // Обновляем состояние эффекта
    public void UpdateEffect(float deltaTime)
    {
        remainingTime -= deltaTime;
        if (remainingTime <= 0)
        {
            onExpire?.Invoke();
        }
    }

    public bool IsExpired()
    {
        return remainingTime <= 0;
    }
}
public class TickEffects : MonoBehaviour
{
    public string effectName; // Название эффекта
    public float duration; // Длительность эффекта в секундах
    public float effectPower; // Длительность эффекта в секундах
    public System.Action onApply; // Действие при активации эффекта
    public System.Action onExpire; // Действие при истечении времени
    public System.Action onUpdate; // Действие при истечении времени

    private float remainingTime; // Время, оставшееся до окончания эффекта

    public TickEffects(string name, float duration, float effectPower, System.Action apply, System.Action expire,System.Action update)
    {
        effectName = name;
        this.duration = duration;
        this.effectPower = effectPower;
        onApply = apply;
        onExpire = expire;
        onUpdate = update;
        remainingTime = duration;
    }

    // Обновляем состояние эффекта
    public void UpdateEffect(float deltaTime)
    {
        remainingTime -= deltaTime;
        onUpdate.Invoke();
        if (remainingTime <= 0)
        {
            onExpire?.Invoke();
        }
    }

    public bool IsExpired()
    {
        return remainingTime <= 0;
    }
}
