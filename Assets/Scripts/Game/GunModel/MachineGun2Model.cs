using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun2Model : MonoBehaviour
{
    public string passive { get; set; }
    public int atackDamage { get; set; }
    public float atackSpeed { get; set; }
    public int armorPenetration { get; set; }
    public int magicPenetration { get; set; }
    public int magic { get; set; }
    public string active { get; set; }
    public int health { get; set; }
    public int armor { get; set; }
    public int flameResist { get; set; }
    public int glacierResist { get; set; }
    public int lightResist { get; set; }
    public int positionResist { get; set; }
    public string weaponDamageType { get; set; }
    public int flameDamage { get; set; }
    public int glacierDamage { get; set; }
    public int lightDamage { get; set; }
    public int positionDamage { get; set; }
    public int range { get; set; }
    public int id { get; set; }
    public List<int> items { get; set; }
    public int totaldamage { get; set; }
    public int criticalChance { get; set; }
    public int lifeSteal { get; set; }
    public int criticaldamage { get; set; }

    public List<int> Bonus { get; set; }// first Ad Bonus , second Ap Bonus , third elemental bonus
   
    public int bulletVelocity { get; set; }
    void Awake()
    {
        totaldamage = 0;
        items = new List<int>();
        Bonus = new List<int>();
        int count = 0;
        int startPosition = 0;
        string AllData = PlayerPrefs.GetString("firstWeapon");
        for (int i = 0; i < AllData.Length; i++)
        {
            if (AllData[i].Equals(','))
            {
                int value = int.Parse(AllData.Substring(startPosition, i - startPosition));
                setData(value, count);
                startPosition = i + 1;
                count++;
            }
        }
        weaponDamageType = "Flame Damage";
        passive = "explosion";
        bulletVelocity = 30;
        atackSpeed = PlayerPrefs.GetFloat("firstWeaponAs");

    }
    public void upgrade()
    {
        Bonus[2] += 5;
        flameDamage += 2;
        range += 1;
        atackDamage += 1;
        float newAs = atackSpeed + 0.12f;
        atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
    }
    private void setData(int value, int count)
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
