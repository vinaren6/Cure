using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Virus : MonoBehaviour
{
    [SerializeField] VirusType virusType = VirusType.Green;
    [SerializeField] int health;
    [SerializeField] float speed = 1f;
    [SerializeField] float detectionRange = 5f;
    //[SerializeField] int rangeMultiplier = 3;
    [SerializeField] Virus virusPrefab = null;

    [Header("Movement parameters")]
    [Tooltip("This will determine how far the virus can move from its current position into a new direction")]
    [SerializeField] int movementRange = 10;

    Vector2 targetPos = new Vector2();

    bool isFollowingPlayer = false;

    bool isInsideScreen = false;

    [SerializeField] GameObject body = null;

    void Start()
    {
        switch (virusType)
        {
            case VirusType.Green:
                gameObject.name = "Green Virus";
                break;
            case VirusType.Orange:
                gameObject.name = "Orange Virus";
                break;
            case VirusType.Red:
                gameObject.name = "Red Virus";
                break;
            case VirusType.Blue:
                gameObject.name = "Blue Virus";
                break;
        }
        SetTargetPos();
    }

    void Update()
    { 
        // put this code back once we have a player in our scene and also optimize it ( a quick check on x and y separately to see if one should collide or not
/*        float distance = Mathf.Abs(Vector2.Distance(transform.position, follow.transform.position));
        if (distance <= detectionRange)
        {
            isFollowingPlayer = true;
        }
        else if (distance >= detectionRange * rangeMultiplier)
        {
            isFollowingPlayer = false;
        }    */ 
    }

    private void FixedUpdate()
    {   
        if(!isInsideScreen) { return; }
        if(isFollowingPlayer)
        {
            // put this code back once we have a player in our scene
           // targetPos = new Vector2(follow.transform.position.x, follow.transform.position.y);
        }
        else if ((Vector2)transform.position == targetPos)
        {
            SetTargetPos();
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
    }

    private void SetTargetPos()
    {
        float x = transform.position.x + Random.Range(-movementRange, movementRange + 1);
        float y = transform.position.y + Random.Range(-movementRange, movementRange + 1);
        targetPos = new Vector2(x,y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            isInsideScreen = true;
            body.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            isInsideScreen = false;
            body.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // add some fancy death animation 
            Destroy(gameObject);
        }
    }

    public void SplitCell()
    {
        Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y);
        Virus spawnedVirus = Instantiate(virusPrefab, spawnPos, Quaternion.identity, transform.parent);
    }



    // remove this?
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}