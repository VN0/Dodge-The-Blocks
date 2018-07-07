/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
	void Update()
	{
		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("Got input");
			SceneManager.LoadScene(1);
		}
	}
}
