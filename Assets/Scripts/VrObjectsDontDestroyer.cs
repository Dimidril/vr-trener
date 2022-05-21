using UnityEngine;

public class VrObjectsDontDestroyer : MonoBehaviour
{
    public static VrObjectsDontDestroyer Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != Instance)
        {
            Destroy(gameObject);
        }
    }
}