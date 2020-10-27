using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    [SerializeField] VirusType virusType = VirusType.Green;
    [SerializeField] int health;

    [SerializeField] Virus virusPrefab = null;

    [Header("Movement parameters")]
    [Tooltip("This will determine how far the virus can move from its current position into a new direction")]
    [SerializeField] int movementRange = 10;
    [SerializeField] float speed = 1f;
    [SerializeField] float detectionRange = 5f;
    //[SerializeField] int rangeMultiplier = 3;

    Vector2 targetPos = new Vector2();

    bool isFollowingPlayer = false;
    bool isInsideScreen = false;

    [SerializeField] GameObject body = null;

    void Start()
    {
        SetName();
        AddToVirionList();
        SetTargetPos();
    }

    private void SetName()
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
        float x = transform.position.x + Random.Range(0, movementRange * 2 + 1)- movementRange;
        float y = transform.position.y + Random.Range(0, movementRange * 2 + 1)- movementRange;
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
            Die();
        }
    }

    private void Die()
    {
        // add some fancy death animation 
        GetComponentInParent<VirusController>().RemoveFromVirionsList(this, virusType);
        Destroy(gameObject);
    }

    private void AddToVirionList()
    {
        GetComponentInParent<VirusController>().AddToVirionList(this, virusType);
    }

    public void SplitCell()
    {
        Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y);
        Instantiate(virusPrefab, spawnPos, Quaternion.identity, transform.parent);
    }



    // remove this?
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}