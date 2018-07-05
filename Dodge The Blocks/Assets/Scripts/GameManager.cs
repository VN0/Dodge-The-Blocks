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
		//GameManager.instance.function();
	}

	public void EndGame()
	{
		StartCoroutine(RestartLevel());
	}

	IEnumerator RestartLevel()
	{
		//before 1 sec
		Time.timeScale = 1 / slowDownFactor;
		Time.fixedDeltaTime = Time.fixedDeltaTime/slowDownFactor;

		yield return new WaitForSeconds(1f / slowDownFactor);

		//after 1 sec
		Time.timeScale = 1f;
		Time.fixedDeltaTime = Time.fixedDeltaTime * slowDownFactor;

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
