using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int firstUserScore = 0;
    public int secondUserScore = 0;
    public TextMeshProUGUI scoreBoard;


    public void Start()
    {
        UpdateScoreBoard();
    }

    public void IncrementFirstUserScore()
    {
        firstUserScore++;
        UpdateScoreBoard();
    }

    public void IncrementSecondUserScore()
    {
        secondUserScore++;
        UpdateScoreBoard();
    }

    private void UpdateScoreBoard()
    {
        scoreBoard.text = firstUserScore.ToString() + " - " + secondUserScore.ToString();
    }
}
