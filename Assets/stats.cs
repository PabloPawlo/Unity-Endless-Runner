using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.name == "stat")
        {
            GetComponent<TextMesh>().text = "Coins: " + GM.coins;
        }
        if (gameObject.name == "stat1")
        {
            GetComponent<TextMesh>().text = "Time: " + GM.time;
        }
    }
}
