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
	public Text scoreText;
	private int _score;

	public float slowDownFactor = 10f;
	public float slowMotionTime = 1f;
	public bool gameOver = false;
	public bool freezeBlocks = false;

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
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
	}

	void Update()
	{
		if(freezeBlocks)
		{
			ReloadLevel();
		}
	}

	public void playerScored()
	{
		_score++;

		scoreText.text = "Score: " + _score;
	}

	public void EndGame()
	{
		gameOver = true;
		StartCoroutine(SlowDownAndStop());
	}

	IEnumerator SlowDownAndStop()
	{
		//before 1 sec
		Time.timeScale = 1 / slowDownFactor;
		Time.fixedDeltaTime = Time.fixedDeltaTime/slowDownFactor;

		yield return new WaitForSeconds(slowMotionTime / slowDownFactor);

		//after 1 sec
		Time.timeScale = 1f;
		Time.fixedDeltaTime = Time.fixedDeltaTime * slowDownFactor;
		freezeBlocks = true; //the blocks are frozen only AFTER the slow motion effect completes execution
		gameOverText.SetActive(true);
		restartText.SetActive(true);
	}

	void ReloadLevel()
	{
		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
