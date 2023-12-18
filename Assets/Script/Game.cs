using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Game : MonoBehaviour
{

    public TextMeshProUGUI score;
    public TextMeshProUGUI countDown;
    public TextMeshProUGUI mainGameTimer;
    public TextMeshProUGUI PlayerName;
    public GameObject countDownGameObject;
    private int redScore = 0;
    private int greenScore = 0;
    public GameObject ball;
    private Ball ballScript;
    private float timer = 4;
    bool timerStarted=false;
    private float gameTimer = 120;
    bool gameStarted = false;
    
    public GameObject victory, defeat;
    private void Start()
    {
        ballScript = ball.GetComponent<Ball>();
        countDownGameObject.SetActive(true);
        mainGameTimer.text = "02:00";
        victory.SetActive(false);
        defeat.SetActive(false);
        PlayerName.text = PlayerPrefs.GetString("PlayerName");
    }
    private void Update()
    {
        if (timerStarted)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Loading");
            }
        }
        if (gameStarted)
        {
            gameTimer -= Time.deltaTime;
            int m = Mathf.FloorToInt(gameTimer) / 60;
            int s = Mathf.FloorToInt(gameTimer) % 60;
            if (s < 10)
            {
                mainGameTimer.text = "0" + m + ":" + "0"+s;
            }
            else
            {
                mainGameTimer.text = "0" + m + ":" + s;
            }
            if (m == 0 && s == 0)
            {
                gameStarted = false;
                displayResult();
            }



        }
        if (timerStarted)
        {
            timer -= Time.deltaTime;
            countDown.text = Mathf.FloorToInt(timer).ToString();
        }
        if (timer <= 0)
        {
            timerStarted = false;
            TimerEnd();
            countDownGameObject.SetActive(false);
        }
        
    }
    public void IncreaseRedScore()
    {
        redScore++;
        score.text = redScore + " - " + greenScore;
    }


    public void IncreaseGreenScore()
    {
        greenScore++;
        score.text = redScore + " - " +greenScore;
    }

    public void TimerStart()
    { 
        timerStarted = true;
        timer = 4;
        countDown.text = timer.ToString();
        countDownGameObject.SetActive(true);
        gameStarted = true;
    }

    public void TimerEnd()
    {
        timer = 4;
        ballScript.addForce();
    }

    public void MainStart()
    {
        TimerStart();
    }

    public void displayResult()
    {
        Time.timeScale = 0;
        if (redScore >= greenScore)
        {
            victory.SetActive(true);
        }
        else
        {
            defeat.SetActive(true);
        }
        
        
    }
}
