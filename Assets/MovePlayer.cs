using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public Text level;
    public Text coins;
    public Text time;
    public KeyCode moveL, moveR, moveW, moveS;
    public float counter = 0;
    public float horVelocity = 0;
    public int laneNum = 2;
    public bool controlLocked = false;
    public float forback = 0;
    public GameObject man;
    public GameObject coin;   



    void Update()
    {
        time.text = "Time: " + GM.time;


        GetComponent<Rigidbody>().velocity = new Vector3(2, GM.vertVel, horVelocity);


        if (Input.GetKeyDown(moveR) && !controlLocked && laneNum > 1)
        {
            horVelocity -= 2;
            laneNum -= 1;
            controlLocked = true;
            StartCoroutine(stopSlide());

        }
        if (Input.GetKeyDown(moveL) && !controlLocked && laneNum < 3)
        {
            horVelocity += 2;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLocked = true;
        }/*
        if (Input.GetKeyDown(moveW) && !controlLocked )
        {
            forback += 1;
            StartCoroutine(stopSlide());
            controlLocked = true;
        }
        if (Input.GetKeyDown(moveS) && !controlLocked )
        {
            forback -= 1;
            StartCoroutine(stopSlide());
            controlLocked = true;
        }*/
    }
    public Transform boomObj;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "lethal")
        {
            Destroy(gameObject);
            GM.zVelAdj = 0;
            Instantiate(boomObj, transform.position, boomObj.rotation);
            time.text = "Press R to restart";
        }
        if (collision.gameObject.tag == "coin")
        {
            GM.coins++;
            coins.text = "Coins:"+ GM.coins;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "bridge")
        {
            GM.vertVel = 1;
            Debug.Log(GM.vertVel);
        }
        if (collision.gameObject.name == "bridgedown")
        {
            GM.vertVel = 0;
            Debug.Log(GM.vertVel);
        }
        if (collision.gameObject.name == "End")
        {
            GM.level++;
            level.text = "Level: " + GM.level;
            horVelocity = 0;
            controlLocked = false;
            GM.vertVel = 0;
            Debug.Log(GM.vertVel);
            GameObject startposition = GameObject.Find("start");
            transform.position = startposition.transform.position;
            GameObject[] randomObjects = GameObject.FindGameObjectsWithTag("lethal");
            GameObject[] moveObjects = GameObject.FindGameObjectsWithTag("move");
            foreach (var cos in randomObjects)
            {
                cos.transform.position = new Vector3(cos.transform.position.x, cos.transform.position.y, 2 + Random.Range(-1, 2));
            }
            foreach (var cos in moveObjects)
            {
                cos.transform.position = new Vector3(cos.transform.position.x, cos.transform.position.y, 2 + Random.Range(-1, 2));
            }


            for(int i=0;i<5;i++)
            {
                var monieta = new Vector3(Random.Range(-3f, 8f), 1, Random.Range(0.5f, 3));

                Instantiate(coin, monieta, Quaternion.identity);

            }


        }
    }




    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.5f);
        horVelocity = 0;
        controlLocked = false;
    }



}
