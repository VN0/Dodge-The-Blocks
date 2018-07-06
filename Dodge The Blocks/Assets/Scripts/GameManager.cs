/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance; //implementing a singleton pattern

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
	}

	void Update()
	{
		if(freezeBlocks)
		{
			ReloadLevel();
		}
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
		freezeBlocks = true; //the blocks are frozen only AFTER the slow mmotion effect completes execution
	}

	void ReloadLevel()
	{
		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
