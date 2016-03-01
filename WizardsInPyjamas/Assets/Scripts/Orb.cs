using UnityEngine;
using System.Collections;

public class Orb : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (ListenClient.pos != null)
        {
            //Debug.Log(ListenClient.pos);
            string temp = ListenClient.pos.Split('@')[2];
            string[] tempStr = temp.Split(' ');
            Vector3 tempVec = new Vector3(float.Parse(tempStr[0]) * 5, float.Parse(tempStr[1]) * 5, float.Parse(tempStr[2]) * 5 + 3);
            //Debug.Log(tempVec.x + " " + tempVec.y + " " + tempVec.z);
            transform.position = tempVec;
        }
    }
}
