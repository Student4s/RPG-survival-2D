using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float maxLifeTime;
    public float currentLifeTime;
    //public bool IsActive;
    public float damage;
    public string damageType = "kinetic";
    private void Start()
    {
        currentLifeTime = 0;
    }
    private void FixedUpdate()
    {
        currentLifeTime += Time.fixedDeltaTime;
        if (currentLifeTime < maxLifeTime)
        {
            gameObject.transform.Translate(0, speed * Time.fixedDeltaTime, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<HealthSystem>()!=null)
        {
            collision.collider.GetComponent<HealthSystem>().GetDamage(damage, damageType);
        }
        Destroy(gameObject);
    }
}
