using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    public float maxHealth = 100f;
    private float currentHealth;

    public Slider healthSlider;
    public GameObject gameOverPanel;

    void Awake()
    {
        Time.timeScale = 1f;
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        gameOverPanel.SetActive(false);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

   void GameOver()
    {
        Debug.Log("Game over tetiklendi");
        gameOverPanel.SetActive(true);
    }

/*    void Update()
{
    if (Input.GetKeyDown(KeyCode.H))
    {
        TakeDamage(5);
    }
}
*/
}