using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hp : MonoBehaviour
{
    int hp;
    private DeleteBoxes deleteBoxes;
    private TextMeshPro tmpHp;
    // Start is called before the first frame update
    void Start()
    {
        GameObject generator = GameObject.Find("DeleteBoxes");
        tmpHp = gameObject.GetComponent<TextMeshPro>();
        deleteBoxes = generator.GetComponent<DeleteBoxes>();
        hp = deleteBoxes.yourHealth;
        set(hp);
    }

    // Update is called once per frame
    void Update()
    {
        if (deleteBoxes.yourHealth > hp)
        {
            hp++;
            set(hp);
        }
        else if (deleteBoxes.yourHealth < hp)
        {
            hp--;
            set(hp);
        }
    }
    private void set(int hp)
    {
        tmpHp.SetText("" + hp);
    }
}
