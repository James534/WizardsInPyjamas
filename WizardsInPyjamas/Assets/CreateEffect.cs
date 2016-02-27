using UnityEngine;
using System.Collections;

public class CreateEffect : MonoBehaviour {

	public GameObject effect;

	private GameObject currentObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			currentObject = GameObject.Instantiate(effect);
			currentObject.transform.position = transform.position + transform.forward * 2;
		}
	}
}
