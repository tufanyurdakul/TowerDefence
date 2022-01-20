using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn2 : MonoBehaviour
{
    private float respawnTime, respawnTimer;
    private GameObject boxOne,boxTwo,boxThree,boxFour, boxFive, boxSix,boxBoss2, background;
    private IdGenerator id;
    private int idOfBoxes;
    private float timer = 0;
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
        boxSix = Resources.Load("boxSix") as GameObject;

        boxBoss2 = Resources.Load("boxBossSecond") as GameObject;
        timer = id.timer;

        respawnTime = 1;
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
            if (timer <= 60)
            {
                copyBox = Instantiate(boxOne, gameObject.transform.position, gameObject.transform.rotation);

            }
            else if (timer > 60 && timer <= 200)
            {
                copyBox = Instantiate(boxTwo, gameObject.transform.position, gameObject.transform.rotation);
            }
            else if(timer > 200 && timer <= 300)
            {
                copyBox = Instantiate(boxThree, gameObject.transform.position, gameObject.transform.rotation);

            }
            else if (timer >= 320 && timer <= 400)
            {
                copyBox = Instantiate(boxThree, gameObject.transform.position, gameObject.transform.rotation);

            }
            else if (timer > 400 && timer <= 500)
            {
                copyBox = Instantiate(boxFour, gameObject.transform.position, gameObject.transform.rotation);

            }
            else if (timer >= 515 && timer < 530)
            {
                copyBox = Instantiate(boxBoss2, gameObject.transform.position, gameObject.transform.rotation);
            }
            else if (timer >= 545 && timer < 700)
            {
                copyBox = Instantiate(boxFive, gameObject.transform.position, gameObject.transform.rotation);
            }
            else if (timer >= 710 && timer < 900)
            {
                int random = getRandom(0, 5);
                if (random == 0)
                {
                    copyBox = Instantiate(boxSix, gameObject.transform.position, gameObject.transform.rotation);
                }
                else
                {
                    copyBox = Instantiate(boxFive, gameObject.transform.position, gameObject.transform.rotation);

                }
            }
            if (copyBox != null)
            {
                copyBox.transform.SetParent(background.transform);
                BoxesOnHit boh = copyBox.GetComponent<BoxesOnHit>();
                boh.boxID = idOfBoxes;
                id.id += 1;
            }
           

            respawnTimer = SetRespawnTimer((int)timer);
        }
    }
    private float SetRespawnTimer(int time)
    {
        float timeIs = 0;
        if (time > 0 && time <= 60)
        {
             timeIs = Random.Range(3, 7);

        }
        else if (time > 60 && time <= 200)
        {
            timeIs = Random.Range(3, 6);

        }
        else if (time > 200 && time <= 240)
        {
            timeIs = Random.Range(2, 7);

        }
        else if ((time > 240 && time <= 300))
        {
            timeIs = Random.Range(1, 4);
        }
        else if ((time >= 320 && time <= 360))
        {
            timeIs = Random.Range(1, 3);

        }
        else if ((time > 360 && time <= 400))
        {
            float x = Random.Range(0, 10);
            timeIs = 0.1f * x;

        }
        else if ((time > 400 && time <= 500))
        {
            float x = Random.Range(0, 8);
            timeIs = 0.8f + (x * 0.1f);

        }
        else if (timer >= 515 && timer < 530)
        {
            timeIs = 5;
        }
        else if (timer >= 545 && timer < 600)
        {
            timeIs = 4;
        }
        else if (timer >= 600 && timer < 700)
        {
            timeIs = 2;
        }
        else if (timer >= 700 && timer < 800)
        {
            timeIs = 5;
        }
        else if (timer >= 800 && timer < 900)
        {
            timeIs = 3;
        }
        return timeIs;
    }
    private int getRandom(int lower, int higher)
    {
        int rndm = Random.Range(lower, higher);
        return rndm;
    }
}
