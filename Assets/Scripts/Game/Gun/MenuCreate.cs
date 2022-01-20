using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuCreate : MonoBehaviour
{
    // Start is called before the first frame update
    private List<SpriteRenderer> weapons;
    private List<int> weaponsMoney;

    void Start()
    {
        weapons = new List<SpriteRenderer>();
        weaponsMoney = new List<int>();
        for (int i = 1; i < 7; i++)
        {
            weapons.Add((Resources.Load("mgun"+i) as GameObject).GetComponent<SpriteRenderer>());
            weaponsMoney.Add(PlayerPrefs.GetInt("weapon"+i+"price"));
        }
        
        string guns = PlayerPrefs.GetString("pickedWeapons");
        string[] items = guns.Split(';');
        Transform[] tGuns = gameObject.GetComponentsInChildren<Transform>();
        SpriteRenderer[] goGuns = gameObject.GetComponentsInChildren<SpriteRenderer>();
        TextMeshPro[] textMoney = gameObject.GetComponentsInChildren<TextMeshPro>();

        for (int i = 0; i < goGuns.Length; i++)
        {
            goGuns[i].name = "weapon" + items[i];
            goGuns[i].sprite = weapons[int.Parse(items[i]) -1].sprite;
            textMoney[i].color = Color.green;
            textMoney[i].SetText(""+weaponsMoney[int.Parse(items[i]) - 1]+"$");
            textMoney[i].name = ("money" + items[i]);
            if ((int.Parse(items[i]))  == 5)
            {
                goGuns[i].transform.Rotate(180, 0, 0);
                
            }
        }
        gameObject.SetActive(false);
    }
}
