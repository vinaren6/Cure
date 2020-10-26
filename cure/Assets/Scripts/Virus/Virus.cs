using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Virus : MonoBehaviour
{
    VirusType virusType;
    int health;
    [SerializeField] float speed = 1f;
    [SerializeField] float detectionRange = 5f;
    [SerializeField] int rangeMultiplier = 3;

    // remove this just for testing
    [SerializeField] bool split = false;
    [SerializeField] Virus virusPrefab = null;

    // change to player and not serialized field (find it using findobject)
    [SerializeField] GameObject follow = null;

    Vector2 targetPos = new Vector2();

    bool isFollowingPlayer = false;

    public void ActivateVirus(VirusType virusType, int health)
    {
        this.virusType = virusType;
        this.health = health;
        switch (virusType)
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

    void Update()
    {
        float distance = Mathf.Abs(Vector2.Distance(transform.position, follow.transform.position));
        if (distance <= detectionRange)
        {
            isFollowingPlayer = true;
        }
        else if (distance >= detectionRange * rangeMultiplier)
        {
            isFollowingPlayer = false;
        }

        if(split)
        {
            SplitCell();
        }  
        
    }

    private void FixedUpdate()
    {   
        if(isFollowingPlayer)
        {
            targetPos = new Vector2(follow.transform.position.x, follow.transform.position.y);
        }
        else if ((Vector2)transform.position == targetPos)
        {
            targetPos = new Vector2(Random.Range(-11, 12), Random.Range(-5, 6));
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
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

    public void SplitCell()
    {        
        split = false;

        Virus newVirus = virusPrefab;
        newVirus.ActivateVirus(virusType, health);
        
        Vector2 spawnPos = new Vector2(transform.position.x - (transform.localScale.x / 2), transform.position.y - (transform.localScale.y / 2));
        Instantiate(newVirus, spawnPos, Quaternion.identity, transform.parent);

        transform.position = new Vector2(transform.position.x + (transform.localScale.x / 2), transform.position.y + (transform.localScale.y / 2));

    }


    // remove this?
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}