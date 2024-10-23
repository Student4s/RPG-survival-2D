using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveComponent : MonoBehaviour
{
    public Unit unit;

    public float speedMultiplicaator = 2f;     

    public float staminaRegenRate = 5f;  // Скорость восстановления выносливости
    public float staminaRunDrain = 10f;  // Скорость расхода выносливости при беге

    private float currentStamina; 
    private bool isRunning;         
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentStamina = unit.stamina;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {
            isRunning = true;
            if (movement != Vector2.zero)
            {
                currentStamina -= staminaRunDrain * Time.deltaTime;
            }
            else
            {
                currentStamina += staminaRegenRate * Time.deltaTime;
            }
        }
        else
        {
            isRunning = false;
            currentStamina += staminaRegenRate * Time.deltaTime;
        }
        currentStamina = Mathf.Clamp(currentStamina, 0, unit.stamina);

        //Rotate to Mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        direction.z = 0f;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90f));
    }

    void FixedUpdate()
    {
        float currentSpeed = isRunning ? unit.speed*speedMultiplicaator : unit.speed;
        rb.MovePosition(rb.position + movement.normalized * currentSpeed * Time.fixedDeltaTime);
    }

    void OnGUI()
    {
        // Отображение выносливости на экране (например, с помощью GUI.Label)
        GUI.Label(new Rect(10, 10, 200, 20), "Stamina: " + Mathf.Round(currentStamina).ToString());
    }
}
