using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool gameFinish;
    public static bool isGameStarted;
    public GameObject gameOverPanel;
    public GameObject gameFinishPanel;
    public GameObject startingText;
    public static int coinCount;
    public static int appleCount;
    public static int diamondCount;
    public static int starCount;
    public static int heartCount;
    public const int coinPoint = 1;
    public const int applePoint = 10;
    public const int diamondPoint = 15;
    public const int starPoint = 20;
    public const int heartPoint = 25;
    public Text coinsText;
    public Text applesText;
    public Text diamondsText;
    public Text heartsText;
    public Text starsText;
    public Text timeText;
    public Text scoreText;
    public Text resultText;
    public Text highScoreText;
    public Text lessTimeText;
    public Text resultFinishText;
    public Text scoreFinishText;
    public Text timeFinishText;
    public Text highScoreFinishText;
    public Text lessTimeFinishText;
    public static int score;
    public static float time;
    public static int highScore;
    public static float lessTime;

    void Start()
    {
        Time.timeScale = 1;
        gameOver = false;
        gameFinish = false;
        isGameStarted = false;
        coinCount = 0;
        appleCount = 0;
        diamondCount = 0;
        starCount = 0;
        heartCount = 0;
        score = 0;
        time = 0f;
    }
    void Update()
    {
        if (!isGameStarted && (SwipeManager.tap || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.S)))
        {
            isGameStarted = true;
            Destroy(startingText);
        }
        if (gameOver)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
        if (gameFinish)
        {
            gameFinishPanel.SetActive(true);
            Time.timeScale = 0f;
            //FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
        if (isGameStarted)
        {
            time += 1 * Time.deltaTime;
            timeText.text = timeFinishText.text = time.ToString("00.0");
        }
        coinsText.text = coinCount.ToString();
        applesText.text = appleCount.ToString();
        diamondsText.text = diamondCount.ToString();
        starsText.text = starCount.ToString();
        heartsText.text = heartCount.ToString();
        score = (coinCount * coinPoint) +
                (appleCount * applePoint) +
                (diamondCount * diamondPoint) +
                (starCount * starPoint) +
                (heartCount * heartPoint);
        scoreText.text = scoreFinishText.text = score.ToString();
        resultText.text = resultFinishText.text =
            "\n ~ HEART(S): " + heartCount.ToString()
            + " ~ STAR(S): " + starCount.ToString()
            + " ~ DIAMOND(S): " + diamondCount.ToString() + " ~ "
            + "\n ~ APPLE(S): " + appleCount.ToString()
            + " ~ COIN(S): " + coinCount.ToString() + " ~ "
            + "\n ~ YOUR SCORE (POINT): " + score.ToString() + " ~ YOUR TIME (SECOND): " + time.ToString("00.0") + " ~ ";
       
        if (gameFinish)
        {
            if (score > highScore)
            {
                highScore = score;
                highScoreText.text = highScoreFinishText.text = "NEW HIGH SCORE (POINT): " + highScore.ToString() + "";
            }
            
            if (lessTime == 0f)
            {
                lessTime = time;
                lessTimeText.text = lessTimeFinishText.text = "NEW LESS TIME (SECOND): " + lessTime.ToString("00.0") + "";
            }
            if (time < lessTime && lessTime != 0f && time != 0f)
            {
                lessTime = time;
                lessTimeText.text = lessTimeFinishText.text = "NEW LESS TIME (SECOND): " + lessTime.ToString("00.0") + "";
            }
            return;
        }
        highScoreText.text = highScoreFinishText.text = "HIGH SCORE (POINT): " + highScore.ToString() + "";
        lessTimeText.text = lessTimeFinishText.text = "LESS TIME (SECOND): " + lessTime.ToString("00.0") + "";
    }
}
