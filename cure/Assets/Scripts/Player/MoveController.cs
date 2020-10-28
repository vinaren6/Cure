using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private float movementSpeed = 0.1f;
    [SerializeField]
    private float dashSpeed = 0;
  
    public float startDashTime;
    bool IsDash = false;
    Rigidbody2D rb2d;
    Vector2 movement;
    float dashTimer = 0;
    float dashTimerLenght = 3;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
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
            dash();
            IsDash = false;
        }
        else
        {
            rb2d.MovePosition(rb2d.position + movement * movementSpeed * 0.5f);
        }  
    }

    private void dash()
    {   
            if (movement.x != 0 || movement.y != 0)
            {
                    dashTimer -= Time.deltaTime;
                    rb2d.velocity = movement * dashSpeed;
                    dashTimer = dashTimerLenght;
            }
        }
    
}
