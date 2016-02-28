using UnityEngine;
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
			if(flying) {
				Vector3 pos = player.transform.position + new Vector3(Random.value * 20 - 10, Random.value * 10, Random.value * 20 + 20);
				Instantiate(model, pos, Quaternion.LookRotation((player.transform.position - pos).normalized));
			} else {
				Vector3 pos = player.transform.position + new Vector3(Random.value * 20 - 10, 0, Random.value * 20 + 20);
				Instantiate(model, pos, Quaternion.LookRotation((player.transform.position - pos).normalized));
			}
		}
	}

	public void kill(GameObject e) {
		Destroy (e, 0);
		numEnemies--;
	}
}
