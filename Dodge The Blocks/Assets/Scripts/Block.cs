/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	public float gravityScaleFactor = 20f;

	void Start()
	{
		GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad/gravityScaleFactor;
	}

	void Update()
	{
		if(transform.position.y < -2f)
		{
			Destroy(gameObject);
		}
	}
}
