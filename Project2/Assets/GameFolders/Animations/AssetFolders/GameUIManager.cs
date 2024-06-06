using UnityEngine;
using UnityEngine.UI;  // UI i�in gerekli

public class GameUIManager : MonoBehaviour
{
    public Button startButton;
    public Button stopButton;
    public Button settingsButton;
    public Text scoreText;
    public Text diamondText;
    public Image[] lifeImages; // Can g�stergeleri i�in

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        stopButton.onClick.AddListener(StopGame);
        settingsButton.onClick.AddListener(OpenSettings);
    }

    void StartGame()
    {
        // Oyun ba�latma kodlar�
    }

    void StopGame()
    {
        // Oyun durdurma kodlar�
    }

    void OpenSettings()
    {
        // Ayarlar men�s�n� a�ma kodlar�
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
