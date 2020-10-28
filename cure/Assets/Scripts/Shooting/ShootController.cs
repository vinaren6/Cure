using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public float bulletVelocity = 5f;
    public GameObject bullet;
    
    public HealthAmmo healtScript;
    private BulletType bulleType;
    
   

    // Start is called before the first frame update
    void Start()
    {

        bulleType = BulletType.Green;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        chooseBulletType();


        if (Input.GetButtonDown("Fire1"))
        {

            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<bullet>().bulletTypeInstantiate(1);
            newBullet.GetComponent<Rigidbody2D>().velocity = transform.up * 5f;
            
            

        }
        if (Input.GetButtonDown("Fire2"))
        {
           
            if (healtScript.healtAmmo[(int) bulleType] > 0)
            {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<bullet>().bulletTypeInstantiate(3, bulleType);
            newBullet.GetComponent<Rigidbody2D>().velocity = transform.up * 5f;
            healtScript.healtAmmo[(int)bulleType] -= 1;
            }
            
        }
    }

    void chooseBulletType()
    {
        if (Input.GetKeyDown("1"))
        {
            bulleType = BulletType.Green;
        }
        else if (Input.GetKeyDown("2"))
        {
            bulleType = BulletType.Blue;
        }
        else if (Input.GetKeyDown("3"))
        {
            bulleType = BulletType.Red;
        }
        else if (Input.GetKeyDown("4"))
        {
            bulleType = BulletType.Orange;
        }
    }
}
