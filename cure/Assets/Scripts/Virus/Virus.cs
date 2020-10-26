using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Transactions;
using UnityEditor;
using UnityEngine;

public class Virus : MonoBehaviour
{
    int health;
    [SerializeField] float speed = 1f;
    [SerializeField] float detectionRadius = 5f;


    Vector2 targetPos = new Vector2();
    Vector2 currentPos = new Vector2();

    

    public Virus(VirusType type, int health)
    {
        this.health = health;
        switch (type)
        {
            case VirusType.Green:
                gameObject.tag = "Green";
                break;
            case VirusType.Orange:
                gameObject.tag = "Orange";
                break;
            case VirusType.Red:
                gameObject.tag = "Red";
                break;
            case VirusType.Blue:
                gameObject.tag = "Blue";
                break;
        }
    }

    void Start()
    {
        targetPos = new Vector2(Random.Range(-11, 12), Random.Range(-5,6));
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = new Vector2(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        if (currentPos == targetPos)
        {
            currentPos = targetPos;
            targetPos = new Vector2(Random.Range(-11, 12), Random.Range(-5, 6));
        }
        else if (currentPos != targetPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            // add some fancy death animation 
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(currentPos, detectionRadius);
    }
}