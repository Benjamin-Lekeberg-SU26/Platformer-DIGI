using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    [SerializeField] GameObject fallingSpike;
    [SerializeField] float fallingSpeed = 5.5f;
    Rigidbody2D rb;
    Collider2D triggerFall;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        triggerFall = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.AddForce(Vector2.down * fallingSpeed, ForceMode2D.Impulse);
        }
    }
}
