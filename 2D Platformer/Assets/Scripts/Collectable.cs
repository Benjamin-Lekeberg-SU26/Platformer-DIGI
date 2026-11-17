using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] GameObject platform;

    void Start()
    {
        platform.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            platform.SetActive(true);

            Destroy(gameObject);
        }
    }
}