using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public float bulletVelocity = 100f;
    public GameObject bullet;
    
    public HealthAmmo healtScript;
    private Type type;
    float bulletTimer = 0;
    float bulletTimerLenght = 0.3f;
   

    // Start is called before the first frame update
    void Start()
    {

        type = Type.Green;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        chooseBulletType();

        Debug.Log(Input.GetButton("Fire1"));
        if (bulletTimer <= 0)
        {


            if (Input.GetButton("Fire1"))
            {

                GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
                newBullet.GetComponent<bullet>().bulletTypeInstantiate(1, Type.Normal);
                newBullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletVelocity;
                bulletTimer = bulletTimerLenght;


            }
        }
        if (bulletTimer <= 0)
        {
            if (Input.GetButton("Fire2"))
            {

                if (healtScript.GetVaccine((int)type) > 0)
                {
                    GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
                    newBullet.GetComponent<bullet>().bulletTypeInstantiate(3, type);
                    newBullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletVelocity;
                    healtScript.DecreaseVaccine(type, 1);
                    bulletTimer = bulletTimerLenght;
                }

            }
        }
        if (bulletTimer > 0)
        {
            bulletTimer -= Time.deltaTime;
        }
    }

    void chooseBulletType()
    {
        if (Input.GetKeyDown("1"))
        {
            type = Type.Green;
        }
        else if (Input.GetKeyDown("2"))
        {
            type = Type.Orange;
        }
        else if (Input.GetKeyDown("3"))
        {
            type = Type.Red;
        }
        else if (Input.GetKeyDown("4"))
        {
            type = Type.Blue;
        }
    }

    public Type GetSelectedVaccineType()
    {
        return type;
    }
}
