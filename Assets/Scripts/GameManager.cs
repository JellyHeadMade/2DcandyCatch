using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverPanel;

    int Lives = 3;

    public static GameManager instance;

    int Score = 0;

    bool gameOver = false;

    private void Awake()
    {
        instance = this;
    }

    public Text livesCount;

    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncrementScore()
    {
        if (!gameOver)
        {
            Score++;
            scoreText.text = Score.ToString();
            print(Score);
        }
        
    }

    public void DecreaseLife()
    {

        

        if (Lives > 0)
        {
            Lives--;
            livesCount.text = Lives.ToString();
            //print(Lives);
        }

        if(Lives <= 0)
        {
            gameOver = true;

            GameOver();
        }
    }

    public void GameOver()
    {
        CandySpawner.instance.StopSpawningCandies();

        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;

        print("GameOver");

        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
