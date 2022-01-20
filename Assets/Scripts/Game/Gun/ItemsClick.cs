using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemsClick : MonoBehaviour
{
    public Button i1, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12, i13, i14, i15, i16, i17, i18, i19, i20, i21, i22, i23, i24, i25, buyButton, close;
    public TextMeshProUGUI itemname, f1, f2, f3, f4, f5, f6, passive, buytext;
    public List<Button> btnList;
    public Button Order, OrderAd, OrderAp, OrderAs, OrderCrit, OrderDefault;
    public int id { get; set; }
    private IdGenerator idgenerator;
    private List<int> itemMoney;
    private List<string> itemStatics;
    private int orderNumber, choosenDisable, choosen, gold;
    private string[] itemsStatics, itemsMoney;
    private TextMeshProUGUI tmpOrder;
    public TextMeshPro tmpAd, tmpAsp, tmpAp, tmpEb, tmpRng, tmpCrit, tmpArpen, tmpMrpen;
    // Start is called before the first frame update
    void Start()
    {
        float mySize = 1.775919732441472f;
        float z = (float)Screen.height / Screen.width;
        float z2 = (float)Screen.width / Screen.height;
        float x2 = z2 / mySize;
        float x = z / mySize;
        float y = mySize / z;
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * x2, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        btnList = new List<Button>();
        string statics = PlayerPrefs.GetString("itemStatics");
        string ItemMoney = PlayerPrefs.GetString("itemMoney");
        itemsStatics = statics.Split(';');
        itemsMoney = ItemMoney.Split(',');
        GameObject Idgenerator = GameObject.Find("IdGenerator");
        idgenerator = Idgenerator.GetComponent<IdGenerator>();
        orderNumber = PlayerPrefs.GetInt("order");
        tmpOrder = Order.GetComponentInChildren<TextMeshProUGUI>();
        definitions();
        itemMoney = new List<int>();
        itemStatics = new List<string>();
        List<string> ids = new List<string>();
        orderByNormal();
        if (orderNumber == 1)
        {
            orderByPrice();
            show();
            tmpOrder.SetText("Price");
        }
        else if (orderNumber == 2)
        {
            orderByName();
            show();
            tmpOrder.SetText("Name");
        }
        else
        {
            show();
            tmpOrder.SetText("Id");
        }
    }
    //Helpoer Functions
    private void showItemInfo(int choosenItem)
    {
        setNull();
        string[] itemvalues = itemStatics[choosenItem].Split(',');
        itemname.SetText(itemvalues[0]);
        f1.SetText(itemvalues[1]);
        f2.SetText(itemvalues[2]);
        f3.SetText(itemvalues[3]);
        f4.SetText(itemvalues[4]);
        f5.SetText(itemvalues[5]);
        f6.SetText(itemvalues[6]);
        passive.SetText(itemvalues[7]);
        gold = itemMoney[choosenItem];
        buytext.SetText($"{itemMoney[choosenItem]}$");
        ControlBuyable();
        choosen = int.Parse(itemvalues[itemvalues.Length - 2]);
        choosenDisable = choosenItem;
    }
    private void show()
    {
        List<string> ids = new List<string>();
        foreach (string id in itemStatics)
        {
            string[] itemid = id.Split(',');
            if (itemid.Length > 1)
            {
                ids.Add(itemid[itemid.Length - 2]);
            }
        }
        for (int l = 0; l < ids.Count; l++)
        {
            btnList[l].name = ids[l];
            btnList[l].interactable = true;
            Image btnSprite = btnList[l].GetComponent<Image>();
            btnSprite.sprite = Resources.Load<Sprite>($"items/{ids[l]}");

        }
        for (int x = btnList.Count - 1; x >= ids.Count; x--)
        {
            btnList[x].interactable = false;
        }
        GameObject[] weapons = GameObject.FindGameObjectsWithTag("weapon");
        foreach (GameObject weapon in weapons)
        {
            MachineGunModel mg = weapon.GetComponent<MachineGunModel>();
            MachineGun2Model mg2 = weapon.GetComponent<MachineGun2Model>();
            MachineGun3Model mg3 = weapon.GetComponent<MachineGun3Model>();
            MachineGun4Model mg4 = weapon.GetComponent<MachineGun4Model>();
            MachineGun5Model mg5 = weapon.GetComponent<MachineGun5Model>();
            MachineGun6Model mg6 = weapon.GetComponent<MachineGun6Model>();
            if (mg != null)
            {
                if (mg.id == id)
                {
                    foreach (var item in mg.items)
                    {
                        for (int i = 0; i < ids.Count; i++)
                        {
                            if (int.Parse(ids[i]) == item)
                            {
                                btnList[i].interactable = false;

                            }
                        }
                    }
                }
            }
            else if (mg2 != null)
            {
                if (mg2.id == id)
                {
                    foreach (var item in mg2.items)
                    {
                        for (int i = 0; i < ids.Count; i++)
                        {
                            if (int.Parse(ids[i]) == item)
                            {
                                btnList[i].interactable = false;

                            }
                        }
                    }
                }
            }
            else if (mg3 != null)
            {
                if (mg3.id == id)
                {
                    foreach (var item in mg3.items)
                    {
                        for (int i = 0; i < ids.Count; i++)
                        {
                            if (int.Parse(ids[i]) == item)
                            {
                                btnList[i].interactable = false;

                            }
                        }
                    }
                }
            }
            else if (mg4 != null)
            {
                if (mg4.id == id)
                {
                    foreach (var item in mg4.items)
                    {
                        for (int i = 0; i < ids.Count; i++)
                        {
                            if (int.Parse(ids[i]) == item)
                            {
                                btnList[i].interactable = false;

                            }
                        }
                    }
                }
            }
            else if (mg5 != null)
            {
                if (mg5.id == id)
                {
                    foreach (var item in mg5.items)
                    {
                        for (int i = 0; i < ids.Count; i++)
                        {
                            if (int.Parse(ids[i]) == item)
                            {
                                btnList[i].interactable = false;

                            }
                        }
                    }
                }
            }
            else if (mg6 != null)
            {
                if (mg6.id == id)
                {
                    foreach (var item in mg6.items)
                    {
                        for (int i = 0; i < ids.Count; i++)
                        {
                            if (int.Parse(ids[i]) == item)
                            {
                                btnList[i].interactable = false;

                            }
                        }
                    }
                }
            }
        }
    }

    //Order Functions
    private void orderByPrice()
    {
        int i;
        int j;
        int TempValue;
        string strValue;

        for (i = (itemMoney.Count - 1); i >= 0; i--)
        {
            for (j = 1; j <= i; j++)
            {
                if (itemMoney[j - 1] > itemMoney[j])
                {
                    TempValue = itemMoney[j - 1];
                    strValue = itemStatics[j - 1];
                    itemMoney[j - 1] = itemMoney[j];
                    itemStatics[j - 1] = itemStatics[j];
                    itemMoney[j] = TempValue;
                    itemStatics[j] = strValue;

                }
            }
        }
    }
    private void orderByName()
    {
        int i;
        int j;
        int TempValue;
        string strValue;

        for (i = (itemStatics.Count - 1); i >= 0; i--)
        {
            for (j = 1; j <= i; j++)
            {
                string[] name = itemStatics[j - 1].Split(',');
                string[] name2 = itemStatics[j].Split(',');
                byte[] byte1 = Encoding.ASCII.GetBytes(name[0]);
                byte[] byte2 = Encoding.ASCII.GetBytes(name2[0]);
                if (byte1.Length > 0 && byte2.Length > 0)
                {
                    int length = byte1.Length > byte2.Length ? byte2.Length : byte1.Length;
                    for (int m = 0; m < length; m++)
                    {
                        if (byte1[m] > byte2[m])
                        {
                            TempValue = itemMoney[j - 1];
                            strValue = itemStatics[j - 1];
                            itemMoney[j - 1] = itemMoney[j];
                            itemStatics[j - 1] = itemStatics[j];
                            itemMoney[j] = TempValue;
                            itemStatics[j] = strValue;
                            break;
                        }
                        else if (byte1[m] < byte2[m])
                        {
                            break;
                        }
                    }

                }

            }
        }
    }
    private void orderByValue(string myname)
    {
        orderNumber = PlayerPrefs.GetInt("order");
        orderByNormal();
        if (orderNumber == 1)
        {
            orderByPrice();
        }
        else if (orderNumber == 2)
        {
            orderByName();
        }
        List<string> justAd = new List<string>();
        List<int> justMoney = new List<int>();
        string[] names = myname.Split(',');
        string[] itemid = null;
        for (int i = 0; i < itemStatics.Count; i++)
        {
            int addedindex = 0;
            itemid = itemStatics[i].Split(',');
            foreach (string item in itemid)
            {
                string[] values = item.Split(':');
                foreach (string value in values)
                {
                    foreach (var name in names)
                    {
                        if (value.Replace(" ", "").ToLower() == name)
                        {
                            addedindex++;

                        }
                    }

                }

            }
            if (addedindex > 0)
            {
                justAd.Add(itemStatics[i]);
                justMoney.Add(itemMoney[i]);

            }
        }
        itemStatics = justAd;
        itemMoney = justMoney;
    }
    private void orderById()
    {
        int i;
        int j;
        int TempValue;
        string strValue;

        for (i = (itemStatics.Count - 1); i >= 0; i--)
        {
            for (j = 1; j <= i; j++)
            {
                string[] name = itemStatics[j - 1].Split(',');
                string[] name2 = itemStatics[j].Split(',');
                if (name.Length > 0 && name2.Length > 1)
                {
                    if (int.Parse(name[name.Length - 2]) > int.Parse(name2[name2.Length - 2]))
                    {
                        TempValue = itemMoney[j - 1];
                        strValue = itemStatics[j - 1];
                        itemMoney[j - 1] = itemMoney[j];
                        itemStatics[j - 1] = itemStatics[j];
                        itemMoney[j] = TempValue;
                        itemStatics[j] = strValue;
                    }

                }

            }
        }
    }
    private void orderByNormal()
    {
        orderNumber = PlayerPrefs.GetInt("order");
        itemMoney = new List<int>();
        itemStatics = new List<string>();
        foreach (var item in itemsMoney)
        {
            if (!string.IsNullOrEmpty(item))
            {
                itemMoney.Add(int.Parse(item));
            }
        }
        foreach (string staticsOfItem in itemsStatics)
        {
            itemStatics.Add(staticsOfItem);
        }
        if (orderNumber == 1)
        {
            orderByPrice();
        }
        if (orderNumber == 2)
        {
            orderByName();
        }
    }
    private void ordered()
    {
        orderNumber = PlayerPrefs.GetInt("order");
        if (orderNumber == 0)
        {
            orderByPrice();
            show();
            PlayerPrefs.SetInt("order", 1);
            tmpOrder.SetText("Price");
        }
        else if (orderNumber == 1)
        {
            orderByName();
            show();
            PlayerPrefs.SetInt("order", 2);
            tmpOrder.SetText("Name");
        }
        else
        {
            orderById();
            show();
            PlayerPrefs.SetInt("order", 0);
            tmpOrder.SetText("Id");
        }
    }
    //Buttons Functions
    private void orderedDefault()
    {
        orderByNormal();
        show();
    }
    private void orderedAd()
    {
        orderByValue("atackdamage,adbonus,atackbonus");
        show();
    }
    private void orderedAs()
    {
        orderByValue("atackspeed");
        show();
    }
    private void orderedAp()
    {
        orderByValue("ap,magic,lightdamage,poisondamage,elementaldamage,flamedamage,glacierdamage,apbonus");
        show();
    }
    private void orderedCrit()
    {
        orderByValue("criticalchance");
        show();
    }
    private void item1()
    {
        showItemInfo(0);
    }
    private void item2()
    {
        showItemInfo(1);
    }
    private void item3()
    {
        showItemInfo(2);
    }
    private void item4()
    {
        showItemInfo(3);
    }
    private void item5()
    {
        showItemInfo(4);
    }
    private void item6()
    {
        showItemInfo(5);
    }
    private void item7()
    {
        showItemInfo(6);
    }
    private void item8()
    {
        showItemInfo(7);
    }
    private void item9()
    {
        showItemInfo(8);
    }
    private void item10()
    {
        showItemInfo(9);
    }
    private void item11()
    {
        showItemInfo(10);
    }
    private void item12()
    {
        showItemInfo(11);
    }
    private void item13()
    {
        showItemInfo(12);
    }
    private void item14()
    {
        showItemInfo(13);
    }
    private void item15()
    {
        showItemInfo(14);
    }
    private void item16()
    {
        showItemInfo(15);
    }
    private void item17()
    {
        showItemInfo(16);
    }
    private void item18()
    {
        showItemInfo(17);
    }
    private void item19()
    {
        showItemInfo(18);
    }
    private void item20()
    {
        showItemInfo(19);
    }
    private void item21()
    {
        showItemInfo(20);
    }
    private void item22()
    {
        showItemInfo(21);

    }
    private void item23()
    {
        showItemInfo(22);
    }
    private void item24()
    {
        showItemInfo(23);
    }
    private void item25()
    {
        showItemInfo(24);

    }
    private void buy()
    {
        if (idgenerator.gold >= gold)
        {
            BuyForWeapon(choosen);
            if (choosen == 12)
            {
                LoadPassives12();
            }
            if (choosen == 6)
            {
                LoadPassives6();
            }
            if (choosen == 22)
            {
                LoadPassives22();
            }
            setNull();
        }
    }
    private void closed()
    {
        orderByNormal();
        show();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    private void BuyForWeapon(int itemNumber)
    {
        if (itemNumber > 0)
        {
            GameObject[] weapons = GameObject.FindGameObjectsWithTag("weapon");
            GameObject[] itemsimage = GameObject.FindGameObjectsWithTag("itemimages");

            foreach (GameObject item in weapons)
            {
                MachineGun2Model mg2 = item.GetComponent<MachineGun2Model>();
                MachineGunModel mg = item.GetComponent<MachineGunModel>();
                MachineGun3Model mg3 = item.GetComponent<MachineGun3Model>();
                MachineGun4Model mg4 = item.GetComponent<MachineGun4Model>();
                MachineGun5Model mg5 = item.GetComponent<MachineGun5Model>();
                MachineGun6Model mg6 = item.GetComponent<MachineGun6Model>();
                if (mg != null)
                {
                    if (mg.id == id)
                    {
                        if (mg.items.Count < 6)
                        {
                            mg.items.Add(itemNumber);
                            idgenerator.gold -= gold;
                            btnList[choosenDisable].interactable = false;
                            if (itemNumber == 1)
                            {
                                mg.atackDamage += 25;
                                float newAs = mg.atackSpeed + 0.2f;
                                mg.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg.armorPenetration += 10;
                            }
                            else if (itemNumber == 2)
                            {
                                mg.magic += 25;
                                mg.atackSpeed += 0.5f;
                                mg.positionDamage += 5;
                            }
                            else if (itemNumber == 3)
                            {
                                mg.positionDamage += 15;
                                float newAs = mg.atackSpeed + 0.2f;
                                mg.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg.Bonus[2] += 15;
                            }
                            else if (itemNumber == 4)
                            {
                                mg.glacierDamage += 10;
                                mg.atackSpeed += 0.2f;
                            }
                            else if (itemNumber == 5)
                            {
                                mg.range += 1;
                                float newAs = mg.atackSpeed + 0.25f;
                                mg.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 6)
                            {
                                mg.positionDamage += 5;
                            }
                            else if (itemNumber == 7)
                            {
                                mg.lightDamage += 17;
                            }
                            else if (itemNumber == 8)
                            {
                                mg.atackDamage += 80;
                                mg.criticaldamage += 50;
                                mg.criticalChance += 20;
                            }
                            else if (itemNumber == 9)
                            {
                                mg.criticalChance += 20;
                                mg.range += 2;
                                float newAs = mg.atackSpeed + 0.1f;
                                mg.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg.flameDamage += 5;
                            }
                            else if (itemNumber == 10)
                            {
                                mg.criticalChance += 10;
                                mg.atackDamage += 20;
                                mg.armorPenetration += 35;
                            }
                            else if (itemNumber == 11)
                            {
                                mg.flameDamage += 2;
                                mg.glacierDamage += 2;
                                mg.lightDamage += 2;
                                mg.positionDamage += 2;
                                mg.magicPenetration += 35;
                            }
                            else if (itemNumber == 12)
                            {
                                mg.flameDamage += 5;
                            }
                            else if (itemNumber == 13)
                            {
                                mg.atackDamage += 20;
                                float newAs = mg.atackSpeed + 0.5f;
                                mg.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg.criticalChance += 20;
                            }
                            else if (itemNumber == 14)
                            {
                                mg.magic += 20;
                                mg.range += 1;
                            }
                            else if (itemNumber == 15)
                            {
                                mg.magic += 50;
                                mg.positionDamage += 50;
                                mg.Bonus[1] += 50;
                                mg.Bonus[2] += 50;
                            }
                            else if (itemNumber == 16)
                            {
                                mg.atackDamage += 200;
                                mg.Bonus[0] += 50;
                            }
                            else if (itemNumber == 17)
                            {
                                mg.positionDamage += 10;
                                mg.magic += 10;
                                mg.atackDamage += 10;
                                float newAs = mg.atackSpeed + 0.2f;
                                mg.atackSpeed = Mathf.Round((newAs) * 100f) / 100f; mg.armorPenetration += 10;
                                mg.magicPenetration += 10;
                            }
                            else if (itemNumber == 18)
                            {
                                mg.flameDamage += 40;
                            }
                            else if (itemNumber == 19)
                            {
                                mg.glacierDamage += 55;
                            }
                            else if (itemNumber == 20)
                            {
                                mg.glacierDamage += 30;
                                float newAs = mg.atackSpeed + 0.5f;
                                mg.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 21)
                            {
                                mg.lightDamage += 55;
                                float newAs = mg.atackSpeed + 0.5f;
                                mg.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 22)
                            {
                                mg.range += 9;
                            }
                            else if (itemNumber == 23)
                            {
                                mg.Bonus[0] += 12;
                                mg.Bonus[1] += 12;
                                mg.Bonus[2] += 12;
                            }
                            else if (itemNumber == 24)
                            {
                                mg.atackDamage += 10;
                                float newAs = mg.atackSpeed + 0.1f;
                                mg.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 25)
                            {
                                float newAs = mg.atackSpeed + 1;
                                mg.atackSpeed = Mathf.Round((newAs) * 100f) / 100f; 
                                mg.criticalChance += 20;
                            }

                            int count = 0;
                            foreach (var i in itemsimage)
                            {
                                SpriteRenderer sr = i.GetComponent<SpriteRenderer>();
                                if (mg.items.Count > count)
                                {
                                    int myResource = 0;
                                    myResource = mg.items[count];
                                    Sprite sprite = Resources.Load<Sprite>($"items/{myResource}");
                                    sr.sprite = sprite;
                                }
                                else
                                {
                                    sr.sprite = null;
                                }
                                count++;
                            }
                            //setInfDamages(mg4, mg3, mg2, mg);
                        }
                        else
                        {
                            Debug.Log("6'dan Fazla Item Satın Alamazsın.");
                        }
                        break;
                    }
                }
                else if (mg2 != null)
                {
                    if (mg2.id == id)
                    {
                        if (mg2.items.Count < 6)
                        {
                            mg2.items.Add(itemNumber);
                            idgenerator.gold -= gold;
                            btnList[choosenDisable].interactable = false;
                            if (itemNumber == 1)
                            {
                                mg2.atackDamage += 25;
                                float newAs = mg2.atackSpeed + 0.2f;
                                mg2.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg2.armorPenetration += 10;
                            }
                            else if (itemNumber == 2)
                            {
                                mg2.magic += 25;
                                float newAs = mg2.atackSpeed + 0.5f;
                                mg2.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg2.flameDamage += 5;
                            }
                            else if (itemNumber == 3)
                            {
                                mg2.positionDamage += 15;
                                float newAs = mg2.atackSpeed + 0.2f;
                                mg2.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg2.Bonus[2] += 15;
                            }
                            else if (itemNumber == 4)
                            {
                                mg2.glacierDamage += 10;
                                float newAs = mg2.atackSpeed + 0.2f;
                                mg2.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 5)
                            {
                                mg2.range += 1;
                                float newAs = mg2.atackSpeed + 0.25f;
                                mg2.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 6)
                            {
                                mg2.positionDamage += 5;
                            }
                            else if (itemNumber == 7)
                            {
                                mg2.lightDamage += 17;
                            }
                            else if (itemNumber == 8)
                            {
                                mg2.atackDamage += 80;
                                mg2.criticaldamage += 50;
                                mg2.criticalChance += 20;
                            }
                            else if (itemNumber == 9)
                            {
                                mg2.criticalChance += 20;
                                mg2.range += 2;
                                float newAs = mg2.atackSpeed + 0.1f;
                                mg2.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg2.flameDamage += 5;
                            }
                            else if (itemNumber == 10)
                            {
                                mg2.criticalChance += 10;
                                mg2.atackDamage += 20;
                                mg2.armorPenetration += 35;
                            }
                            else if (itemNumber == 11)
                            {
                                mg2.flameDamage += 2;
                                mg2.glacierDamage += 2;
                                mg2.lightDamage += 2;
                                mg2.positionDamage += 2;
                                mg2.magicPenetration += 35;

                            }
                            else if (itemNumber == 12)
                            {
                                mg2.flameDamage += 5;
                            }
                            else if (itemNumber == 13)
                            {
                                mg2.atackDamage += 20;
                                float newAs = mg2.atackSpeed + 0.5f;
                                mg2.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg2.criticalChance += 20;
                            }
                            else if (itemNumber == 14)
                            {
                                mg2.magic += 20;
                                mg2.range += 1;
                            }
                            else if (itemNumber == 15)
                            {
                                mg2.magic += 50;
                                mg2.flameDamage += 50;
                                mg2.Bonus[1] += 50;
                                mg2.Bonus[2] += 50;
                            }
                            else if (itemNumber == 16)
                            {
                                mg2.atackDamage += 200;
                                mg2.Bonus[0] += 50;
                            }
                            else if (itemNumber == 17)
                            {
                                mg2.flameDamage += 10;
                                mg2.magic += 10;
                                mg2.atackDamage += 10;
                                mg2.atackSpeed += 0.2f;
                                mg2.armorPenetration += 10;
                                mg2.magicPenetration += 10;
                            }
                            else if (itemNumber == 18)
                            {
                                mg2.flameDamage += 40;
                            }
                            else if (itemNumber == 19)
                            {
                                mg2.glacierDamage += 55;
                            }
                            else if (itemNumber == 20)
                            {
                                mg2.glacierDamage += 30;
                                float newAs = mg2.atackSpeed + 0.5f;
                                mg2.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 21)
                            {
                                mg2.lightDamage += 55;
                                float newAs = mg2.atackSpeed + 0.5f;
                                mg2.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 22)
                            {
                                mg2.range += 9;
                            }
                            else if (itemNumber == 23)
                            {
                                mg2.Bonus[0] += 12;
                                mg2.Bonus[1] += 12;
                                mg2.Bonus[2] += 12;
                            }
                            else if (itemNumber == 24)
                            {
                                mg2.atackDamage += 10;
                                float newAs = mg2.atackSpeed + 0.1f;
                                mg2.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 25)
                            {
                                float newAs = mg2.atackSpeed + 1;
                                mg2.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg2.criticalChance += 20;
                            }
                            int count = 0;
                            //setInfDamages(mg4, mg3, mg2, mg);
                            foreach (var i in itemsimage)
                            {
                                SpriteRenderer sr = i.GetComponent<SpriteRenderer>();
                                if (mg2.items.Count > count)
                                {
                                    int myResource = 0;
                                    myResource = mg2.items[count];
                                    Sprite sprite = Resources.Load<Sprite>($"items/{myResource}");
                                    sr.sprite = sprite;
                                }
                                else
                                {
                                    sr.sprite = null;
                                }
                                count++;
                            }
                            break;
                        }
                        else
                        {

                        }
                    }
                }
                else if (mg3 != null)
                {
                    if (mg3.id == id)
                    {
                        if (mg3.items.Count < 6)
                        {
                            mg3.items.Add(itemNumber);
                            idgenerator.gold -= gold;
                            btnList[choosenDisable].interactable = false;
                            if (itemNumber == 1)
                            {
                                mg3.atackDamage += 25;
                                float newAs = mg3.atackSpeed + 0.2f;
                                mg3.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg3.armorPenetration += 10;

                            }
                            else if (itemNumber == 2)
                            {
                                mg3.magic += 25;
                                float newAs = mg3.atackSpeed + 0.5f;
                                mg3.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg3.glacierDamage += 5;

                            }
                            else if (itemNumber == 3)
                            {
                                mg3.positionDamage += 15;
                                float newAs = mg3.atackSpeed + 0.2f;
                                mg3.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg3.Bonus[2] += 15;

                            }
                            else if (itemNumber == 4)
                            {
                                mg3.glacierDamage += 10;
                                float newAs = mg3.atackSpeed + 0.2f;
                                mg3.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 5)
                            {
                                mg3.range += 1;
                                float newAs = mg3.atackSpeed + 0.25f;
                                mg3.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 6)
                            {
                                mg3.positionDamage += 5;

                            }
                            else if (itemNumber == 7)
                            {
                                mg3.lightDamage += 17;

                            }
                            else if (itemNumber == 8)
                            {
                                mg3.atackDamage += 80;
                                mg3.criticaldamage += 50;
                                mg3.criticalChance += 20;

                            }
                            else if (itemNumber == 9)
                            {
                                mg3.criticalChance += 20;
                                mg3.range += 2;
                                float newAs = mg3.atackSpeed + 0.1f;
                                mg3.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg3.flameDamage += 5;

                            }
                            else if (itemNumber == 10)
                            {
                                mg3.criticalChance += 10;
                                mg3.atackDamage += 20;
                                mg3.armorPenetration += 35;

                            }
                            else if (itemNumber == 11)
                            {
                                mg3.flameDamage += 2;
                                mg3.glacierDamage += 2;
                                mg3.lightDamage += 2;
                                mg3.positionDamage += 2;
                                mg3.magicPenetration += 35;

                            }
                            else if (itemNumber == 12)
                            {
                                mg3.flameDamage += 5;

                            }
                            else if (itemNumber == 13)
                            {
                                mg3.atackDamage += 20;
                                float newAs = mg3.atackSpeed + 0.5f;
                                mg3.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg3.criticalChance += 20;

                            }
                            else if (itemNumber == 14)
                            {
                                mg3.magic += 20;
                                mg3.range += 1;

                            }
                            else if (itemNumber == 15)
                            {
                                mg3.magic += 50;
                                mg3.glacierDamage += 50;
                                mg3.Bonus[1] += 50;
                                mg3.Bonus[2] += 50;

                            }
                            else if (itemNumber == 16)
                            {
                                mg3.atackDamage += 200;
                                mg3.Bonus[0] += 50;

                            }
                            else if (itemNumber == 17)
                            {
                                mg3.glacierDamage += 10;
                                mg3.magic += 10;
                                mg3.atackDamage += 10;
                                float newAs = mg3.atackSpeed + 0.2f;
                                mg3.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg3.armorPenetration += 10;
                                mg3.magicPenetration += 10;

                            }
                            else if (itemNumber == 18)
                            {
                                mg3.flameDamage += 40;

                            }
                            else if (itemNumber == 19)
                            {
                                mg3.glacierDamage += 55;

                            }
                            else if (itemNumber == 20)
                            {
                                mg3.glacierDamage += 30;
                                float newAs = mg3.atackSpeed + 0.5f;
                                mg3.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 21)
                            {
                                mg3.lightDamage += 55;
                                float newAs = mg3.atackSpeed + 0.5f;
                                mg3.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 22)
                            {
                                mg3.range += 9;

                            }
                            else if (itemNumber == 23)
                            {
                                mg3.Bonus[0] += 12;
                                mg3.Bonus[1] += 12;
                                mg3.Bonus[2] += 12;

                            }
                            else if (itemNumber == 24)
                            {
                                mg3.atackDamage += 10;
                                float newAs = mg3.atackSpeed + 0.1f;
                                mg3.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 25)
                            {
                                float newAs = mg3.atackSpeed +1;
                                mg3.atackSpeed = Mathf.Round((newAs) * 100f) / 100f; mg3.criticalChance += 20;

                            }
                            int count = 0;
                            //setInfDamages(mg4, mg3, mg2, mg);
                            foreach (var i in itemsimage)
                            {
                                SpriteRenderer sr = i.GetComponent<SpriteRenderer>();
                                if (mg3.items.Count > count)
                                {
                                    int myResource = 0;
                                    myResource = mg3.items[count];
                                    Sprite sprite = Resources.Load<Sprite>($"items/{myResource}");
                                    sr.sprite = sprite;
                                }
                                else
                                {
                                    sr.sprite = null;
                                }
                                count++;
                            }
                            break;
                        }
                    }
                }
                else if (mg4 != null)
                {
                    if (mg4.id == id)
                    {
                        if (mg4.items.Count < 6)
                        {
                            mg4.items.Add(itemNumber);
                            idgenerator.gold -= gold;
                            btnList[choosenDisable].interactable = false;
                            if (itemNumber == 1)
                            {
                                mg4.atackDamage += 25;
                                float newAs = mg4.atackSpeed + 0.2f;
                                mg4.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg4.armorPenetration += 10;

                            }
                            else if (itemNumber == 2)
                            {
                                mg4.magic += 25;
                                float newAs = mg4.atackSpeed + 0.5f;
                                mg4.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg4.lightDamage += 5;

                            }
                            else if (itemNumber == 3)
                            {
                                mg4.positionDamage += 15;
                                float newAs = mg4.atackSpeed + 0.2f;
                                mg4.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg4.Bonus[2] += 15;

                            }
                            else if (itemNumber == 4)
                            {
                                mg4.glacierDamage += 10;
                                float newAs = mg4.atackSpeed + 0.2f;
                                mg4.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 5)
                            {
                                mg4.range += 1;
                                float newAs = mg4.atackSpeed + 0.25f;
                                mg4.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 6)
                            {
                                mg4.positionDamage += 5;

                            }
                            else if (itemNumber == 7)
                            {
                                mg4.lightDamage += 17;

                            }
                            else if (itemNumber == 8)
                            {
                                mg4.atackDamage += 80;
                                mg4.criticaldamage += 50;
                                mg4.criticalChance += 20;
                            }
                            else if (itemNumber == 9)
                            {
                                mg4.criticalChance += 20;
                                mg4.range += 2;
                                float newAs = mg4.atackSpeed + 0.1f;
                                mg4.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg4.flameDamage += 5;
                            }
                            else if (itemNumber == 10)
                            {
                                mg4.criticalChance += 10;
                                mg4.atackDamage += 20;
                                mg4.armorPenetration += 35;
                            }
                            else if (itemNumber == 11)
                            {
                                mg4.flameDamage += 2;
                                mg4.glacierDamage += 2;
                                mg4.lightDamage += 2;
                                mg4.positionDamage += 2;
                                mg4.magicPenetration += 35;
                            }
                            else if (itemNumber == 12)
                            {
                                mg4.flameDamage += 5;
                            }
                            else if (itemNumber == 13)
                            {
                                mg4.atackDamage += 20;
                                float newAs = mg4.atackSpeed + 0.5f;
                                mg4.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg4.criticalChance += 20;
                            }
                            else if (itemNumber == 14)
                            {
                                mg4.magic += 20;
                                mg4.range += 1;
                            }
                            else if (itemNumber == 15)
                            {
                                mg4.magic += 50;
                                mg4.lightDamage += 50;
                                mg4.Bonus[1] += 50;
                                mg4.Bonus[2] += 50;
                            }
                            else if (itemNumber == 16)
                            {
                                mg4.atackDamage += 200;
                                mg4.Bonus[0] += 50;
                            }
                            else if (itemNumber == 17)
                            {
                                mg4.lightDamage += 10;
                                mg4.magic += 10;
                                mg4.atackDamage += 10;
                                float newAs = mg4.atackSpeed + 0.2f;
                                mg4.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg4.armorPenetration += 10;
                                mg4.magicPenetration += 10;
                            }
                            else if (itemNumber == 18)
                            {
                                mg4.flameDamage += 40;
                            }
                            else if (itemNumber == 19)
                            {
                                mg4.glacierDamage += 55;
                            }
                            else if (itemNumber == 20)
                            {
                                mg4.glacierDamage += 30;
                                float newAs = mg4.atackSpeed + 0.5f;
                                mg4.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 21)
                            {
                                mg4.lightDamage += 55;
                                float newAs = mg4.atackSpeed + 0.5f;
                                mg4.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 22)
                            {
                                mg4.range += 9;
                            }
                            else if (itemNumber == 23)
                            {
                                mg4.Bonus[0] += 12;
                                mg4.Bonus[1] += 12;
                                mg4.Bonus[2] += 12;
                            }
                            else if (itemNumber == 24)
                            {
                                mg4.atackDamage += 10;
                                float newAs = mg4.atackSpeed + 0.1f;
                                mg4.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 25)
                            {
                                float newAs = mg4.atackSpeed + 1;
                                mg4.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg4.criticalChance += 20;
                            }
                            int count = 0;
                            //setInfDamages(mg4, mg3, mg2, mg);
                            foreach (var i in itemsimage)
                            {
                                SpriteRenderer sr = i.GetComponent<SpriteRenderer>();
                                if (mg4.items.Count > count)
                                {
                                    int myResource = 0;
                                    myResource = mg4.items[count];
                                    Sprite sprite = Resources.Load<Sprite>($"items/{myResource}");
                                    sr.sprite = sprite;
                                }
                                else
                                {
                                    sr.sprite = null;
                                }
                                count++;
                            }
                            break;
                        }
                    }
                }
                else if (mg5 != null)
                {
                    if (mg5.id == id)
                    {
                        if (mg5.items.Count < 6)
                        {
                            mg5.items.Add(itemNumber);
                            idgenerator.gold -= gold;
                            btnList[choosenDisable].interactable = false;
                            if (itemNumber == 1)
                            {
                                mg5.atackDamage += 25;
                                mg5.Bonus[0] += 10;
                                mg5.armorPenetration += 10;

                            }
                            else if (itemNumber == 2)
                            {
                                mg5.magic += 25;
                                mg5.Bonus[0] += 25;
                                mg5.positionDamage += 5;

                            }
                            else if (itemNumber == 3)
                            {
                                mg5.positionDamage += 15;
                                mg5.Bonus[0] += 10;
                                mg5.Bonus[2] += 15;

                            }
                            else if (itemNumber == 4)
                            {
                                mg5.glacierDamage += 10;
                                mg5.Bonus[0] += 10;

                            }
                            else if (itemNumber == 5)
                            {
                                mg5.range += 1;
                                mg5.Bonus[0] += 13;

                            }
                            else if (itemNumber == 6)
                            {
                                mg5.positionDamage += 5;

                            }
                            else if (itemNumber == 7)
                            {
                                mg5.lightDamage += 17;

                            }
                            else if (itemNumber == 8)
                            {
                                mg5.atackDamage += 80;
                                mg5.criticaldamage += 50;
                                mg5.criticalChance += 20;
                            }
                            else if (itemNumber == 9)
                            {
                                mg5.criticalChance += 20;
                                mg5.range += 2;
                                mg5.Bonus[0] += 5;
                                mg5.flameDamage += 5;
                            }
                            else if (itemNumber == 10)
                            {
                                mg5.criticalChance += 10;
                                mg5.atackDamage += 20;
                                mg5.armorPenetration += 35;
                            }
                            else if (itemNumber == 11)
                            {
                                mg5.flameDamage += 2;
                                mg5.glacierDamage += 2;
                                mg5.lightDamage += 2;
                                mg5.positionDamage += 2;
                                mg5.magicPenetration += 35;
                            }
                            else if (itemNumber == 12)
                            {
                                mg5.flameDamage += 5;
                            }
                            else if (itemNumber == 13)
                            {
                                mg5.atackDamage += 20;
                                mg5.Bonus[0] += 25;
                                mg5.criticalChance += 20;
                            }
                            else if (itemNumber == 14)
                            {
                                mg5.magic += 20;
                                mg5.range += 1;
                            }
                            else if (itemNumber == 15)
                            {
                                mg5.magic += 50;
                                mg5.positionDamage += 50;
                                mg5.Bonus[1] += 50;
                                mg5.Bonus[2] += 50;
                            }
                            else if (itemNumber == 16)
                            {
                                mg5.atackDamage += 200;
                                mg5.Bonus[0] += 50;
                            }
                            else if (itemNumber == 17)
                            {
                                mg5.positionDamage += 10;
                                mg5.magic += 10;
                                mg5.atackDamage += 10;
                                mg5.Bonus[0] += 10;
                                mg5.armorPenetration += 10;
                                mg5.magicPenetration += 10;
                            }
                            else if (itemNumber == 18)
                            {
                                mg5.flameDamage += 40;
                            }
                            else if (itemNumber == 19)
                            {
                                mg5.glacierDamage += 55;
                            }
                            else if (itemNumber == 20)
                            {
                                mg5.glacierDamage += 30;
                                mg5.Bonus[0] += 25;
                            }
                            else if (itemNumber == 21)
                            {
                                mg5.lightDamage += 55;
                                mg5.Bonus[0] += 25;
                            }
                            else if (itemNumber == 22)
                            {
                                mg5.range += 9;
                            }
                            else if (itemNumber == 23)
                            {
                                mg5.Bonus[0] += 12;
                                mg5.Bonus[1] += 12;
                                mg5.Bonus[2] += 12;
                            }
                            else if (itemNumber == 24)
                            {
                                mg5.atackDamage += 10;
                                mg5.Bonus[0] += 5;
                            }
                            else if (itemNumber == 25)
                            {
                                mg5.Bonus[0] += 50;
                                mg5.criticalChance += 20;
                            }
                            int count = 0;
                            foreach (var i in itemsimage)
                            {
                                SpriteRenderer sr = i.GetComponent<SpriteRenderer>();
                                if (mg5.items.Count > count)
                                {
                                    int myResource = 0;
                                    myResource = mg5.items[count];
                                    Sprite sprite = Resources.Load<Sprite>($"items/{myResource}");
                                    sr.sprite = sprite;
                                }
                                else
                                {
                                    sr.sprite = null;
                                }
                                count++;
                            }
                            break;
                        }
                    }
                }
                else if (mg6 != null)
                {
                    if (mg6.id == id)
                    {
                        if (mg6.items.Count < 6)
                        {
                            mg6.items.Add(itemNumber);
                            idgenerator.gold -= gold;
                            btnList[choosenDisable].interactable = false;
                            if (itemNumber == 1)
                            {
                                float adAd = 25 * 0.005f;
                                float newAs = mg6.atackSpeed + 0.2f + adAd;
                                mg6.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg6.armorPenetration += 10;

                            }
                            else if (itemNumber == 2)
                            {
                                mg6.magic += 25;
                                float newAs = mg6.atackSpeed + 0.5f;
                                mg6.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg6.lightDamage += 5;

                            }
                            else if (itemNumber == 3)
                            {
                                mg6.positionDamage += 15;
                                float newAs = mg6.atackSpeed + 0.2f;
                                mg6.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg6.Bonus[2] += 15;

                            }
                            else if (itemNumber == 4)
                            {
                                mg6.glacierDamage += 10;
                                float newAs = mg6.atackSpeed + 0.2f;
                                mg6.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 5)
                            {
                                mg6.range += 1;
                                float newAs = mg6.atackSpeed + 0.25f;
                                mg6.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 6)
                            {
                                mg6.positionDamage += 5;

                            }
                            else if (itemNumber == 7)
                            {
                                mg6.lightDamage += 17;

                            }
                            else if (itemNumber == 8)
                            {
                                float adAd = 80 * 0.005f;
                                float newAs = mg6.atackSpeed + adAd;
                                mg6.atackSpeed = Mathf.Round((newAs) * 100f) / 100f; mg6.criticaldamage += 50;
                                mg6.criticalChance += 20;
                            }
                            else if (itemNumber == 9)
                            {
                                mg6.criticalChance += 20;
                                mg6.range += 2;
                                float newAs = mg6.atackSpeed + 0.1f;
                                mg6.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg6.flameDamage += 5;
                            }
                            else if (itemNumber == 10)
                            {
                                mg6.criticalChance += 10;
                                float adAd = 20 * 0.005f;
                                float newAs = mg6.atackSpeed + adAd;
                                mg6.armorPenetration += 35;
                            }
                            else if (itemNumber == 11)
                            {
                                mg6.flameDamage += 2;
                                mg6.glacierDamage += 2;
                                mg6.lightDamage += 2;
                                mg6.positionDamage += 2;
                                mg6.magicPenetration += 35;
                            }
                            else if (itemNumber == 12)
                            {
                                mg6.flameDamage += 5;
                            }
                            else if (itemNumber == 13)
                            {
                                float adAd = 20 * 0.005f;
                                float newAs = mg6.atackSpeed + adAd + 0.5f;
                                mg6.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg6.criticalChance += 20;
                            }
                            else if (itemNumber == 14)
                            {
                                mg6.magic += 20;
                                mg6.range += 1;
                            }
                            else if (itemNumber == 15)
                            {
                                mg6.magic += 50;
                                mg6.flameDamage += 50;
                                mg6.Bonus[1] += 50;
                                mg6.Bonus[2] += 50;
                            }
                            else if (itemNumber == 16)
                            {
                                float adAd = 200 * 0.005f;
                                float newAs = mg6.atackSpeed + adAd;
                                mg6.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg6.Bonus[0] += 50;
                            }
                            else if (itemNumber == 17)
                            {
                                mg6.lightDamage += 10;
                                mg6.magic += 10;
                                float adAd = 10 * 0.005f;
                                float newAs = mg6.atackSpeed + adAd + 0.2f; 
                                mg6.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg6.armorPenetration += 10;
                                mg6.magicPenetration += 10;
                            }
                            else if (itemNumber == 18)
                            {
                                mg6.flameDamage += 40;
                            }
                            else if (itemNumber == 19)
                            {
                                mg6.glacierDamage += 55;
                            }
                            else if (itemNumber == 20)
                            {
                                mg6.glacierDamage += 30;
                                float newAs = mg6.atackSpeed + 0.5f;
                                mg6.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 21)
                            {
                                mg6.lightDamage += 55;
                                float newAs = mg6.atackSpeed + 0.5f;
                                mg6.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 22)
                            {
                                mg6.range += 9;
                            }
                            else if (itemNumber == 23)
                            {
                                mg6.Bonus[0] += 12;
                                mg6.Bonus[1] += 12;
                                mg6.Bonus[2] += 12;
                            }
                            else if (itemNumber == 24)
                            {
                                float adAd = 10 * 0.005f;
                                float newAs = mg6.atackSpeed + adAd + 0.1f;
                                mg6.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                            }
                            else if (itemNumber == 25)
                            {
                                float newAs = mg6.atackSpeed + 1;
                                mg6.atackSpeed = Mathf.Round((newAs) * 100f) / 100f;
                                mg6.criticalChance += 20;
                            }
                            int count = 0;
                            foreach (var i in itemsimage)
                            {
                                SpriteRenderer sr = i.GetComponent<SpriteRenderer>();
                                if (mg6.items.Count > count)
                                {
                                    int myResource = 0;
                                    myResource = mg6.items[count];
                                    Sprite sprite = Resources.Load<Sprite>($"items/{myResource}");
                                    sr.sprite = sprite;
                                }
                                else
                                {
                                    sr.sprite = null;
                                }
                                count++;
                            }
                            break;
                        }
                    }
                }
            }

        }
    }
    private void ControlBuyable()
    {
        Image btnImg = buyButton.GetComponent<Image>();
        if (idgenerator.gold < gold)
        {
            btnImg.color = new Color32(255, 255, 255, 100);
        }
        else
        {
            btnImg.color = new Color32(255, 255, 255, 255);

        }
    }
    private void setNull()
    {
        choosen = 0;
        itemname.SetText("");
        f1.SetText("");
        f2.SetText("");
        f3.SetText("");
        f4.SetText("");
        f5.SetText("");
        f6.SetText("");
        passive.SetText("");
        buytext.SetText("");
    }
    private void LoadPassives12()
    {
        GameObject[] weapons = GameObject.FindGameObjectsWithTag("weapon");
        foreach (GameObject weapon in weapons)
        {
            MachineGun2Model mg2 = weapon.GetComponent<MachineGun2Model>();
            MachineGun6Model mg6 = weapon.GetComponent<MachineGun6Model>();
            if (mg2 != null)
            {
                mg2.atackSpeed += 0.1f;
                mg2.range += 1;
            }
            else if (mg6 != null)
            {
                mg6.atackSpeed += 0.1f;
                mg6.range += 1;
            }
        }
    }
    private void LoadPassives6()
    {
        GameObject[] weapons = GameObject.FindGameObjectsWithTag("weapon");
        foreach (GameObject weapon in weapons)
        {
            MachineGunModel mg = weapon.GetComponent<MachineGunModel>();
            MachineGun5Model mg5 = weapon.GetComponent<MachineGun5Model>();
            if (mg != null)
            {
                mg.atackDamage += 10;
                mg.criticalChance += 5;
            }
            if (mg5 != null)
            {
                mg5.atackDamage += 10;
                mg5.criticalChance += 5;
            }
        }
    }
    private void LoadPassives22()
    {
        GameObject[] weapons = GameObject.FindGameObjectsWithTag("weapon");
        foreach (GameObject weapon in weapons)
        {
            MachineGunModel mg = weapon.GetComponent<MachineGunModel>();
            MachineGun2Model mg2 = weapon.GetComponent<MachineGun2Model>();
            MachineGun3Model mg3 = weapon.GetComponent<MachineGun3Model>();
            MachineGun4Model mg4 = weapon.GetComponent<MachineGun4Model>();
            MachineGun5Model mg5 = weapon.GetComponent<MachineGun5Model>();
            MachineGun6Model mg6 = weapon.GetComponent<MachineGun6Model>();

            if (mg != null)
            {
                mg.range += 1;
            }
            else if (mg2 != null)
            {
                mg2.range += 1;
            }
            else if (mg3 != null)
            {
                mg3.range += 1;
            }
            else if (mg4 != null)
            {
                mg4.range += 1;
            }
            else if (mg5 != null)
            {
                mg5.range += 1;
            }
            else if (mg6 != null)
            {
                mg6.range += 1;
            }
        }
    }
   
    private void definitions()
    {
        btnList.Add(i1);
        btnList.Add(i2);
        btnList.Add(i3);
        btnList.Add(i4);
        btnList.Add(i5);
        btnList.Add(i6);
        btnList.Add(i7);
        btnList.Add(i8);
        btnList.Add(i9);
        btnList.Add(i10);
        btnList.Add(i11);
        btnList.Add(i12);
        btnList.Add(i13);
        btnList.Add(i14);
        btnList.Add(i15);
        btnList.Add(i16);
        btnList.Add(i17);
        btnList.Add(i18);
        btnList.Add(i19);
        btnList.Add(i20);
        btnList.Add(i21);
        btnList.Add(i22);
        btnList.Add(i23);
        btnList.Add(i24);
        btnList.Add(i25);
        i1.onClick.AddListener(item1);
        i2.onClick.AddListener(item2);
        i3.onClick.AddListener(item3);
        i4.onClick.AddListener(item4);
        i5.onClick.AddListener(item5);
        i6.onClick.AddListener(item6);
        i7.onClick.AddListener(item7);
        i8.onClick.AddListener(item8);
        i9.onClick.AddListener(item9);
        i10.onClick.AddListener(item10);
        i11.onClick.AddListener(item11);
        i12.onClick.AddListener(item12);
        i13.onClick.AddListener(item13);
        i14.onClick.AddListener(item14);
        i15.onClick.AddListener(item15);
        i16.onClick.AddListener(item16);
        i17.onClick.AddListener(item17);
        i18.onClick.AddListener(item18);
        i19.onClick.AddListener(item19);
        i20.onClick.AddListener(item20);
        i21.onClick.AddListener(item21);
        i22.onClick.AddListener(item22);
        i23.onClick.AddListener(item23);
        i24.onClick.AddListener(item24);
        i25.onClick.AddListener(item25);
        Order.onClick.AddListener(ordered);
        OrderAd.onClick.AddListener(orderedAd);
        OrderAs.onClick.AddListener(orderedAs);
        OrderAp.onClick.AddListener(orderedAp);
        OrderCrit.onClick.AddListener(orderedCrit);
        OrderDefault.onClick.AddListener(orderedDefault);
        buyButton.onClick.AddListener(buy);
        close.onClick.AddListener(closed);
    }

}
