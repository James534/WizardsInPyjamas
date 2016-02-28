using UnityEngine;
using System.Collections;

public class CreateEffect : MonoBehaviour {

	public GameObject effect;
    public GameObject special;
    Player p;

    private GameObject player;

    private GameObject currentObject;
    private GameObject currentSpecial;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        p = player.GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			currentObject = GameObject.Instantiate(effect);
			currentObject.transform.position = transform.position + transform.forward * 2;
		}
        if (p.curMana >= p.maxMana && Input.GetKeyDown (KeyCode.LeftShift))
        {
            currentSpecial = GameObject.Instantiate(special);
            currentSpecial.transform.position = transform.position + new Vector3(0,0,30);
            p.curMana -= p.maxMana;
        }
    }
}
