using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public float maxLifeTime;
    public float currentLifeTime;
    public float damage;
    public float throwForce;

    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Throw(throwForce);
    }
    public void Throw(float force)
    {
        rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
    }
    private void FixedUpdate()
    {
        currentLifeTime += Time.fixedDeltaTime;
        if (currentLifeTime > maxLifeTime)
        {
            Boom();
        }
    }

    void Boom()
    {
        Destroy(gameObject);
    }
}
