﻿using UnityEngine;
using System.Collections;

public class RandomEnemyGen : MonoBehaviour {

	public GameObject player;
	public GameObject model;
	public float secondsPerSpawn;
	public int maxEnemies;
	public bool flying;

	private float lastTime;
	private int numEnemies;

	// Use this for initialization
	void Start () {
		lastTime = Time.time;
		numEnemies = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > secondsPerSpawn + lastTime && numEnemies < maxEnemies) {
			lastTime = Time.time;
			numEnemies++;
            Vector3 pos;
			if(flying) {
				pos = player.transform.position + new Vector3(Random.value * 20 - 10, Random.value * 10, Random.value * 20 + 20);				
			} else {
				pos = player.transform.position + new Vector3(Random.value * 20 - 10, 0, Random.value * 20 + 20);
			}
            GameObject t = Instantiate(model);
            //pos, Quaternion.LookRotation((player.transform.position - pos).normalized));
            t.transform.position = pos;
            t.transform.rotation = Quaternion.Euler(0, 270, 0);
            //t.transform.LookAt(player.transform);

        }
	}

	public void kill(GameObject e) {
		Destroy (e, 0);
		numEnemies--;
	}
}
