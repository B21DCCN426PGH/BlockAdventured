using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] public class BestScoreData
{
    public int score = 0;
}
public class Scores : MonoBehaviour
{
    public SquareTextureData squareTextureData;
    public Text scoreText;

    private bool newBestScore_ = false;
    private BestScoreData bestScore_ = new BestScoreData();

    private int currentScores_;

    private string bestScoreKey_ = "bsdat";

    private void Awake()
    {
        if (BinaryDataStream.Exist(bestScoreKey_))
        {
            StartCoroutine(ReadDataFile());

        }
    }

    private IEnumerator ReadDataFile()
    {
        bestScore_ = BinaryDataStream.Read<BestScoreData>(bestScoreKey_);
        yield return new WaitForEndOfFrame();
        GameEvent.UpdateBestScoreBar(currentScores_, bestScore_.score);
    }

    void Start()
    {
        currentScores_ = 0;
        newBestScore_ = false;
        squareTextureData.SetStartColor();
        UpdateScoreText();
    }

    private void OnEnable()
    {
        GameEvent.AddScores += AddScores;
        GameEvent.GameOver += SaveBestScores;
    }


    private void OnDisable()
    {
        GameEvent.AddScores -= AddScores;
        GameEvent.GameOver -= SaveBestScores;
    }

    public void SaveBestScores(bool newBestScores)
    {
        BinaryDataStream.Save<BestScoreData>(bestScore_, bestScoreKey_);
    }
    private void AddScores(int scores)
    {
        currentScores_ += scores;
        if(currentScores_ > bestScore_.score)
        {
            newBestScore_ = true;
            bestScore_.score = currentScores_;  
            SaveBestScores(true);
        }

        UpdateSquareColor();
        GameEvent.UpdateBestScoreBar(currentScores_, bestScore_.score);
        UpdateScoreText();
    }

    private void UpdateSquareColor()
    {
        if (GameEvent.UpdateSquareColor != null && currentScores_ >= squareTextureData.tresholdVal)
        {
            squareTextureData.UpdateColors(currentScores_);
            GameEvent.UpdateSquareColor(squareTextureData.currentColor);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text =currentScores_.ToString();
    }

}
