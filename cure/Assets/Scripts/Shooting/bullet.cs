using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    int dmg;
    // Start is called before the first frame update
    void Start()
    {
        playAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.layer == LayerMask.NameToLayer("Virus"))
            {
                Debug.Log(collision.gameObject.tag);
            Debug.Log("test");
                 if (collision.gameObject.tag == gameObject.tag || gameObject.tag.Equals("Grey"))
                 {
                    
                   collision.gameObject.GetComponent<Virus>().TakeDamage(dmg);

                 }
                 Destroy(gameObject);
                
            }
    }
        
       
    private void playAnimation()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool(gameObject.tag, true);
    }   
     
    
   
    public void bulletTypeInstantiate(BulletType bulletType, int dmg)
    {
        
        this.dmg = dmg;
        switch (bulletType)
        {
            case BulletType.Green:
                gameObject.tag = "Green";
                
                break;
            case BulletType.Orange:
                gameObject.tag = "Orange";
                break;
            case BulletType.Red:
                gameObject.tag = "Red";
                break;
            case BulletType.Blue:
                gameObject.tag = "Blue";
                break;
            case BulletType.Grey:
                gameObject.tag = "Grey";
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            Destroy(gameObject);
        }
    }
}
