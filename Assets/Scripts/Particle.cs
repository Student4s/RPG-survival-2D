using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public float LifeTime;
    public float coef;// change collider radius
    private CircleCollider2D col;
    void Start()
    {
        col.radius *= coef;
    }

    // Update is called once per frame
    void Update()
    {
        LifeTime -= Time.deltaTime;
        if(LifeTime<=0)
        {
            Destroy(gameObject);
        }
    }
}
