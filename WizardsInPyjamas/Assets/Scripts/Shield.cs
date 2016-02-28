using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (ListenClient.pos != null)
        {
            //Debug.Log(ListenClient.pos);
            string temp = ListenClient.pos.Split('@')[0];
            string[] tempStr = temp.Split(' ');
            Vector3 tempVec = new Vector3(float.Parse(tempStr[0]) * 5, float.Parse(tempStr[1]), float.Parse(tempStr[2]) * 5);
            //Debug.Log(tempVec.x + " " + tempVec.y + " " + tempVec.z);
            transform.position = tempVec;
        }
    }
}
