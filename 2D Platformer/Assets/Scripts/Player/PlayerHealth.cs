using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 5;
    
    [SerializeField] float hitInvulnerability = 1f;
    bool isInvulnerable;
    private int startingHealth;

    void Start()
    {
        startingHealth = playerHealth;
    }

    public void ResetHealth()
    {
        playerHealth = startingHealth;
    }
    
    void Update()
    {
        if (playerHealth <= 0)
        {
            FindAnyObjectByType<LevelManager>().RestartScene();
        }
    }
    
    public void HealthDepletion()
    {
        
        if (!isInvulnerable)
        {
            playerHealth--;
            isInvulnerable = true;
            Invoke("CancelInvulnerability", hitInvulnerability);
            Debug.Log(playerHealth);
        }
    }
    void CancelInvulnerability()
    {
        isInvulnerable = false;
    }
}
