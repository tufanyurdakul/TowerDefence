using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public TextMeshProUGUI tmpMoney;
    // Start is called before the first frame update
    void Awake()
    {
        //Ad,Ap,Ls,Crit,Flame,Glacier,Light,Poison,AdBonus,ApBonus,ElementalBonus,ArPen,MagicPen,range
        //count of accessory , upgrade
        //PlayerPrefs.SetInt("isFirst", 0);
        if (PlayerPrefs.GetInt("isFirst") == 0)
        {
            PlayerPrefs.SetString("pickedWeapons", "1;2;3;4;");
            PlayerPrefs.SetString("upgradeMoney", "100,100,100,100,100;100,100,100,100,100;100,100,100,100,100;100,100,100,100,100;100,100,100,100,100;100,100,100,100,100;");
            PlayerPrefs.SetInt("weapon1price", 120);
            PlayerPrefs.SetInt("weapon2price", 80);
            PlayerPrefs.SetInt("weapon3price", 40);
            PlayerPrefs.SetInt("weapon4price", 40);
            PlayerPrefs.SetInt("weapon5price", 100);
            PlayerPrefs.SetInt("weapon6price", 150);
            PlayerPrefs.SetString("firstWeapon",  "6,1,0,0,5,0,0,0,0,0,0,0,0,5,");
            PlayerPrefs.SetString("secondWeapon", "20,1,0,10,0,0,0,2,0,0,0,0,0,15,");
            PlayerPrefs.SetString("thirdWeapon",  "3,5,0,0,0,5,0,0,0,0,0,0,10,7,");
            PlayerPrefs.SetString("fourthWeapon", "3,5,0,0,0,0,5,0,0,0,0,0,0,7,");
            PlayerPrefs.SetString("fifthWeapon",  "30,1,0,0,0,0,0,1,0,0,0,0,0,5,");
            PlayerPrefs.SetString("sixthWeapon", "0,0,0,0,10,0,0,0,0,0,0,0,0,8,");
            PlayerPrefs.SetInt("map", 1);
            PlayerPrefs.SetFloat("firstWeaponAs", 0.8f);
            PlayerPrefs.SetFloat("secondWeaponAs", 0.45f);
            PlayerPrefs.SetFloat("thirdWeaponAs", 0.55f);
            PlayerPrefs.SetFloat("fourthWeaponAs", 0.55f);
            PlayerPrefs.SetFloat("fifthWeaponAs", 0.3f);
            PlayerPrefs.SetFloat("sixthWeaponAs", 1.5f);

            PlayerPrefs.SetString("fireSkill", "2,10,360,");
            PlayerPrefs.SetString("asSkill", "0,1;6;120;");
            PlayerPrefs.SetInt("mission", 0);
            PlayerPrefs.SetInt("getmission", 0);
            PlayerPrefs.SetString("itemMoney", "1800,3500,2200,950,1500,950,950,3000,2500,2000,2000,950,2500,2500,6000,7000,2750,2500,2500,3000,2500,2400,1750,400,3250");
            //item name,ad,ap,as,crit,arpen,mrpen,elemental d.,flame,glacier,light,Poison,itemid
            PlayerPrefs.SetString("itemStatics", "Sword Art,Atack Damage :25,Atack Speed :0.2,Armor Penetration :%10,,,,Every Third Atack Hits Bonus Damage For 50% Of Weapon's Atack Damage And Decreases Enemies Current Armor By 15%,1,;" +
                "Magician Page,Magic :35,Atack Speed :0.5,Elemental Damage :5,,,,Every Atack Hits Extra Weapon's Elemental Damage For 3% Of Enemies Current Health,2,;" +
                "Ring Of Cerenimo,Poison Damage :15,Atack Speed :0.2,Elemental Bonus :15,,,,If Health Of Enemies Is Lower Than 50% Than Your Damage Increases By 12%,3,;" +
                "Book Of Iced Cyclone,Glacier Damage :10,Atack Speed :0.2,,,,,Ice Time Increases By 2.5 Second,4,;" +
                "Hit Of Spanks,Atack Speed :0.25,Range :1,,,,,Every 4th Atack Throw Two Ammo And Second Ammo Doesn't Hits Physical Damage,5,;" +
                "Poison Elixir,Poison Damage : 5,,,,,,All Current Poison Type Weapons In Map Gain 10 Atack And 5 Critical Chance,6,;" +
                "Help Of Elixir,Light Damage : 17,,,,,,All Weapons Gain 0.3 Atack Speed For 5 Sec If You Hits 9 Times.,7,;" +
                "Heavy Phonome,Atack Damage : 80,Critical Chance : 20,,,,,Your Critical Damage Increases By 50%,8,;" +
                "One Pounch Weapon,Critical Chance : 20,Range : 2,Atack Speed : 0.1,Flame Damage : 5,,,If Weapon Kills A Enemy With Last Hit You Restore Your Health By 1,9,;" +
                "Bag Of Penetration,Atack Damage : 20,Critical Chance : 10,,,,,35% Armor Penetration,10,;" +
                "Penetration Of Ability,Flame Damage : 2,Glacier Damage : 2,Poison Damage : 2,Light Damage : 2,,,35% Magic Penetration,11,;" +
                "Crystal Of Flame,Flame Damage : 5,,,,,,All Current Fire Type Weapons In Map Gain 0.1 Atack Speed And 1 Range,12,;" +
                "Infinity Damage,Atack Damage : 20,Critical Chance : 20,Atack Speed: 0.5,,,,If Weapon Hits Critical And Enemies Health Lower Than %12 Of Max Hp Than This Item Execute The Enemy,13,;" +
                "Area Blood,Magic: 20,Range: 1,,,,,Your Ammoes Bounced To  Enemies And Theese Ammoes Damages Decreases By 50% On Every Hits,14,;" +
                "Life Leaf,Magic: 50,Elemental Damage: 50,,,,,Magic And Elemental Bonus Increases By 50,15,;" +
                "Rope's Atack,Atack Damage: 200,,,,,,Atack Bonus Increases By 50,16,;" +
                "Green's Power,Atack Damage: 10,Atack Speed: 0.2,Magic: 10,Magic Penetration: 10%,Armor Penetration: 10%,Elemental Damage: 10,Life Regeneration Of Enemies Decreases By 50%,17,;" +
                "Fire Up,Flame Damage: 40,,,,,,Every Third Atack In Same Enemy Gives Extra Damage. It Grows With Flame Damage,18,;" +
                "Ice Born,Glacier Damage :55,,,,,,Every Third Atack In Same Enemy Gives Extra Damage. It Grows With Glacier Damage,19,;" +
                "Iced Atack,Glacier Damage: 35,Atack Speed: 0.5,,,,,If Weapon Slows Enemies With This Item Than This Item Create Area and Slows Enemies By 25%,20,;" +
                "Pill,Light Damage: 40,Atack Speed: 0.5,,,,,Every Third Atack In Same Enemy Gives Extra Damage. It Grows With Light Damage,21,;" +
                "Eye Range,Range: 9,,,,,,Every Weapon Gain 1 Range,22,;" +
                "The Bank,Magic Bonus: 12,Atack Bonus: 12,Elemental Bonus: 12,,,,If Kill Enemies With This Item You Gain Extra 10$,23,;" +
                "Bangage,Atack Damage: 10,Atack Speed : 0.1,,,,,Every Atack Gives Extra 10 Physical Damage,24,;" +
                 "Broken,Atack Speed: 1.0,Critical Chance : 20,,,,,Every Critical Atack Gives Extra 30 Physical Damage,25,;"
                );
            PlayerPrefs.SetInt("weapon5Buy", 0);
            PlayerPrefs.SetInt("weapon6Buy", 0);
            PlayerPrefs.SetInt("weapon5BuyPrice", 10000);
            PlayerPrefs.SetInt("weapon6BuyPrice", 15000);
            PlayerPrefs.SetInt("isFirst",1);
            PlayerPrefs.SetInt("price", 100000);
        }
        tmpMoney.SetText(PlayerPrefs.GetInt("price")+"$");

    }
}
