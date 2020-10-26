using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public float bulletVelocity = 5f;
    public GameObject bullet;
    public GameObject GreenBullet;
    public enum BulletType
    {
        Green,
        Orange,
        Red,
        Blue
    }
    BulletType bulletType;
   

    // Start is called before the first frame update
    void Start()
    {
        bulletType = BulletType.Green;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        if (Input.GetButtonDown("Fire1"))
        {

            
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().velocity = transform.up * 10f;
        }
        if (Input.GetButtonDown("Fire2"))
        {


            GameObject newBullet = Instantiate(GreenBullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().velocity = transform.up * 10f;
        }
    }
}
