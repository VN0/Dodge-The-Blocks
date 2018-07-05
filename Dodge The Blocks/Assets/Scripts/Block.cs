/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	void Update()
	{
		if(transform.position.y < -2f)
		{
			Destroy(gameObject);
		}
	}
}
