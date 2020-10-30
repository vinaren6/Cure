using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 0.1f;
    [SerializeField]
    private float dashSpeed = 0f;
    [SerializeField]
    private float acceleration = 0f;
    [SerializeField]
    private float dampening = 0f;
    [SerializeField]
    private float dashLength = 0f;
    [SerializeField]
    private float dashTimerLenght = 3;
    
    
    bool IsDash = false;
    Rigidbody2D rb2d;
    Vector2 movement;
    float dashTimer = 2;

    HealthAmmo healthAmmo;

    private void Start()
    {
        healthAmmo = GetComponent<HealthAmmo>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTimer >= dashTimerLenght)
        {
            IsDash = true;
        }
        if (dashTimer < dashTimerLenght)
        {
            if (dashTimer > 2)
                dashTimer = 2;
            else
                dashTimer += Time.deltaTime;
        }
       

    }
    private void FixedUpdate()
    {
        if (IsDash)
        {
            Dash();
            IsDash = false;
        }
        else
        {

            if(rb2d.velocity.magnitude < maxSpeed)
            {
                //velocity += movement.normalized * acceleration * Time.fixedDeltaTime;
                rb2d.AddForce(movement.normalized * acceleration * Time.fixedDeltaTime, ForceMode2D.Impulse);
            }

        }  
    }

    public float getDashCoolDown()
    {
        return dashTimer;
    }

    private void Dash()
    {
        healthAmmo.StartDashEnumerator();
        if (movement.x != 0 || movement.y != 0)
        {
            rb2d.AddForce(movement.normalized * dashSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            dashTimer = 0;
        }
    }
}
