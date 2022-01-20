using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunModel : MonoBehaviour
{
    public string passive { get; set; }
    public int atackDamage { get; set; }
    public float atackSpeed { get; set; }
    public int armorPenetration { get; set; }
    public int magicPenetration { get; set; }
    public int magic { get; set; }

    public string weaponDamageType { get; set; }
    public int flameDamage { get; set; }
    public int glacierDamage { get; set; }
    public int lightDamage { get; set; }
    public int positionDamage { get; set; }

    public int range { get; set; }

    public int id { get; set; }
    public int criticalChance { get; set; }
    public int lifeSteal { get; set; }

    public List<int> items { get; set; }
    public List<int> Bonus { get; set; }// first Ad Bonus , second Ap Bonus , third elemental bonus , fourth hp bonus
    public int totaldamage {get; set;}
    public int bulletVelocity { get; set; }
    public int criticaldamage { get; set; }


    void Awake()
    {
        items = new List<int>();
        Bonus = new List<int>();
        int count = 0;
        int startPosition = 0;
        string AllData = PlayerPrefs.GetString("secondWeapon");
        for (int i = 0; i< AllData.Length; i++)
        {
            if (AllData[i].Equals(','))
            {
                int value = int.Parse(AllData.Substring(startPosition, i - startPosition));
                setData(value, count);
                startPosition = i + 1;
                count++;
            }
        }
        weaponDamageType = "Poison Damage";
        passive = "poison";
        atackSpeed = PlayerPrefs.GetFloat("secondWeaponAs");
        bulletVelocity = 15;
        float mySize = 1.775919732441472f;
        float z2 = (float)Screen.width / Screen.height;
        float x2 = z2 / mySize;
        range = (int)Math.Ceiling((range * x2) + (2 * x2));

    }
    public void upgrade()
    {
        Bonus[0] += 5;
        atackDamage += 5;
        criticalChance += 2;
        criticaldamage += 3;
        positionDamage += 1;
    }
    private void setData(int value , int count)
    {
        if (count == 0)
        {
            atackDamage = value;
        }
        else if (count == 1)
        {
            magic = value;
        }
        else if (count == 2)
        {
            lifeSteal = value;
        }
        else if (count == 3)
        {
            criticalChance = value;
        }
        else if (count == 4)
        {
            flameDamage = value;
        }
        else if (count == 5)
        {
            glacierDamage = value;
        }
        else if (count == 6)
        {
            lightDamage = value;
        }
        else if (count == 7)
        {
            positionDamage = value;
        }
        else if (count >= 8 && count < 11)
        {
            Bonus.Add(value);
        }
        else if (count == 11)
        {
            armorPenetration = value;
        }
        else if (count == 12)
        {
            magicPenetration = value;
        }
        else if (count == 13)
        {
            range = value;
        }
        criticaldamage = 0;
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
