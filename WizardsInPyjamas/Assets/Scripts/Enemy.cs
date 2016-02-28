using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject projectile;
	public int minShotInterval;
	public float damage;
	public float angleVariance;
	
	private GameObject player;
	private float lastTime;
	
	// Use this for initialization
	void Start () {
		lastTime = Time.time;
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > minShotInterval + lastTime + Random.value * 6 - 3) {
			lastTime = Time.time;
			Vector3 pos = transform.position + transform.forward;
			Vector3 rand = new Vector3(Random.value * angleVariance - angleVariance/2, Random.value * angleVariance - angleVariance/2, Random.value * angleVariance - angleVariance/2);
			Instantiate(projectile, pos, Quaternion.LookRotation((player.transform.position - pos + rand).normalized));
		}
	}

	public void hit()
	{
		GameObject.Find ("GameObject").gameObject.GetComponent<RandomEnemyGen> ().kill (this.gameObject);
	}
}
