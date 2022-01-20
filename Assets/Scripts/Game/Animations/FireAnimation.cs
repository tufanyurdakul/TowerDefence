using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimation : MonoBehaviour
{
    private float timer = 0.5f;
    private bool changing = false, changing2 , changing3;
    SpriteRenderer sr1, sr2, sr3 , sr4;
    // Start is called before the first frame update
    void Start()
    {
        GameObject anotherPic = Resources.Load("flame2") as GameObject;
        GameObject anotherPic2 = Resources.Load("flame3") as GameObject;
        GameObject anotherPic3 = Resources.Load("flame4") as GameObject;
        sr1 = gameObject.GetComponent<SpriteRenderer>();
        sr2 = anotherPic.GetComponent<SpriteRenderer>();
        sr3 = anotherPic2.GetComponent<SpriteRenderer>();
        sr4 = anotherPic3.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.4f && !changing)
        {
            sr1.sprite = sr2.sprite;
            changing = true;
        }
        else if (timer < 0.3f && timer > 0.15f &&!changing2)
        {
            sr1.sprite = sr3.sprite;
            changing2 = true;
        }
        else if (timer <= 0.15f)
        {
            if (timer <= 0 && changing2)
            {
                Destroy(gameObject);
            }
            else if (timer < 0.15f && !changing3)
            {
                sr1.sprite = sr4.sprite;
                changing3 = true;
            }
        }

    }
}
