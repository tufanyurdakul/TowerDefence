using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn5 : MonoBehaviour
{
    private float respawnTime, respawnTimer;
    private GameObject boxOne, boxTwo, boxThree, boxFour, boxFive, boxBoss1, background;
    private IdGenerator id;
    private int idOfBoxes;
    private float timer = 0;
    private bool sendBossVawe1;
    // Start is called before the first frame update
    void Start()
    {
        GameObject idgenerator = GameObject.Find("IdGenerator");
        id = idgenerator.GetComponent<IdGenerator>();
        idOfBoxes = id.id;
        background = GameObject.Find("BackGround");
        boxOne = Resources.Load("boxOne") as GameObject;
        boxTwo = Resources.Load("boxTwo") as GameObject;
        boxThree = Resources.Load("boxThree") as GameObject;
        boxFour = Resources.Load("boxFour") as GameObject;
        boxFive = Resources.Load("boxFive") as GameObject;
        boxBoss1 = Resources.Load("boxBossOne") as GameObject;
        timer = id.timer;


        respawnTime = 3;
        respawnTimer = respawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer = id.timer;
        respawnTimer -= Time.deltaTime;
        if (respawnTimer <= 0)
        {
            GameObject idgenerator = GameObject.Find("IdGenerator");
            id = idgenerator.GetComponent<IdGenerator>();
            idOfBoxes = id.id;
            GameObject copyBox = null;
            if (timer >= 320 && timer <= 360)
            {
                copyBox = Instantiate(boxOne, gameObject.transform.position, gameObject.transform.rotation);
                respawnTimer = 1;
            }
            else if (timer >= 360 && timer <= 450)
            {
                copyBox = Instantiate(boxThree, gameObject.transform.position, gameObject.transform.rotation);
                respawnTimer = 4;
            }
            else if (timer > 450 && timer <= 500)
            {
                copyBox = Instantiate(boxThree, gameObject.transform.position, gameObject.transform.rotation);
                respawnTimer = 0.44f;
            }
            else if (timer >= 545 && timer < 600)
            {
                int random = getRandom(0, 4);
                if (random == 0)
                {
                    copyBox = Instantiate(boxFive, gameObject.transform.position, gameObject.transform.rotation);
                    respawnTimer = 3;

                }
                else if (random == 1 || random == 2)
                {
                    copyBox = Instantiate(boxFour, gameObject.transform.position, gameObject.transform.rotation);
                    respawnTimer = 1;
                }
                else
                {
                    copyBox = Instantiate(boxThree, gameObject.transform.position, gameObject.transform.rotation);
                    respawnTimer = 0.4f;
                }
            }
            else if (timer >= 600 && timer < 700)
            {
                int random = getRandom(0, 3);
                if (random == 0 || random == 2)
                {
                    copyBox = Instantiate(boxFour, gameObject.transform.position, gameObject.transform.rotation);
                }
                else if (random == 1)
                {
                    copyBox = Instantiate(boxFive, gameObject.transform.position, gameObject.transform.rotation);
                }
                respawnTimer = 1.25f;
            }
            else if (timer >= 710 && timer < 800)
            {
                copyBox = Instantiate(boxFive, gameObject.transform.position, gameObject.transform.rotation);
                respawnTimer = 3;

            }
            else if (timer >= 800 && timer < 900)
            {
                copyBox = Instantiate(boxFive, gameObject.transform.position, gameObject.transform.rotation);
                respawnTimer = 2;

            }
            if (copyBox != null)
            {
                copyBox.transform.SetParent(background.transform);
                BoxesOnHit boh = copyBox.GetComponent<BoxesOnHit>();
                boh.boxID = idOfBoxes;
                id.id += 1;
            }

        }
    }
    private int getRandom(int lower, int higher)
    {
        int rndm = Random.Range(lower, higher);
        return rndm;
    }
}
