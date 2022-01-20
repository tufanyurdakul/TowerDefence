using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    private float deleteTimer = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deleteTimer -= Time.deltaTime;
        if (deleteTimer <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            if (gameObject.tag == "physical")
                
            {
                gameObject.transform.position += new Vector3(0.005f, 0f, 0);
            }
            else 
            {
                gameObject.transform.position += new Vector3(0.006f, 0.005f, 0);
                
            }
            gameObject.transform.localScale += new Vector3(-0.001f, -0.001f, 0);
        }
    }
}
