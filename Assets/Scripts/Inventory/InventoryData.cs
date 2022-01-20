using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryData : MonoBehaviour
{
    public Sprite B1, B2, B3;
    public Button weapon1, weapon2, weapon3, weapon4, weapon5;
    public GameObject textAd, textAp, textAs, textEd, textRng, textCrit;
    public Button belt1, belt2, belt3;
    private TextMeshProUGUI tmpAd, tmpAp, tmpAs, tmpEd, tmpRng, tmpCrit;
    private int ad, ap, ed, rng, crit , ls , arpen , mrpen;
    private float asp;
    private List<int> Bonus;
    public int SlotBelt1 { get; set; }
    public int SlotBelt2 { get; set; }
    public int SlotBelt3 { get; set; }
    public int SlotBelt1Up { get; set; }
    public int SlotBelt2Up { get; set; }
    public int SlotBelt3Up { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        tmpAd = textAd.GetComponent<TextMeshProUGUI>();
        tmpAs = textAs.GetComponent<TextMeshProUGUI>();
        tmpAp = textAp.GetComponent<TextMeshProUGUI>();
        tmpEd = textEd.GetComponent<TextMeshProUGUI>();
        tmpRng = textRng.GetComponent<TextMeshProUGUI>();
        tmpCrit = textCrit.GetComponent<TextMeshProUGUI>();
        weapon1.onClick.AddListener(Weapon1Click);
        weapon2.onClick.AddListener(Weapon2Click);
        weapon3.onClick.AddListener(Weapon3Click);
        weapon4.onClick.AddListener(Weapon4Click);
        weapon5.onClick.AddListener(Weapon5Click);
        GetData(1);
    }
    private void Weapon1Click()
    {
        GetData(1);
    }
    private void Weapon2Click()
    {
        GetData(2);
    }
    private void Weapon3Click()
    {
        GetData(3);
    }
    private void Weapon4Click()
    {
        GetData(4);
    }
    private void Weapon5Click()
    {
        GetData(5);
    }
    private void GetData(int weapon)
    {
        Bonus = new List<int>();
        string data = string.Empty;
        string beltData = string.Empty;
        int myWeapon = 0;
        if (weapon == 1)
        {
            data = PlayerPrefs.GetString("firstWeapon");
            asp = PlayerPrefs.GetFloat("firstWeaponAs");
            beltData = PlayerPrefs.GetString("firstWeaponBelts");
            myWeapon = 4;
        }
        if (weapon == 2)
        {
            data = PlayerPrefs.GetString("secondWeapon");
            asp = PlayerPrefs.GetFloat("secondWeaponAs");
            beltData = PlayerPrefs.GetString("secondWeaponBelts");
            myWeapon = 7;
        }
        if (weapon == 3)
        {
            data = PlayerPrefs.GetString("thirdWeapon");
            asp = PlayerPrefs.GetFloat("thirdWeaponAs");
            beltData = PlayerPrefs.GetString("thirdWeaponBelts");
            myWeapon = 5;
        }
        if (weapon == 4)
        {
            data = PlayerPrefs.GetString("fourthWeapon");
            asp = PlayerPrefs.GetFloat("fourthWeaponAs");
            beltData = PlayerPrefs.GetString("fourthWeaponBelts");
            myWeapon = 6;
        }
        if (weapon == 5)
        {
            data = PlayerPrefs.GetString("fifthWeapon");
            asp = PlayerPrefs.GetFloat("fifthWeaponAs");
        }
        splitData(data, myWeapon);
        splitData(beltData,"belt");
        ShowData();
    }
    public void splitData(string data , int myWeapon)
    {
        int startPosition = 0;
        int count = 0;
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i].Equals(','))
            {
                int value = int.Parse(data.Substring(startPosition, i - startPosition));
                setData(value, count, myWeapon);
                startPosition = i + 1;
                count++;
            }
        }
    }
    public void splitData(string data , string itemname)
    {
        int startPosition = 0;
        int count = 0;
        int slot = 1;
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i].Equals(','))
            {
                int value = int.Parse(data.Substring(startPosition, i - startPosition));
                setData(value, count , itemname , slot);
                startPosition = i + 1;
                count++;
                if (count % 2 == 0)
                {
                    slot++;
                }
            }
        }
    }
    public void setData(int value , int count , string item , int slot)
    {
        int itemname = 0;
        int upgrade = 0;

        if (count % 2 == 0)
        {
            itemname = value;
            if (item == "belt")
            {
                Sprite myBelt = GetBelt(itemname);
                if (slot == 1)
                {
                    belt1.GetComponent<Image>().sprite = myBelt;
                    SlotBelt1 = itemname;
                }
                else if (slot == 2)
                {
                    belt2.GetComponent<Image>().sprite = myBelt;
                    SlotBelt2 = itemname;

                }
                else if (slot == 3)
                {
                    belt3.GetComponent<Image>().sprite = myBelt;
                    SlotBelt3 = itemname;

                }
            }
        }
        else if (count % 2 == 1)
        {
            upgrade = value;
            if (item == "belt")
            {
                if (slot == 1)
                {
                    SlotBelt1Up = upgrade;
                    belt1.GetComponentInChildren<TextMeshProUGUI>().SetText(""+upgrade);
                }
                else if (slot == 2)
                {
                    SlotBelt2Up = upgrade;
                    belt2.GetComponentInChildren<TextMeshProUGUI>().SetText("" + upgrade);
                }
                else if (slot == 3)
                {
                    SlotBelt3Up = upgrade;
                    belt3.GetComponentInChildren<TextMeshProUGUI>().SetText("" + upgrade);
                }
            }
        }
    }
    private Sprite GetBelt(int name)
    {
        Sprite mybelt = null;
        if (name == 1)
        {
            mybelt = B1;
        }
        else if(name == 2)
        {
            mybelt = B2;
        }
        else if(name == 3)
        {
            mybelt = B3;
        }
        return mybelt;
    }
    private void setData(int value, int count , int myEd)
    {
        if (count == 0)
        {
            ad = value;
        }
        else if (count == 1)
        {
            ap = value;
        }
        else if (count == 2)
        {
            ls = value;
        }
        else if (count == 3)
        {
            crit = value;
        }
        else if (count == myEd)
        {
            ed = value;
        }
        else if (count >= 8 && count < 11)
        {
            Bonus.Add(value);
        }
        else if (count == 11)
        {
            arpen = value;
        }
        else if (count == 12)
        {
            mrpen = value;
        }
        else if (count == 13)
        {
            rng = value;
        }
    }
    private void ShowData()
    {
        ad += (int)(ad * Bonus[0] * 0.01f);
        ap += (int)(ap * Bonus[1] * 0.01f);
        ed += (int)(ed * Bonus[2] * 0.01f);
        tmpAd.SetText($"Atack Damage: {ad}");
        tmpAs.SetText($"Atack Speed: {asp}");
        tmpAp.SetText($"Magic Damage: {ap}");
        tmpEd.SetText($"Elemental Damage: {ed}");
        tmpRng.SetText($"Range: {rng}");
        tmpCrit.SetText($"Critical Change: {crit}");
    }
}
