using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    BulletType bulletType;
    int dmg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            collision.gameObject.GetComponent<Virus>().TakeDamage(3);
            
        }
        Destroy(gameObject);
    }
    public void bulletTypeInstantiate(BulletType bulletType, int dmg)
    {
        Debug.Log(bulletType);
        this.bulletType = bulletType;
        this.dmg = dmg;
        switch (bulletType)
        {
            case BulletType.Green:
                gameObject.tag = "Green";
                GetComponent<SpriteRenderer>().color = new Color(0, 190, 0, 255);
                break;
            case BulletType.Orange:
                gameObject.tag = "Orange";
                break;
            case BulletType.Red:
                gameObject.tag = "Red";
                GetComponent<SpriteRenderer>().color = new Color(190, 0, 0, 255);
                break;
            case BulletType.Blue:
                GetComponent<SpriteRenderer>().color = new Color(0, 0, 130, 255);
                gameObject.tag = "Blue";
                break;
        }
    }
}
