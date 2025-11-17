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

    public ScoringZone redZone;
    public ScoringZone blueZone;

    private int redScore;
    private int blueScore;

    private bool isPaused = false;

    private void Start()
    {
        Time.timeScale = 0f; //Game pauses
        ui.ShowStartMenu();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ui.ResumeGame();
            else
                ui.PauseGame();
        }
    }

    //Setup
    public void ChooseRed()
    {
        SetupGame(redPaddle, bluePaddle);
    }

    public void ChooseBlue()
    {
        SetupGame(bluePaddle, redPaddle);
    }

    private void SetupGame(Paddle player, Paddle computer)
    {
        playerPaddle = player;
        computerPaddle = computer;

        playerPaddle.TogglePaddleType(Paddle.PaddleType.Player);
        computerPaddle.TogglePaddleType(Paddle.PaddleType.Computer);

        computerPaddle.sideDirection = (computerPaddle == bluePaddle) ? 1 : -1;


        NewGame();
    }


    private void NewGame()
    {
        ui.HideStartMenu();
        ui.ShowHUD();
        Time.timeScale = 1f; //Game resumes
        SetRedScore(0);
        SetBlueScore(0);
    }

    public void NewRound()
    {
        ball.ResetPosition();
        ball.AddStartingForce();
    }

    //Score
    public void RedScored()
    {
        SetRedScore(redScore +1);
        NewRound();
    }
    public void BlueScored()
    {
        SetBlueScore(blueScore +1);
        NewRound();
    }
    private void SetRedScore(int score)
    {
        redScore = score;
        redScoreText.text = score.ToString();
    }
    private void SetBlueScore(int score)
    {
        blueScore = score;
        blueScoreText.text = score.ToString();
    }

    public void EndGame()
    {
        Application.Quit();
    }

}
