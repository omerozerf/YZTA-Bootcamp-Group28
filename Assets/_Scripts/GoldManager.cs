using UnityEngine;
using TMPro;

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance;
    public int currentGold = 50;
    public TextMeshProUGUI goldText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGoldUI();
    }

    public void AddGold(int amount)
    {
        currentGold += amount;
        UpdateGoldUI();
    }

    public bool SpendGold(int amount)
    {
        if (currentGold >= amount)
        {
            currentGold -= amount;
            UpdateGoldUI();
            return true;
        }
        return false;
    }

    void UpdateGoldUI()
    {
        goldText.text = currentGold.ToString();
    }
}