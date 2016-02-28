using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float maxHp = 100;
    public float curHp = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (ListenClient.pos != null)
        {
            //Debug.Log(ListenClient.pos);
            string[] tempStr = ListenClient.pos.Split(' ');
            Vector3 tempVec = new Vector3(float.Parse(tempStr[0]) * 5, float.Parse(tempStr[1]), float.Parse(tempStr[2]) * 5);
            Debug.Log(tempVec.x + " " + tempVec.y + " "+tempVec.z);
            transform.position = tempVec;
        }
	}

    void hit()
    {
        curHp -= 5;
        if (curHp <= 0)
        {
            curHp = 0;
            Debug.Log("Player is dead");
        }
    }
}
