/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGate : MonoBehaviour
{
	public void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "ScorePoint")
		{
			if(GameManager.instance.gameOver == false)
			{
				GameManager.instance.playerScored();
				AudioManager.instance.Play("ScorePoint");
			}
		}
	}
}
