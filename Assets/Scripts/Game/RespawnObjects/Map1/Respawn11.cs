using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn11 : MonoBehaviour
{
    // Start is called before the first frame update
    private float respawnTime, respawnTimer,totalTimer;
    private GameObject boxOne, boxTwo, boxThree, boxFour, boxFive, boxSix, boxBoss1, boxBoss2, background;
    private IdGenerator id;
    private int idOfBoxes;
    private bool sendBossVawe1, sendBossVawe2;
    // Start is called before the first frame update
    enum Wawe
    {
        first = 100,
        second = 200,
        third = 300,
        fourth = 400,
        fifth = 500,
        sixth = 600,
        seventh = 700,
        eighth = 800,
        nineth = 900,
        tenth = 1000
    }
    enum Time
    {
        first = 3,
        second = 3,
        three = 2,
        fourth = 2,
        fifth = 3,
        sixth = 3,
        seventh = 2,
        eighth = 3,
        nineth = 3,
        tenth = 3
    }

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
        boxBoss1 = Resources.Load("boxBossOne") as GameObject;
        boxBoss2 = Resources.Load("boxBossSecond") as GameObject;
        totalTimer = id.timer;
        StartCoroutine(CreateEnemy(respawnTime));
        respawnTime = 3;
        respawnTimer = respawnTime;
    }
    private IEnumerator CreateEnemy(float timer)
    {
        yield return new WaitForSeconds(timer);
        if (totalTimer < (int)Wawe.first)
            FirstWave();
        else if (totalTimer >= (int)Wawe.first && totalTimer < (int)Wawe.second)
            SecondWave();
        else if (totalTimer >= (int)Wawe.second && totalTimer < (int)Wawe.third)
            ThirdWave();
        else if (totalTimer >= (int)Wawe.third && totalTimer < (int)Wawe.fourth)
            FourthWave();
        else if (totalTimer >= (int)Wawe.fourth && totalTimer < (int)Wawe.fifth)
            FifthWave();
        else if (totalTimer >= (int)Wawe.fifth && totalTimer < (int)Wawe.sixth)
            SixthWave();
        else if (totalTimer >= (int)Wawe.sixth && totalTimer < (int)Wawe.seventh)
            SeventhWave();
        else if (totalTimer >= (int)Wawe.seventh && totalTimer < (int)Wawe.eighth)
            EighthWave();
        else if (totalTimer >= (int)Wawe.eighth && totalTimer < (int)Wawe.nineth)
            NinethWave();
        else if (totalTimer >= (int)Wawe.nineth && totalTimer < (int)Wawe.tenth)
            TenthWave();

    }
    private void FirstWave()
    {
        Instantiate(boxOne, gameObject.transform.position, Quaternion.identity);
        StartCoroutine(CreateEnemy((float)Time.first));
    }
    private void SecondWave()
    {
        Instantiate(boxTwo, gameObject.transform.position, Quaternion.identity);
        StartCoroutine(CreateEnemy((float)Time.second));
    }
    private void ThirdWave()
    {
        int which = Random.Range(0, 2);
        if (which == 0)
            Instantiate(boxOne, gameObject.transform.position, Quaternion.identity);
        else
            Instantiate(boxTwo, gameObject.transform.position, Quaternion.identity);
        StartCoroutine(CreateEnemy((float)Time.three));
    }
    private void FourthWave()
    {
        Instantiate(boxTwo, gameObject.transform.position, Quaternion.identity);
        StartCoroutine(CreateEnemy((float)Time.fourth));
    }
    private void FifthWave()
    {
        Instantiate(boxThree, gameObject.transform.position, Quaternion.identity);
        StartCoroutine(CreateEnemy((float)Time.fifth));
    }
    private void SixthWave()
    {
        int which = Random.Range(0, 2);
        if (which == 0)
            Instantiate(boxTwo, gameObject.transform.position, Quaternion.identity);
        else
            Instantiate(boxThree, gameObject.transform.position, Quaternion.identity);
        StartCoroutine(CreateEnemy((float)Time.sixth));
    }
    private void SeventhWave()
    {
        Instantiate(boxThree, gameObject.transform.position, Quaternion.identity);
        StartCoroutine(CreateEnemy((float)Time.seventh));
    }
    private void EighthWave()
    {
        int which = Random.Range(0, 2);
        if (which == 0)
            Instantiate(boxThree, gameObject.transform.position, Quaternion.identity);
        else
            Instantiate(boxFour, gameObject.transform.position, Quaternion.identity);
        StartCoroutine(CreateEnemy((float)Time.eighth));
    }
    private void NinethWave()
    {
        Instantiate(boxFour, gameObject.transform.position, Quaternion.identity);
        StartCoroutine(CreateEnemy((float)Time.nineth));
    }
    private void TenthWave()
    {
        int which = Random.Range(0, 5);
        if (which == 0)
            Instantiate(boxThree, gameObject.transform.position, Quaternion.identity);
        else if(which == 1)
            Instantiate(boxFive, gameObject.transform.position, Quaternion.identity);
        else 
            Instantiate(boxFour, gameObject.transform.position, Quaternion.identity);
        StartCoroutine(CreateEnemy((float)Time.tenth / 2));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
