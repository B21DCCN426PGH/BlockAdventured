using UnityEngine;
using UnityEngine.UI;

public class BestScoreBar : MonoBehaviour
{
    public Image fillIngImage;
    public Text bestScoreText;

    private void OnEnable()
    {
        GameEvent.UpdateBestScoreBar += UpdateBestScoreBar;
    }

    private void OnDisable()
    {
        GameEvent.UpdateBestScoreBar -= UpdateBestScoreBar;
    }

    private void UpdateBestScoreBar(int bestScore, int currentScore)
    {
        float currentPercentage = (float)currentScore / (float)bestScore;
        fillIngImage.fillAmount = currentPercentage;
        bestScoreText.text = bestScore.ToString();
    }
}
