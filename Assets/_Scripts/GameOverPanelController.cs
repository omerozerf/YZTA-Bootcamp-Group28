using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverPanelController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject panel;
    public TMP_Text victoryText;

    private bool panelShown = false;

    public void RestartGame()
    {
        if (panelShown) return;

        Debug.Log("RestartGame çağrıldı");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        if (panelShown) return;

        Debug.Log("Çık butonu basıldı");
        SceneManager.LoadScene(0); // Ana menü sahnesi index 0
    }

    public void ShowPanel(bool isVictory)
    {
        if (panelShown) return;

        panel.SetActive(true);
        victoryText.gameObject.SetActive(isVictory);
        panelShown = true;
    }
}
