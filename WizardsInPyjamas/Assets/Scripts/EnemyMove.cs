using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed * Vector3.forward * Time.deltaTime);
	}
}
