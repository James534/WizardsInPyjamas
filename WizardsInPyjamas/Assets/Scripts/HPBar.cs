﻿using UnityEngine;
using System.Collections;

public class HPBar : MonoBehaviour {
    Player p;
    // Use this for initialization
    void Start()
    {
        GameObject temp = GameObject.Find("Player");
        p = temp.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;
        scale.x = p.curHp / p.maxHp;
        transform.localScale = scale;
    }
}
