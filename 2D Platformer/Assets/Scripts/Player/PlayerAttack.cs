using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Collider2D feet;
    Collider2D body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        feet = GetComponent<CapsuleCollider2D>();
        body = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (feet.IsTouchingLayers(LayerMask.GetMask("Enemies")) && collision.gameObject.CompareTag("Enemies"))
        {
            Destroy(collision.gameObject);
        }
        else if (body.IsTouchingLayers(LayerMask.GetMask("Enemies")))
        {
            FindAnyObjectByType<PlayerHealth>().HealthDepletion();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Killbox"))
        {
            FindAnyObjectByType<LevelManager>().RestartScene();
        }
    }
}
