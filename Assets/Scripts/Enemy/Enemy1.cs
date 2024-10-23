using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Vector3 target;
    public GameObject player;
    public Transform rayPoint;
    public string state;
    public float packId;
    
    [Foldout("IDLE")]
    public float moveSpeed = 2f;
    [Foldout("IDLE")]
    public float walkRadius = 3f;
    [Foldout("IDLE")]
    public float waitTime = 4f;
    [Foldout("IDLE")]
    public float currentWaitTime = 0f;
    [Foldout("IDLE")]
    private bool isMoving = false;

    [Foldout("Initiate")]
    public float chargeDistance;
    [Foldout("Initiate")]
    public float circleDistance;
    [Foldout("Initiate")]
    public float initiateSpeed;

    [Foldout("Charge")]
    public float attackDistance;
    [Foldout("Charge")]
    public float chargeSpeed;
    [Foldout("Charge")]
    public float attackSpeed;
    [Foldout("Charge")]
    public float currentTimeBtwAttack;
    [Foldout("Charge")]
    public float damage;
    [Foldout("Charge")]
    public string damageType;

    public delegate void ChangeState(float id);
    public static event ChangeState ChangeToCharge;
    private void OnEnable()
    {
        ChangeToCharge += PackAttack;
    }
    private void OnDisable()
    {
        ChangeToCharge -= PackAttack;
    }

    void Update()
    {
        StateMachine();
        RotateToTarget();
        currentTimeBtwAttack -= Time.deltaTime;
    }

    void RotateToTarget()
    {
        Vector2 direction = target - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    void StateMachine()
    {
        switch (state)
        {
            case ("IDLE"):
                IDLEMoving();
                break;
            case ("Initiate"):
                Initiate();
                break;
            case ("Charge"):
                Charge();
                break;
        }
    }
    void Initiate()
    {
        target = player.transform.position;
        if(Vector3.Distance(transform.position, target)>= circleDistance)//go to player straight
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, initiateSpeed * Time.deltaTime);
        }
        else
        {
            Debug.DrawRay(rayPoint.position, transform.right * 10, Color.yellow);
            RaycastHit2D hit = Physics2D.Raycast(rayPoint.position, transform.right);

            if (hit.collider.CompareTag("PlayerVision"))// enemy in player vision zone
            {
                gameObject.transform.Translate(0,initiateSpeed* Time.deltaTime,0);
                //gameObject.transform.Translate(-initiateSpeed * Time.deltaTime / 2, 0,0);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, initiateSpeed * Time.deltaTime);
            }
        }
        if(Vector3.Distance(transform.position, target) <= chargeDistance)
        {
            state = "Charge";
            ChangeToCharge(packId);
        }
    }

    void Charge()
    {
        target = player.transform.position;
        if (Vector3.Distance(transform.position, player.transform.position) > attackDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, chargeSpeed * Time.deltaTime);
        }
        else
        {
            if(currentTimeBtwAttack<=0)
            {
                player.GetComponent<HealthSystem>().GetDamage(damage, damageType);
                currentTimeBtwAttack = attackSpeed;
            }
        }
            
    }

    void IDLEMoving()
    {
        currentWaitTime -= Time.deltaTime;
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            isMoving = false;
        }

        if(currentWaitTime <= 0)
        {
            currentWaitTime = waitTime;
            Vector2 randomDirection = Random.insideUnitCircle * walkRadius;
            target = new Vector3(transform.position.x + randomDirection.x, transform.position.y + randomDirection.y, transform.position.z);
            isMoving = true;
        }
    }

    public void PackAttack(float id)
    {
        if(packId==id)
        {
            state = "Charge";
        }
    }
}
