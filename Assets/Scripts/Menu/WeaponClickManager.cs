using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponClickManager : MonoBehaviour
{
    public Button weapon1, weapon2, weapon3, weapon4, weapon5, weapon6, equip, upgrade, buy, buyClose, buyButton, equipCancel, equipOk, panelCancel, upOk;
    public Button equip1, equip2, equip3, equip4, upAd, upAp, upAs, upCrit, upMoney;
    public GameObject goAd, goAsp, goEp, goRange, goCrit, goMoney, goPassive, goname, gotype, panelBuy, panelEquip, panelUpgrade;
    private TextMeshProUGUI ad, asp, ep, range, crit, money, passive, name, type;
    public TextMeshProUGUI tmpBuy, tmpMoney, tmpUpgrade, tmpUpgradeInfo, tmpUpPrice;
    private List<string> AllData, damagesName, passiveText, nameText, dataName, priceData;
    private List<int> price, damages;
    private List<float> atackSpeed;
    private List<Color32> textColor;
    private float adspeed;
    private int atackDamage, criticalChance, rng, weaponPrice, choosen = 0, buyPrice;
    public List<SpriteRenderer> weaponSprites;
    private List<Button> equipButtons;
    private int equipment, upgradeName;
    private int increaseAd, increaseAp, increaseCrit, increaseMoney;
    private float increaseAs;
    enum ListElemental
    {
        flame = 4,
        glacier = 5,
        light = 6,
        posion = 7
    }
    enum ListStatics
    {
        ad = 0,
        crit = 3
    }
    void Start()
    {
        definitions();
        addList();
        weapon1Click();
    }
    private void weapon1Click()
    {
        choosen = 0;
        if (!equip.interactable && !upgrade.interactable)
        {
            TextMeshProUGUI tmpup = upgrade.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI tmpbuy = buy.GetComponentInChildren<TextMeshProUGUI>();
            tmpup.SetText("Upgrade");
            upgrade.interactable = true;
            buy.interactable = false;
            tmpbuy.SetText("");
        }
        else
        {
            buy.interactable = false;
            TextMeshProUGUI tmpbuy = buy.GetComponentInChildren<TextMeshProUGUI>();
            tmpbuy.SetText("");

        }

        equipButton();
        ItemClick(choosen);
    }
    private void weapon2Click()
    {
        choosen = 1;
        if (!equip.interactable && !upgrade.interactable)
        {
            TextMeshProUGUI tmpup = upgrade.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI tmpbuy = buy.GetComponentInChildren<TextMeshProUGUI>();
            tmpup.SetText("Upgrade");
            tmpbuy.SetText("");
            upgrade.interactable = true;
            buy.interactable = false;
        }
        else
        {
            TextMeshProUGUI tmpbuy = buy.GetComponentInChildren<TextMeshProUGUI>();
            tmpbuy.SetText("");
            buy.interactable = false;
        }
        equipButton();

        ItemClick(choosen);
    }
    private void weapon3Click()
    {
        choosen = 2;
        if (!equip.interactable && !upgrade.interactable)
        {
            TextMeshProUGUI tmpup = upgrade.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI tmpbuy = buy.GetComponentInChildren<TextMeshProUGUI>();
            tmpup.SetText("Upgrade");
            tmpbuy.SetText("");
            upgrade.interactable = true;
            buy.interactable = false;
        }
        else
        {
            TextMeshProUGUI tmpbuy = buy.GetComponentInChildren<TextMeshProUGUI>();
            tmpbuy.SetText("");
            buy.interactable = false;
        }
        equipButton();

        ItemClick(choosen);
    }
    private void weapon4Click()
    {
        choosen = 3;
        if (!equip.interactable && !upgrade.interactable)
        {
            TextMeshProUGUI tmpup = upgrade.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI tmpbuy = buy.GetComponentInChildren<TextMeshProUGUI>();
            tmpup.SetText("Upgrade");
            tmpbuy.SetText("");
            upgrade.interactable = true;
            buy.interactable = false;
        }
        else
        {
            TextMeshProUGUI tmpbuy = buy.GetComponentInChildren<TextMeshProUGUI>();
            tmpbuy.SetText("");
            buy.interactable = false;
        }
        equipButton();

        ItemClick(choosen);
    }
    private void weapon5Click()
    {
        choosen = 4;
        if (PlayerPrefs.GetInt("weapon5Buy") == 0)
        {
            TextMeshProUGUI tmpeq = equip.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI tmpup = upgrade.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI tmpbuy = buy.GetComponentInChildren<TextMeshProUGUI>();
            tmpup.SetText("");
            tmpeq.SetText("");
            tmpbuy.SetText("Buy");
            upgrade.interactable = false;
            equip.interactable = false;
            buy.interactable = true;
        }
        else
        {
            if (!equip.interactable && !upgrade.interactable)
            {
                TextMeshProUGUI tmpup = upgrade.GetComponentInChildren<TextMeshProUGUI>();
                TextMeshProUGUI tmpbuy = buy.GetComponentInChildren<TextMeshProUGUI>();
                tmpup.SetText("Upgrade");
                tmpbuy.SetText("");
                upgrade.interactable = true;
                buy.interactable = false;
            }
            else
            {
                TextMeshProUGUI tmpbuy = buy.GetComponentInChildren<TextMeshProUGUI>();
                tmpbuy.SetText("");
                buy.interactable = false;
            }
            equipButton();

        }
        ItemClick(choosen);
    }
    private void weapon6Click()
    {
        choosen = 5;
        if (PlayerPrefs.GetInt("weapon6Buy") == 0)
        {
            TextMeshProUGUI tmpeq = equip.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI tmpup = upgrade.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI tmpbuy = buy.GetComponentInChildren<TextMeshProUGUI>();
            tmpeq.SetText("");
            tmpup.SetText("");
            tmpbuy.SetText("Buy");
            upgrade.interactable = false;
            equip.interactable = false;
            buy.interactable = true;
        }
        else
        {
            if (!equip.interactable && !upgrade.interactable)
            {
                TextMeshProUGUI tmpup = upgrade.GetComponentInChildren<TextMeshProUGUI>();
                TextMeshProUGUI tmpbuy = buy.GetComponentInChildren<TextMeshProUGUI>();
                tmpup.SetText("Upgrade");
                tmpbuy.SetText("");
                upgrade.interactable = true;
                buy.interactable = false;
            }
            else
            {
                TextMeshProUGUI tmpbuy = buy.GetComponentInChildren<TextMeshProUGUI>();
                tmpbuy.SetText("");
                buy.interactable = false;
                equipButton();
            }
            equipButton();
        }
        ItemClick(choosen);
    }
    private void buyPanelClick()
    {
        panelBuy.SetActive(true);
        weapon1.interactable = false;
        weapon2.interactable = false;
        weapon3.interactable = false;
        weapon4.interactable = false;
        weapon5.interactable = false;
        weapon6.interactable = false;

        buyPrice = PlayerPrefs.GetInt("weapon" + (choosen + 1) + "BuyPrice");
        tmpBuy.SetText($"Do You Want To Buy This Weapon To {buyPrice}$");
        if (buyPrice <= PlayerPrefs.GetInt("price"))
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
        }
    }
    private void equipClick()
    {
        equipment = 0;
        panelEquip.SetActive(true);
        string[] equips = PlayerPrefs.GetString("pickedWeapons").Split(';');
        for (int i = 0; i < equipButtons.Count; i++)
        {
            equipButtons[i].interactable = true;
            Image srEquip = equipButtons[i].GetComponent<Image>();
            srEquip.sprite = weaponSprites[int.Parse(equips[i]) - 1].sprite;
        }
        weapon1.interactable = false;
        weapon2.interactable = false;
        weapon3.interactable = false;
        weapon4.interactable = false;
        weapon5.interactable = false;
        weapon6.interactable = false;
        upgrade.interactable = false;
        tmpUpgrade.SetText("");
    }
    private void equipcancel()
    {
        weapon1.interactable = true;
        weapon2.interactable = true;
        weapon3.interactable = true;
        weapon4.interactable = true;
        weapon5.interactable = true;
        weapon6.interactable = true;
        upgrade.interactable = true;
        tmpUpgrade.SetText("Upgrade");
        panelEquip.SetActive(false);
    }
    private void equipok()
    {
        if (equipment == 0)
        {

        }
        else
        {
            string[] equips = PlayerPrefs.GetString("pickedWeapons").Split(';');
            equips[equipment - 1] = (choosen + 1).ToString();
            string newString = string.Empty;
            foreach (var item in equips)
            {
                newString += item + ";";
            }
            PlayerPrefs.SetString("pickedWeapons", newString);
            if (choosen == 0)
            {
                weapon1Click();
            }
            else if (choosen == 1)
            {
                weapon2Click();
            }
            else if (choosen == 2)
            {
                weapon3Click();
            }
            else if (choosen == 3)
            {
                weapon4Click();
            }
            else if (choosen == 4)
            {
                weapon5Click();
            }
            else if (choosen == 5)
            {
                weapon6Click();
            }
            weapon1.interactable = true;
            weapon2.interactable = true;
            weapon3.interactable = true;
            weapon4.interactable = true;
            weapon5.interactable = true;
            weapon6.interactable = true;
            upgrade.interactable = true;
            tmpUpgrade.SetText("Upgrade");
            panelEquip.SetActive(false);
        }
    }
    private void equip1click()
    {
        equipment = 1;
        foreach (var item in equipButtons)
        {
            item.interactable = true;
        }
        equipButtons[0].interactable = false;
    }
    private void equip2click()
    {
        equipment = 2;
        foreach (var item in equipButtons)
        {
            item.interactable = true;
        }
        equipButtons[1].interactable = false;
    }
    private void equip3click()
    {
        equipment = 3;
        foreach (var item in equipButtons)
        {
            item.interactable = true;
        }
        equipButtons[2].interactable = false;
    }
    private void equip4click()
    {
        equipment = 4;
        foreach (var item in equipButtons)
        {
            item.interactable = true;
        }
        equipButtons[3].interactable = false;
    }
   

    private void buyWeapon()
    {

        if (buyPrice <= PlayerPrefs.GetInt("price"))
        {
            weapon1.interactable = true;
            weapon2.interactable = true;
            weapon3.interactable = true;
            weapon4.interactable = true;
            weapon5.interactable = true;
            weapon6.interactable = true;
            PlayerPrefs.SetInt("price", PlayerPrefs.GetInt("price") - buyPrice);
            PlayerPrefs.SetInt($"weapon{choosen + 1 }Buy", 1);
            tmpMoney.SetText(PlayerPrefs.GetInt("price") + "$");
            if (choosen == 4)
            {
                weapon5Click();
            }
            else if (choosen == 5)
            {
                weapon6Click();
            }
            panelBuy.SetActive(false);
           
            
        }
        
        
    }
    private void buyPanelClose()
    {
        weapon1.interactable = true;
        weapon2.interactable = true;
        weapon3.interactable = true;
        weapon4.interactable = true;
        weapon5.interactable = true;
        weapon6.interactable = true;
        panelBuy.SetActive(false);
    }
    private void equipButton()
    {
        bool isEquipped = false;
        string[] equips = PlayerPrefs.GetString("pickedWeapons").Split(';');
        foreach (string equipItem in equips)
        {
            if (equipItem == (choosen + 1).ToString())
            {
                TextMeshProUGUI tmpeq = equip.GetComponentInChildren<TextMeshProUGUI>();
                tmpeq.SetText("");
                equip.interactable = false;
                isEquipped = true;
                break;
            }
        }
        if (!isEquipped)
        {
            TextMeshProUGUI tmpeq = equip.GetComponentInChildren<TextMeshProUGUI>();
            tmpeq.SetText("Equip");
            equip.interactable = true;
        }
    }
    private void OnUpgradePanel()
    {

        UpPrice(choosen);
        weapon1.interactable = false;
        weapon2.interactable = false;
        weapon3.interactable = false;
        weapon4.interactable = false;
        weapon5.interactable = false;
        weapon6.interactable = false;
        equip.interactable = false;
        TextMeshProUGUI tmpeq = equip.GetComponentInChildren<TextMeshProUGUI>();
        tmpeq.SetText("");
        upgradeAd();
        panelUpgrade.SetActive(true);
    }
    private void panelcancel()
    {
        weapon1.interactable = true;
        weapon2.interactable = true;
        weapon3.interactable = true;
        weapon4.interactable = true;
        weapon5.interactable = true;
        weapon6.interactable = true;
        if (choosen == 0)
        {
            weapon1Click();
        }
        else if (choosen == 1)
        {
            weapon2Click();
        }
        else if (choosen == 2)
        {
            weapon3Click();
        }
        else if (choosen == 3)
        {
            weapon4Click();
        }
        else if (choosen == 4)
        {
            weapon5Click();
        }
        else if (choosen == 5)
        {
            weapon6Click();
        }
        panelUpgrade.SetActive(false);

    }
    private void upgradeOk()
    {
        string newString = string.Empty;
        int upgradeMoney = int.Parse(priceData[upgradeName - 1]);
        if (upgradeMoney <= PlayerPrefs.GetInt("price"))
        {
            if (upgradeName == 1 || upgradeName == 2 || upgradeName == 4)
            {
                string[] getData = AllData[choosen].Split(',');
                if (upgradeName == 1)
                {
                    getData[(int)ListStatics.ad] = (increaseAd + int.Parse(getData[(int)ListStatics.ad])).ToString();
                    foreach (var item in getData)
                    {
                        if (item == getData[getData.Length - 1])
                        {
                            newString += item;
                        }
                        else
                        {
                            newString += item + ",";

                        }
                    }
                }
                else if (upgradeName == 2)
                {
                    List<int> elementalData = new List<int>();
                    elementalData.Add((int)ListElemental.posion);
                    elementalData.Add((int)ListElemental.flame);
                    elementalData.Add((int)ListElemental.glacier);
                    elementalData.Add((int)ListElemental.light);
                    elementalData.Add((int)ListElemental.posion);
                    elementalData.Add((int)ListElemental.flame);

                    getData[elementalData[choosen]] = (increaseAp + int.Parse(getData[elementalData[choosen]])).ToString();
                    foreach (var item in getData)
                    {
                        if (item == getData[getData.Length - 1])
                        {
                            newString += item;
                        }
                        else
                        {
                            newString += item + ",";

                        }
                    }
                }
                else if (upgradeName == 4)
                {
                    getData[(int)ListStatics.crit] = (increaseCrit + int.Parse(getData[(int)ListStatics.crit])).ToString();
                    foreach (var item in getData)
                    {
                        if (item == getData[getData.Length - 1])
                        {
                            newString += item;
                        }
                        else
                        {
                            newString += item + ",";

                        }
                    }
                }
                PlayerPrefs.SetString(dataName[choosen], newString);
                changeAllData();
            }
            else if (upgradeName == 3)
            {
                float newAs = adspeed + increaseAs;
                newAs = Mathf.Round((newAs) * 100f) / 100f;
                PlayerPrefs.SetFloat(dataName[choosen] + "As", ((float)newAs));
                changeAllAsData();
            }
            else if (upgradeName == 5)
            {
                int newGold = weaponPrice - increaseMoney;
                PlayerPrefs.SetInt($"weapon{choosen + 1}price", newGold);
                changeAllPriceData();
            }
            PlayerPrefs.SetInt("price", PlayerPrefs.GetInt("price") - upgradeMoney);
            setWeaponUpPrice(choosen, upgradeName);
            tmpMoney.SetText(PlayerPrefs.GetInt("price") + "$");
            panelcancel();
        }
    }
    private void upgradeAd()
    {
        increaseAd = 0;
        upgradeName = 1;
        getUpMoney(upgradeName - 1);
        if (choosen == 0)
        {
            increaseAd = 4;
        }
        else if (choosen == 1)
        {
            increaseAd = 2;
        }
        else if (choosen == 2)
        {
            increaseAd = 2;
        }
        else if (choosen == 3)
        {
            increaseAd = 2;
        }
        else if (choosen == 4)
        {
            increaseAd = 10;
        }
        else if (choosen == 5)
        {
            increaseAd = 1;
        }
        tmpUpgradeInfo.SetText($"Atack Damage : {atackDamage} + {increaseAd} -> {atackDamage + increaseAd}");
        setUpButton();
    }
    private void upgradeAp()
    {
        increaseAp = 0;
        upgradeName = 2;
        getUpMoney(upgradeName - 1);
        if (choosen == 0)
        {
            increaseAp = 1;
        }
        else if (choosen == 1)
        {
            increaseAp = 2;
        }
        else if (choosen == 2)
        {
            increaseAp = 2;
        }
        else if (choosen == 3)
        {
            increaseAp = 2;
        }
        else if (choosen == 4)
        {
            increaseAp = 1;
        }
        else if (choosen == 5)
        {
            increaseAp = 1;
        }
        int c = choosen < 4 ? choosen : choosen % 4;

        tmpUpgradeInfo.SetText($"Elemental Damage : {damages[c]} + {increaseAp} -> {damages[c] + increaseAp}");
        setUpButton();

    }
    private void upgradeAs()
    {
        increaseAs = 0;
        upgradeName = 3;
        getUpMoney(upgradeName - 1);
        if (choosen == 0)
        {
            increaseAs = 0.02f;
        }
        else if (choosen == 1)
        {
            increaseAs = 0.04f;
        }
        else if (choosen == 2)
        {
            increaseAs = 0.04f;
        }
        else if (choosen == 3)
        {
            increaseAs = 0.04f;
        }
        else if (choosen == 4)
        {
            increaseAs = 0.01f;
        }
        else if (choosen == 5)
        {
            increaseAs = 0.06f;
        }

        tmpUpgradeInfo.SetText($"Atack Speed : {adspeed} + {increaseAs} -> {adspeed + increaseAs}");
        setUpButton();

    }
    private void upgradeCrit()
    {
        increaseCrit = 0;
        upgradeName = 4;
        getUpMoney(upgradeName - 1);
        if (choosen == 0)
        {
            increaseCrit = 2;
        }
        else if (choosen == 1)
        {
            increaseCrit = 1;
        }
        else if (choosen == 2)
        {
            increaseCrit = 1;
        }
        else if (choosen == 3)
        {
            increaseCrit = 1;
        }
        else if (choosen == 4)
        {
            increaseCrit = 1;
        }
        else if (choosen == 5)
        {
            increaseCrit = 2;
        }

        tmpUpgradeInfo.SetText($"Critical Change : {criticalChance} + {increaseCrit} -> {criticalChance + increaseCrit}");
        setUpButton();
    }
    private void upgradeMoney()
    {
        increaseMoney = 0;
        upgradeName = 5;
        getUpMoney(upgradeName - 1);
        if (choosen == 0)
        {
            increaseMoney = 1;
        }
        else if (choosen == 1)
        {
            increaseMoney = 1;
        }
        else if (choosen == 2)
        {
            increaseMoney = 1;
        }
        else if (choosen == 3)
        {
            increaseMoney = 1;
        }
        else if (choosen == 4)
        {
            increaseMoney = 1;
        }
        else if (choosen == 5)
        {
            increaseMoney = 1;
        }

        tmpUpgradeInfo.SetText($"Weapon Price : {weaponPrice} - {increaseMoney} -> {weaponPrice - increaseMoney}");
        setUpButton();
    }
    private void getUpMoney(int upName)
    {
        tmpUpPrice.SetText(priceData[upName]);
    }
    private void setUpButton()
    {
        int upgradeMoney = int.Parse(priceData[upgradeName - 1]);
        if (upgradeMoney <= PlayerPrefs.GetInt("price"))
        {
            upOk.interactable = true;
        }
        else
        {
            upOk.interactable = false;
        }
    }
   
    private void getData(string myvalue)
    {
        int count = 0;
        int startPosition = 0;
        for (int i = 0; i < myvalue.Length; i++)
        {
            if (myvalue[i].Equals(','))
            {
                int value = int.Parse(myvalue.Substring(startPosition, i - startPosition));
                setData(value, count);
                startPosition = i + 1;
                count++;
            }
        }
    }
    private void ItemClick(int choosen)
    {
        getData(AllData[choosen]);
        setPrice(choosen);
        setAtackSpeed(choosen);
        setInfo(choosen);
    }
    private void UpPrice(int choosen)
    {
        priceData = new List<string>();
        string[] prices = PlayerPrefs.GetString("upgradeMoney").Split(';');
        string[] cprices = prices[choosen].Split(',');
        foreach (var item in cprices)
        {
            priceData.Add(item);
        }
    }
    private void setWeaponUpPrice(int ch,int un)
    {
        string[] prices = PlayerPrefs.GetString("upgradeMoney").Split(';');
        priceData[un-1] = (int.Parse(priceData[un-1]) * 2).ToString();
        string newString = string.Empty;
        for(int i = 0; i<prices.Length; i++)
        {
            if (ch == i)
            {
                for (int j = 0; j<priceData.Count; j++)
                {
                    if (j == priceData.Count -1)
                    {
                        newString += priceData[j]+";";
                    }
                    else
                    {
                        newString += priceData[j] + ",";

                    }
                }
            }
            else
            {
                if (i == prices.Length - 1)
                {
                    newString += prices[i];
                }
                else
                {
                    newString += prices[i] + ";";

                }
            }
        }
        PlayerPrefs.SetString("upgradeMoney", newString);

    }
    private void setInfo(int weapon)
    {
        int damagetype = weapon < 4 ? weapon : weapon % 4;
       
        ad.SetText($"Atack Damage : {atackDamage}");
        asp.SetText("Atack Speed : " + adspeed.ToString());
        ep.SetText(damagesName[damagetype] + "" + damages[damagetype].ToString());
        range.SetText("Range : " + rng.ToString());
        crit.SetText("Critical Chance : " + criticalChance.ToString());
        money.SetText("Price : " + weaponPrice.ToString());
        name.SetText(nameText[weapon]);
        type.SetText("Damage Type : " + damagesName[damagetype].Replace("Damage : ", ""));
        type.color = textColor[weapon];
        passive.SetText(passiveText[weapon]);
    }
    private void setAtackSpeed(int choosen)
    {
        adspeed = atackSpeed[choosen];
    }
    private void setPrice(int choosen)
    {
        weaponPrice = price[choosen];
    }
    private void setData(int value, int count)
    {
        if (count == 0)
        {
            atackDamage = value;
        }
        else if (count == 3)
        {
            criticalChance = value;
        }
        else if (count == 4)
        {
            damages[1] = value;
        }
        else if (count == 5)
        {
            damages[2] = value;
        }
        else if (count == 6)
        {
            damages[3] = value;
        }
        else if (count == 7)
        {
            damages[0] = value;
        }
        else if (count == 13)
        {
            rng = value;
        }
    }
    private void changeAllData()
    {
        AllData = new List<string>();
        AllData.Add(PlayerPrefs.GetString("secondWeapon"));
        AllData.Add(PlayerPrefs.GetString("firstWeapon"));
        AllData.Add(PlayerPrefs.GetString("thirdWeapon"));
        AllData.Add(PlayerPrefs.GetString("fourthWeapon"));
        AllData.Add(PlayerPrefs.GetString("fifthWeapon"));
        AllData.Add(PlayerPrefs.GetString("sixthWeapon"));
    }
    private void changeAllAsData()
    {
        atackSpeed = new List<float>();
        atackSpeed.Add(PlayerPrefs.GetFloat("secondWeaponAs"));
        atackSpeed.Add(PlayerPrefs.GetFloat("firstWeaponAs"));
        atackSpeed.Add(PlayerPrefs.GetFloat("thirdWeaponAs"));
        atackSpeed.Add(PlayerPrefs.GetFloat("fourthWeaponAs"));
        atackSpeed.Add(PlayerPrefs.GetFloat("fifthWeaponAs"));
        atackSpeed.Add(PlayerPrefs.GetFloat("sixthWeaponAs"));
    }
    private void changeAllPriceData()
    {
        price = new List<int>();
        for (int i = 0; i < 6; i++)
        {
            price.Add(PlayerPrefs.GetInt($"weapon{i + 1}price"));
            damages.Add(0);
        }
    }
    private void addList()
    {
        AllData.Add(PlayerPrefs.GetString("secondWeapon"));
        AllData.Add(PlayerPrefs.GetString("firstWeapon"));
        AllData.Add(PlayerPrefs.GetString("thirdWeapon"));
        AllData.Add(PlayerPrefs.GetString("fourthWeapon"));
        AllData.Add(PlayerPrefs.GetString("fifthWeapon"));
        AllData.Add(PlayerPrefs.GetString("sixthWeapon"));

        dataName.Add("secondWeapon");
        dataName.Add("firstWeapon");
        dataName.Add("thirdWeapon");
        dataName.Add("fourthWeapon");
        dataName.Add("fifthWeapon");
        dataName.Add("sixthWeapon");

        atackSpeed.Add(PlayerPrefs.GetFloat("secondWeaponAs"));
        atackSpeed.Add(PlayerPrefs.GetFloat("firstWeaponAs"));
        atackSpeed.Add(PlayerPrefs.GetFloat("thirdWeaponAs"));
        atackSpeed.Add(PlayerPrefs.GetFloat("fourthWeaponAs"));
        atackSpeed.Add(PlayerPrefs.GetFloat("fifthWeaponAs"));
        atackSpeed.Add(PlayerPrefs.GetFloat("sixthWeaponAs"));
        for (int i = 0; i < 6; i++)
        {
            price.Add(PlayerPrefs.GetInt($"weapon{i + 1}price"));
            damages.Add(0);
        }
        damagesName.Add("Posion Damage : ");
        damagesName.Add("Flame Damage : ");
        damagesName.Add("Glacier Damage : ");
        damagesName.Add("Light Damage : ");
        damagesName.Add("Posion Damage : ");
        damagesName.Add("Flame Damage : ");


        passiveText.Add("Weapon's Atack Gives Posion Damage To Enemies For 4 Second");
        passiveText.Add("Weapon's Atack Gives Flame Damage To Area");
        passiveText.Add("Weapon's Atack Can Slow To Enemies");
        passiveText.Add("Weapon's Atack Can Stun To Enemies");
        passiveText.Add("Weapon's Atack Throw 3 Ammo And Weapon Gain Atack Bonus Instead Of Atack Speed.");
        passiveText.Add("Every Atack On Same Enemy Increase Weapon's Damage And Weapon's Atacks Hit Just Flame Damage.It Can Hit Critical. Also , Weapon Gain Atack Speed Instead Of Atack Damage.");

        nameText.Add("Boozuka");
        nameText.Add("Machine Gun");
        nameText.Add("Shot Ice");
        nameText.Add("Shot Light");
        nameText.Add("Shot Gun");
        nameText.Add("M60");

        textColor.Add(new Color(255, 0, 255));
        textColor.Add(Color.red);
        textColor.Add(Color.blue);
        textColor.Add(Color.yellow);
        textColor.Add(new Color(255, 0, 255));
        textColor.Add(Color.red);
        equipButtons.Add(equip1);
        equipButtons.Add(equip2);
        equipButtons.Add(equip3);
        equipButtons.Add(equip4);
    

    }
    private void definitions()
    {
        weapon1.onClick.AddListener(weapon1Click);
        weapon2.onClick.AddListener(weapon2Click);
        weapon3.onClick.AddListener(weapon3Click);
        weapon4.onClick.AddListener(weapon4Click);
        weapon5.onClick.AddListener(weapon5Click);
        weapon6.onClick.AddListener(weapon6Click);

        buy.onClick.AddListener(buyPanelClick);
        buyClose.onClick.AddListener(buyPanelClose);
        buyButton.onClick.AddListener(buyWeapon);
        equip.onClick.AddListener(equipClick);
        equipCancel.onClick.AddListener(equipcancel);
        equipOk.onClick.AddListener(equipok);
        equip1.onClick.AddListener(equip1click);
        equip2.onClick.AddListener(equip2click);
        equip3.onClick.AddListener(equip3click);
        equip4.onClick.AddListener(equip4click);
  

        upgrade.onClick.AddListener(OnUpgradePanel);
        panelCancel.onClick.AddListener(panelcancel);
        upAd.onClick.AddListener(upgradeAd);
        upAp.onClick.AddListener(upgradeAp);
        upAs.onClick.AddListener(upgradeAs);
        upCrit.onClick.AddListener(upgradeCrit);
        upMoney.onClick.AddListener(upgradeMoney);
        upOk.onClick.AddListener(upgradeOk);

        ad = goAd.GetComponent<TextMeshProUGUI>();
        asp = goAsp.GetComponent<TextMeshProUGUI>();
        ep = goEp.GetComponent<TextMeshProUGUI>();
        range = goRange.GetComponent<TextMeshProUGUI>();
        crit = goCrit.GetComponent<TextMeshProUGUI>();
        money = goMoney.GetComponent<TextMeshProUGUI>();
        passive = goPassive.GetComponent<TextMeshProUGUI>();
        name = goname.GetComponent<TextMeshProUGUI>();
        type = gotype.GetComponent<TextMeshProUGUI>();

        AllData = new List<string>();
        dataName = new List<string>();
        price = new List<int>();
        damages = new List<int>();
        atackSpeed = new List<float>();
        damagesName = new List<string>();
        passiveText = new List<string>();
        nameText = new List<string>();
        textColor = new List<Color32>();
        equipButtons = new List<Button>();
    }
}
