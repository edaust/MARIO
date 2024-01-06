using UnityEngine;
using UnityEngine.UI;  // UI için gerekli

public class GameUIManager : MonoBehaviour
{
    public Button startButton;
    public Button stopButton;
    public Button settingsButton;
    public Text scoreText;
    public Text diamondText;
    public Image[] lifeImages; // Can göstergeleri için

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        stopButton.onClick.AddListener(StopGame);
        settingsButton.onClick.AddListener(OpenSettings);
    }

    void StartGame()
    {
        // Oyun baþlatma kodlarý
    }

    void StopGame()
    {
        // Oyun durdurma kodlarý
    }

    void OpenSettings()
    {
        // Ayarlar menüsünü açma kodlarý
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateDiamondCount(int count)
    {
        diamondText.text = "Diamonds: " + count;
    }

    public void UpdateLives(int lives)
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            lifeImages[i].enabled = i < lives;
        }
    }
}
