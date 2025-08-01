using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverPanelController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject panel;
    public TMP_Text victoryText;

    private bool panelShown = false;

    // Zafere göre paneli göster
    public void ShowPanel(bool isVictory)
    {
        if (panelShown) return;

        panelShown = true;
        panel.SetActive(true);
        victoryText.gameObject.SetActive(isVictory);

        // Eğer butonlar hala basılmıyorsa, şu satırı da dene (gerekirse):
        // EventSystem.current.SetSelectedGameObject(null);
    }

    // Oyun yeniden başlatılırken tekrar çağrılmasına gerek yok
    public void RestartGame()
    {
        Debug.Log("RestartGame çağrıldı");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Çık butonu basıldı");
        SceneManager.LoadScene(0); // Ana menü sahnesi index 0
    }

    // Panel durumu sıfırlamak için eğer ihtiyaç olursa
    public void ResetPanelState()
    {
        panelShown = false;
    }
}
