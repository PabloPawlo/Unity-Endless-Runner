using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {
    public static float vertVel = 0;

    public static float coins = 0;

    public static float level = 1;

    public static float time = 0;

    public static float zVelAdj = 1; //dostosowanie predkosci na osi OZ

    public float waitToLoad = 0;

    public string lvlStatus = "";

    public static
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (lvlStatus =="Fail")
        {
            waitToLoad += Time.deltaTime;
        }
        if (waitToLoad > 2) SceneManager.LoadScene("levelComp");
	}
}
