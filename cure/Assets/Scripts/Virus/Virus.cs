// Code writer: Nicklas 
using System.Net.Http.Headers;
using UnityEngine;

public class Virus : MonoBehaviour
{   
    [SerializeField] GameObject body = null;
    [SerializeField] Virus virusPrefab = null;
    
    [Header("Virus stats")]
    [SerializeField] Type type = Type.Green;
    [SerializeField] int health;
    [Tooltip("The cost to players vaccine level when colliding with this virus")]
    [SerializeField] int vaccineCost = 1;

    [Header("Movement")]
    [SerializeField] float speed = 1f;
    [Tooltip("This value is for how many seconds the newly created virus should move, " +
    "even if its outside of the screen (to prevent large numbers on the exact same spot)")]
    [SerializeField] float forcedMoveTime = 10f;
    [Tooltip("This will determine how far the virus can move from its current position into a new direction")]
    [SerializeField] int movementRange = 10;
    [SerializeField] float detectionRange = 5f;
    [SerializeField] float followRange = 4f;

    Vector2 moveArea = new Vector2();
    Vector2 targetPos = new Vector2();

    bool isFollowingPlayer = false;
    bool isInsideScreen = false;

    Transform player;

    void Start()
    {   
        player = FindObjectOfType<MoveController>().transform;  
        
        targetPos = GetTargetPos();
        forcedMoveTime = forcedMoveTime + Time.time;

        SetName();
        AddToVirionList();
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
        if (!isInsideScreen && forcedMoveTime <= Time.time) 
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
        float x = Random.Range(0, moveArea.x * 2 + 1) - moveArea.x;
        float y = Random.Range(0, moveArea.y * 2 + 1) - moveArea.y;
        return new Vector2(x,y);
    }
    private Vector2 GetTargetPos(Transform player)
    {
        return new Vector2(player.position.x, player.position.y);
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
            Die();
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
        // add some fancy death animation?
        Destroy(gameObject);
    }

    private void AddToVirionList()
    {
        GetComponentInParent<VirusController>().AddToVirionList(this, type);
    }

    public void SplitCell()
    {
        Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y);
        Instantiate(virusPrefab, spawnPos, Quaternion.identity, transform.parent).InitializeVirus(health,moveArea);
    }

    public void InitializeVirus(int health, Vector2 moveArea)
    {
        this.moveArea = moveArea;
        this.health = health;
    }

    public void SetMoveArea(Vector2 moveArea)
    {
        this.moveArea = moveArea;
    }

    // remove this?
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}