using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Ball ball;

    public Paddle playerPaddle;

    public Paddle computerPaddle;

    public TextMeshProUGUI playerScoreText;

    public TextMeshProUGUI computerScoreText;

    private int playerScore;

    private int computerScore;


    public void PlayerScores()
    {
        playerScore++;
        this.playerScoreText.text = playerScore.ToString();
        ResetRound();
    }
    public void ComputerScores()
    {
        computerScore++;
        this.computerScoreText.text = computerScore.ToString();
        ResetRound();
    }
    
    private void ResetRound()
    {
        this.playerPaddle.ResetPosition();
        this.computerPaddle.ResetPosition();
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
    }

}
