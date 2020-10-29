using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    int dmg;
    Type type;

    void Start()
    {
        playAnimation();
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.layer == LayerMask.NameToLayer("Virus"))
            {
                 collision.gameObject.GetComponent<Virus>().TakeDamage(type, dmg);
                 Destroy(gameObject);
                
            }
    }
        
       
    private void playAnimation()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool(gameObject.tag, true);
    }   
     
    
   
    public void bulletTypeInstantiate(int dmg, Type type)
    {
        this.type = type;
        this.dmg = dmg;
        switch (type)
        {
            case Type.Green:
                gameObject.tag = "Green";
                
                break;
            case Type.Orange:
                gameObject.tag = "Orange";
                break;
            case Type.Red:
                gameObject.tag = "Red";
                break;
            case Type.Blue:
                gameObject.tag = "Blue";
                break;
            case Type.Normal:
                gameObject.tag = "Normal";
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
