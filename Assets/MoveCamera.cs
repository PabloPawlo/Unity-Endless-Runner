using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start ()
    {
        offset = transform.position - player.transform.position;
        //GetComponent<Rigidbody>().velocity = new Vector3(2*GM.zVelAdj, GM.vertVel, 0);	
	}



    // Update is called once per frame
    void Update ()
    {
		transform.position = player.transform.position + offset;
	}
}
