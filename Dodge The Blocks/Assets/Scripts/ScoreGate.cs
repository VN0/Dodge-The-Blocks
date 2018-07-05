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
		if(col.GetComponent<Collider2D>().tag == "ScorePoint")
		{
			Debug.Log("Scored a point");
		}
	}
}
