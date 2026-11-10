using UnityEngine;

public class DontReset : MonoBehaviour
{
    void Awake()
    {
        int numberOfInstances = FindObjectsByType<DontReset>().Length;

        if (numberOfInstances > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
