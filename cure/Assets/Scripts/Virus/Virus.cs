using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Virus : MonoBehaviour
{
    [SerializeField] Type type = Type.Green;
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
    [Tooltip("This value is for how many seconds the newly created virus should move, " +
        "even if its outside of the screen (to prevent large numbers on the exact same spot)")]
    [SerializeField] float firstMovementTime = 10f;

    Vector2 targetPos = new Vector2();


    bool isFollowingPlayer = false;
    bool isInsideScreen = false;

    [SerializeField] GameObject body = null;

    MoveController player;

    void Start()
    {
        firstMovementTime = firstMovementTime + Time.time;
        player = FindObjectOfType<MoveController>();
        SetName();
        AddToVirionList();
        targetPos = GetTargetPos();
    }

    private void SetName()
    {
        switch (type)
        {
            case Type.Green:
                gameObject.name = "Green Virus";
                break;
            case Type.Orange:
                gameObject.name = "Orange Virus";
                break;
            case Type.Red:
                gameObject.name = "Red Virus";
                break;
            case Type.Blue:
                gameObject.name = "Blue Virus";
                break;
        }
    }

    void Update()
    {
        CheckFollowPlayer();
    }

    private void CheckFollowPlayer()
    {
        float xDistance = Mathf.Abs(transform.position.x - player.transform.position.x);
        float yDistance = Mathf.Abs(transform.position.y - player.transform.position.y);

        if (xDistance < detectionRange || yDistance < detectionRange && !isFollowingPlayer)
        {
            float distance = Mathf.Abs(Vector2.Distance(transform.position, player.transform.position));
            if (distance <= detectionRange)
            {
                isFollowingPlayer = true;
            }
        }
        if (xDistance >= followRange || yDistance >= followRange)
        {
            isFollowingPlayer = false;
        }
    }

    private void FixedUpdate()
    {
        if (!isInsideScreen && firstMovementTime <= Time.time) 
        {
            return;
        }
        SetTargetPos();
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
    }

    private void SetTargetPos()
    {
        if (isFollowingPlayer)
        {
            targetPos = GetTargetPos(player);
        }
        else if ((Vector2)transform.position == targetPos)
        {
            targetPos = GetTargetPos();
        }
    }
    private Vector2 GetTargetPos()
    {
        float x = transform.position.x + Random.Range(0, movementRange * 2 + 1)- movementRange;
        float y = transform.position.y + Random.Range(0, movementRange * 2 + 1)- movementRange;
        return new Vector2(x,y);
    }
    private Vector2 GetTargetPos(MoveController player)
    {
        return new Vector2(player.transform.position.x, player.transform.position.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            ToggleVirusVisibility(true);
        }
        if (collision.gameObject.tag == "Player")
        {
            CollideWithPlayer(collision);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            ToggleVirusVisibility(false);
        }
    }

    private void CollideWithPlayer(Collider2D collision)
    {
        collision.GetComponent<HealthAmmo>().DecreaseVaccine(type, vaccineCost);
        RemoveFromVirionList();
        Destroy(gameObject);
    }

    private void ToggleVirusVisibility(bool value)
    {
        isInsideScreen = value;
        body.SetActive(value);
    }

    public void TakeDamage(Type type,int damage)
    {
        if(this.type == type || type == Type.Normal)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
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
        GetComponentInParent<VirusController>().RemoveFromVirionsList(this, type);
    }
    private void AddToVirionList()
    {
        GetComponentInParent<VirusController>().AddToVirionList(this, type);
    }

    public void SplitCell()
    {
        Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y);
        Instantiate(virusPrefab, spawnPos, Quaternion.identity, transform.parent).SetHealth(health);
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    // remove this?
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}