using UnityEngine;
using TMPro;

public class TutorialMessage : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public float displayDuration = 5f;

    void Start()
    {
        tutorialText.gameObject.SetActive(true);
        Invoke(nameof(HideText), displayDuration);
    }

    void HideText()
    {
        tutorialText.gameObject.SetActive(false);
    }
}
