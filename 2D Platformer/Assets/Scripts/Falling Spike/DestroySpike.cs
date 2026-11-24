using UnityEngine;

public class DestroySpike : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Killbox"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
