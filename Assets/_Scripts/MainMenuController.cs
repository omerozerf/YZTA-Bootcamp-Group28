using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("HoldTheThrone");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Oyun kapatılıyor..."); // sadece editor için görsel kontrol
    }
}
