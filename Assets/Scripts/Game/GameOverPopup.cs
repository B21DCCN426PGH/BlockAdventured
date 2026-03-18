using UnityEngine;

public class GameOverPopup : MonoBehaviour
{
    public GameObject gameOverPopup;
    public GameObject losePopup;
    public GameObject newBestScorePopup;

    void Start()
    {
        gameOverPopup.SetActive(false);
        
    }

    private void OnEnable()
    {
        GameEvent.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        GameEvent.GameOver -= OnGameOver;
    }

    private void OnGameOver(bool newBestScore)
    {
        gameOverPopup.SetActive(true);
        losePopup.SetActive(false);
        newBestScorePopup.SetActive(true);
    }
}
