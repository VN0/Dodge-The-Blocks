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
		yield return new WaitForSeconds(1f);
		//after 1 sec
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
