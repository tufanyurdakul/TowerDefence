using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn6 : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject boxFive,background;
    private float respawnTime, respawnTimer, timer;
    private IdGenerator id;
    private int idOfBoxes;
    void Start()
    {
        GameObject idgenerator = GameObject.Find("IdGenerator");
        background = GameObject.Find("BackGround");
        id = idgenerator.GetComponent<IdGenerator>();
        boxFive = Resources.Load("boxFive") as GameObject;
        respawnTime = 10;
        respawnTimer = respawnTime;
        timer = id.timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer = id.timer;
        if (timer > 700)
        {
            GameObject idgenerator = GameObject.Find("IdGenerator");
            id = idgenerator.GetComponent<IdGenerator>();
            idOfBoxes = id.id;
            GameObject copyBox = null;
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0)
            {
                if (timer >= 710 && timer < 800)
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
    }
}
