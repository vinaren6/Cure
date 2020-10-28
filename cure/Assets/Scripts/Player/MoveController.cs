using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private float movementSpeed = 5f;
    Rigidbody2D rb2d;
    Vector2 movement;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();    
    }


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        
    }
    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
