// Code writer: Nicklas 
using UnityEngine;

public class Vaccine : MonoBehaviour
{
    [SerializeField] Type type = Type.Green;
    [SerializeField] int vaccineAmount = 3;

    [SerializeField]
    private AudioSource audioSource = null;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        GetComponentInParent<VaccineSpawner>().AddToVaccineList(this, type);
        switch (type)
        {
            case Type.Green:
                gameObject.name = "Green Vaccine";
                break;
            case Type.Orange:
                gameObject.name = "Orange Vaccine";
                break;
            case Type.Red:
                gameObject.name = "Red Vaccine";
                break;
            case Type.Blue:
                gameObject.name = "Blue Vaccine";
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            collision.gameObject.GetComponent<HealthAmmo>().IncreaseVaccine(type, vaccineAmount);
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;

            Invoke("DestroyObject", 1f);
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
