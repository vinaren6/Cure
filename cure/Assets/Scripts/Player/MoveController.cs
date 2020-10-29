using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private float movementSpeed = 0.1f;
    [SerializeField]
    private float dashSpeed = 70;
    bool IsDash = false;
    Rigidbody2D rb2d;
    Vector2 movement;
    float dashTimer = 0;
    [SerializeField]
    float dashTimerLenght = 2;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTimer <= 0)
        {
            IsDash = true;
        }
        if (dashTimer > 0)
        {
            dashTimer -= Time.deltaTime;
            rb2d.velocity = Vector2.zero;
        }
       

    }
    private void FixedUpdate()
    {
        if (IsDash )
        {
            Dash();
            IsDash = false;
        }
        else
        {
            rb2d.MovePosition(rb2d.position + movement * movementSpeed * 0.5f);
        }  
    }

    private void Dash()
    {   
            if (movement.x != 0 || movement.y != 0)
            {
                    rb2d.velocity = movement * dashSpeed;
                    dashTimer = dashTimerLenght;
            }
        }
    
}
