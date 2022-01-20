using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteBoxes : MonoBehaviour
{
    public int yourHealth { get; set; }
    public int maxHealth { get; private set; }
    
    private bool isOver = false;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        yourHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (yourHealth <= 0 && !isOver)
        {
            isOver = true;
            SceneManager.LoadScene("Menu");
        }
    }
}
