using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject small_enemy;
	public float small_enemy_spawn_interval = 1.0f;
	public GameObject large_enemy;
	public float large_enemy_spawn_interval;
 
	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnSmallEnemy", 0, small_enemy_spawn_interval);
	}

	void SpawnSmallEnemy () {

		Vector3 spawnPosition = transform.position;

		spawnPosition.x = Random.Range(-8.0f, 8.0f);

		Instantiate (small_enemy, spawnPosition, Quaternion.identity);
		
	}

}
