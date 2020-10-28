using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Virus : MonoBehaviour
{
    [SerializeField] VirusType virusType = VirusType.Green;
    [SerializeField] int health;

    [SerializeField] Virus virusPrefab = null;
    [Tooltip("The cost to players vaccine level when colliding with this vaccine")]
    [SerializeField] int vaccineCost = 1;

    [Header("Movement parameters")]
    [Tooltip("This will determine how far the virus can move from its current position into a new direction")]
    [SerializeField] int movementRange = 10;
    [SerializeField] float speed = 1f;
    [SerializeField] float detectionRange = 5f;
    [SerializeField] float followRange = 4f;

    Vector2 targetPos = new Vector2();

    bool isFollowingPlayer = false;
    bool isInsideScreen = false;

    [SerializeField] GameObject body = null;

    MoveController player;

    void Start()
    {
        player = FindObjectOfType<MoveController>();
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
        
        float xDistance = Mathf.Abs(transform.position.x - player.transform.position.x);
        float yDistance = Mathf.Abs(transform.position.y - player.transform.position.y);

        if(xDistance < detectionRange || yDistance < detectionRange && !isFollowingPlayer)
        {
            float distance = Mathf.Abs(Vector2.Distance(transform.position, player.transform.position));
            if (distance <= detectionRange)
            {
                isFollowingPlayer = true;
            }        
        }
        if(xDistance >= followRange || yDistance >= followRange)
        {
            isFollowingPlayer = false;
        }

    }

    private void FixedUpdate()
    {   
        if(!isInsideScreen) { return; }
        if(isFollowingPlayer)
        {
            targetPos = SetTargetPos(player);
        }
        else if((Vector2)transform.position == targetPos)
        {
            targetPos = SetTargetPos();
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
    }

    private Vector2 SetTargetPos()
    {
        float x = transform.position.x + Random.Range(0, movementRange * 2 + 1)- movementRange;
        float y = transform.position.y + Random.Range(0, movementRange * 2 + 1)- movementRange;
        return new Vector2(x,y);
    }
    private Vector2 SetTargetPos(MoveController player)
    {
        return new Vector2(player.transform.position.x, player.transform.position.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            isInsideScreen = true;
            body.SetActive(true);
        }
        if (collision.gameObject.tag == "Player")
        {
            // put this code in once victor has created a player script and a method that handles removing vaccine .
            //collision.GetComponent<Player>().DecreaseVaccine(virusType, vaccineCost);
            RemoveFromVirionList();
            Destroy(gameObject);
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
        // add some fancy death animation ?
        RemoveFromVirionList();
        Destroy(gameObject);
    }

    private void RemoveFromVirionList()
    {
        GetComponentInParent<VirusController>().RemoveFromVirionsList(this, virusType);
    }
    private void AddToVirionList()
    {
        GetComponentInParent<VirusController>().AddToVirionList(this, virusType);
    }

    public void SplitCell()
    {
        // if virus is outside of the screen make it spawn the virus a bit away from it
        // to avoid having 200 on the same spot making the game lagg like crazy, alternatively 
        // make a timer that counts down to zero once spawned but as long as its not zero virus can move normally.
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