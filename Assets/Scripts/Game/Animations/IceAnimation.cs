using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAnimation : MonoBehaviour
{
    private float timer = 0.5f;
    private bool changing = false , changing2;
    SpriteRenderer sr1 , sr2 ,sr3;
    // Start is called before the first frame update
    void Start()
    {
        GameObject anotherPic = Resources.Load("ice2") as GameObject;
        GameObject anotherPic2 = Resources.Load("ice3") as GameObject;
        sr1 = gameObject.GetComponent<SpriteRenderer>();
        sr2 = anotherPic.GetComponent<SpriteRenderer>();
        sr3 = anotherPic2.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer >= 0.4f)
        {
            gameObject.transform.position += new Vector3(0.002f, 0, 0);
        }
        else if (timer < 0.4f && !changing)
        {
            sr1.sprite = sr2.sprite;
            changing = true;
        }
        else if (changing)
        {
            if (timer <= 0 && changing2)
            {
                Destroy(gameObject);
            }
            else if (timer < 0.2f && !changing2)
            {
                sr1.sprite = sr3.sprite;
                changing2 = true;
            }
        }
    }
}
