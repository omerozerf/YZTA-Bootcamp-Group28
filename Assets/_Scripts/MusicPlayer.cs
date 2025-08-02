using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject); // Zaten varsa bunu yok et
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Sahne değişse bile silinme
    }
}
