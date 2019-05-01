/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //implementing a singleton pattern
    public GameObject gameOverText;
    public GameObject restartText;
    public GameObject topScoreText;
    public Text scoreText;
    private int _score;

    public float slowDownFactor = 10f;
    public float slowMotionTime = 1f;
    public bool gameOver = false;
    public bool freezeBlocks = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        freezeBlocks = false;
        gameOver = false;
        gameOverText.SetActive(false);
        restartText.SetActive(false);
        _score = 0;

        Text dummytext = topScoreText.GetComponent<Text>();
        dummytext.text = PlayerPrefs.GetInt("TopScore", 0).ToString();
    }

    void Update()
    {
        if (freezeBlocks)
        {
            ReloadLevel();
        }
    }

    public void playerScored()
    {
        if (gameOver)
        {
            return;
        }

        _score++;

        scoreText.text = "Score: " + _score.ToString();
    }

    public void topScore()
    {
        if (_score > PlayerPrefs.GetInt("TopScore", 0))
        {
            PlayerPrefs.SetInt("TopScore", _score);
            Text dumText = topScoreText.GetComponent<Text>();
            dumText.text = "Top Score: " + _score.ToString();
            topScoreText.SetActive(true);
        }
        else
        {
            Text dumText = topScoreText.GetComponent<Text>();
            dumText.text = "Top Score: " + PlayerPrefs.GetInt("TopScore").ToString();
            topScoreText.SetActive(true);
        }
    }

    public void EndGame()
    {
        gameOver = true;
        AudioManager.instance.Play("GameOver");
        StartCoroutine(SlowDownAndStop());
    }

    IEnumerator SlowDownAndStop()
    {
        //before 1 sec
        Time.timeScale = 1 / slowDownFactor;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowDownFactor;
        AudioManager.instance.Play("GameOver");

        yield return new WaitForSeconds(slowMotionTime / slowDownFactor);

        //after 1 sec
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowDownFactor;
        freezeBlocks = true; //the blocks are frozen only AFTER the slow motion effect completes execution
        gameOverText.SetActive(true);
        restartText.SetActive(true);
        topScore();
    }

    void ReloadLevel()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
