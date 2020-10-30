using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    int dmg;
    Type type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.layer == LayerMask.NameToLayer("Virus"))
            {
                 collision.gameObject.GetComponent<Virus>().TakeDamage(type, dmg);
                 Destroy(gameObject);
                
            }
    }
        
    public void BulletTypeInstantiate(int dmg, Type type)
    {
        this.type = type;
        this.dmg = dmg;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            Destroy(gameObject);
        }
    }
}
