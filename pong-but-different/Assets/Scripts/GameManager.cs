using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public UIManager ui;
    public Ball ball;

    public Paddle redPaddle;
    public Paddle bluePaddle;
    private Paddle playerPaddle;
    private Paddle computerPaddle;

    public TextMeshProUGUI redScoreText;
    public TextMeshProUGUI blueScoreText;
    private TextMeshProUGUI playerScoreText;
    private TextMeshProUGUI computerScoreText;

    public ScoringZone redZone;
    public ScoringZone blueZone;
    private ScoringZone playerZone;
    private ScoringZone computerZone;

    private int playerScore;
    private int computerScore;

    private void Start()
    {
        Time.timeScale = 0f; //Game pauses
        ui.ShowStartMenu();
    }

    //Setup
    public void ChooseRed()
    {
        SetupGame(redPaddle, bluePaddle, redScoreText, blueScoreText, redZone, blueZone);
    }

    public void ChooseBlue()
    {
        SetupGame(bluePaddle, redPaddle, blueScoreText, redScoreText, blueZone, redZone);
    }

    private void SetupGame(Paddle player, Paddle computer, TextMeshProUGUI playerText, TextMeshProUGUI computerText, ScoringZone playerScoringZone, ScoringZone computerScoringZone)
    {
        playerPaddle = player;
        computerPaddle = computer;

        playerScoreText = playerText;
        computerScoreText = computerText;

        playerZone = playerScoringZone;
        computerZone = computerScoringZone;

        playerPaddle.TogglePaddleType(Paddle.PaddleType.Player);
        computerPaddle.TogglePaddleType(Paddle.PaddleType.Computer);

        NewGame();
    }


    private void NewGame()
    {
        ui.HideStartMenu();
        ui.ShowHUD();
        Time.timeScale = 1f; //Game resumes
        SetPlayerScore(0);
        SetComputerScore(0);
    }
    public void NewRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();
        ball.AddStartingForce();
    }

    //Score
    public void PlayerScored()
    {
        SetPlayerScore(playerScore +1);
        NewRound();
    }
    public void ComputerScored()
    {
        SetComputerScore(computerScore +1);
        NewRound();
    }
    private void SetPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = score.ToString();
    }
    private void SetComputerScore(int score)
    {
        computerScore = score;
        computerScoreText.text = score.ToString();
    }

    public void EndGame()
    {
        Application.Quit();
    }

}
