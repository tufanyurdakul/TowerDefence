using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public GameObject bg, skills;
    void Start()
    {
        //GameObject environment1 = Resources.Load("Environment0") as GameObject;
        //GameObject copyEnv = Instantiate(environment1, bg.transform.position, Quaternion.identity);

        //copyEnv.transform.SetParent(bg.transform);

        //copyEnv.transform.localScale = new Vector3(1, 1, 1);

        float mySize = 1.775919732441472f;
        float z = (float)Screen.height / Screen.width;
        float z2 = (float)Screen.width / Screen.height;
        float x2 = z2 / mySize;
        float x = z / mySize;
        float y = mySize / z;
        bg.transform.localScale = new Vector3(bg.transform.localScale.x * x2, bg.transform.localScale.y, bg.transform.localScale.z);
        skills.transform.position = new Vector3(skills.transform.position.x - skills.transform.position.x * x, skills.transform.position.y, skills.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
