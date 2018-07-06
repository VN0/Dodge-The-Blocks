/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
	public Transform[] spawnPoints;

	public GameObject blockPrefab;
	public GameObject scorePointPrefab;

	[SerializeField]
	private float _timeToSpawn = 2f;
	[SerializeField]
	private float _timeBetweenWaves = 1f;
	
	void Update () 
	{
		if(GameManager.instance.gameOver == false)
		{
			if(Time.time >= _timeToSpawn)
			{
				SpawnBlocks();
				_timeToSpawn = Time.time + _timeBetweenWaves;
			}
		}
	}

	void SpawnBlocks()
	{
		int randomIndex = Random.Range(0, spawnPoints.Length);

		for(int i = 0; i < spawnPoints.Length; i++)
		{
			if(i != randomIndex)
			{
				Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
			}
			else
			{
				Instantiate(scorePointPrefab, spawnPoints[i].position, Quaternion.identity);
			}
		}
	}
}
