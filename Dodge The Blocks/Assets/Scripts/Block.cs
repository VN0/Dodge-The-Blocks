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
	public Rigidbody2D rb;
	
	void Start()
	{
		GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad/gravityScaleFactor;
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		if(transform.position.y < -2f)
		{
			Destroy(gameObject);
		}
		if(GameManager.instance.gameOver == true)
		{
			if(GameManager.instance.freezeBlocks == true)
			{
				if(rb != null)
				{
					rb.constraints = RigidbodyConstraints2D.FreezeAll;
				}
			}
		}
	}
}
