using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private float movementSpeed = 0.2f;
    [SerializeField]
    private float dashSpeed = 0;
    private float dashTime;
    public float startDashTime;
    bool IsDash = false;
    Rigidbody2D rb2d;
    Vector2 movement;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTime >= 0)
        {
            IsDash = true;
        }
        else
        {
            dashTime = startDashTime;
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
            rb2d.MovePosition(rb2d.position + movement * movementSpeed );
        }
       
        
    }

    private void dash()
    {
       
            
            if (movement.x != 0 || movement.y != 0)
            {
                
                
                
                    
                    dashTime -= Time.deltaTime;
                    rb2d.velocity = movement * dashSpeed;
                    Debug.Log(rb2d.velocity);
                
            }
        }
    
}
