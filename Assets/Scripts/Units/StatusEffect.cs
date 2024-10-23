using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour
{
    public string effectName; // �������� �������
    public float duration; // ������������ ������� � ��������
    public float effectPower; // ������������ ������� � ��������
    public System.Action onApply; // �������� ��� ��������� �������
    public System.Action onExpire; // �������� ��� ��������� �������

    private float remainingTime; // �����, ���������� �� ��������� �������

    public StatusEffect(string name, float duration,float effectPower, System.Action apply, System.Action expire)
    {
        effectName = name;
        this.duration = duration;
        this.effectPower = effectPower;
        onApply = apply;
        onExpire = expire;
        remainingTime = duration;
    }

    // ��������� ��������� �������
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
    public string effectName; // �������� �������
    public float duration; // ������������ ������� � ��������
    public float effectPower; // ������������ ������� � ��������
    public System.Action onApply; // �������� ��� ��������� �������
    public System.Action onExpire; // �������� ��� ��������� �������
    public System.Action onUpdate; // �������� ��� ��������� �������

    private float remainingTime; // �����, ���������� �� ��������� �������

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

    // ��������� ��������� �������
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
