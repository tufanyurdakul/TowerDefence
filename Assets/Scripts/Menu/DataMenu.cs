using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMenu : MonoBehaviour
{
    public GameObject bg;
    // Start is called before the first frame update
    void Start()
    {
        float mySize = 1.775919732441472f;
        float z = (float)Screen.height / Screen.width;
        float z2 = (float)Screen.width / Screen.height;
        float x2 = z2 / mySize;
        float x = z / mySize;
        float y = mySize / z;
        bg.transform.localScale = new Vector3(bg.transform.localScale.x * x2, bg.transform.localScale.y, bg.transform.localScale.z);
    }
}
