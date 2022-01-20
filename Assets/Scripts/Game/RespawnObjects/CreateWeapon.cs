using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateWeapon : MonoBehaviour
{
    public bool isCreate { get; set; } = false;
    public int id { get; set; }
    public int level { get; set; }
    public int money { get; set; }
    public GameObject menu, tad, teb;
    public GameObject upMenu, skillMenu;
    public GameObject upLevel, yourMoney, buyItem, damagepersecond, itemBuyPanel;
    public TextMeshPro dmgType;
    private TextMeshPro tmpdps;
    private int ad, eb, myrange;
    private int gunname = 0;
    public void OnMouseDown()
    {
        if (!itemBuyPanel.active)
        {
            GameObject[] allArea = GameObject.FindGameObjectsWithTag("createweapon");
            foreach (var area in allArea)
            {
                SpriteRenderer[] sp = area.GetComponentsInChildren<SpriteRenderer>();
                SpriteRenderer s = sp[1];
                s.color = Color.white;
            }
            if (!isCreate)
            {

                SpriteRenderer[] insideItems = gameObject.GetComponentsInChildren<SpriteRenderer>();
                SpriteRenderer insideItem = insideItems[1];
                insideItem.color = Color.green;
                menu.SetActive(true);
                upMenu.SetActive(false);
                skillMenu.SetActive(false);
            }
            else if (isCreate)
            {
                skillMenu.SetActive(false);
                SpriteRenderer[] insideItems = gameObject.GetComponentsInChildren<SpriteRenderer>();
                SpriteRenderer insideItem = insideItems[1];
                insideItem.color = Color.red;
                upMenu.SetActive(true);
                setInfText();
                setInfDamages();
                DpsWeapon();
                menu.SetActive(false);
                BuyItemPanel bip = buyItem.GetComponent<BuyItemPanel>();
                bip.id = id;
               


            }
            GameObject[] guns = GameObject.FindGameObjectsWithTag("weapon");
            foreach (var item in guns)
            {
                MachineGun6Model m6 = item.GetComponent<MachineGun6Model>();
                MachineGun5Model m5 = item.GetComponent<MachineGun5Model>();
                MachineGun4Model m4 = item.GetComponent<MachineGun4Model>();
                MachineGun3Model m3 = item.GetComponent<MachineGun3Model>();
                MachineGun2Model m2 = item.GetComponent<MachineGun2Model>();
                SpriteRenderer[] circleRender = item.GetComponentsInChildren<SpriteRenderer>();
                MachineGunModel m1 = item.GetComponent<MachineGunModel>();
                SpriteRenderer circle = null;
                foreach (var mysprite in circleRender)
                {
                    if (mysprite.name == "Range")
                    {
                        circle = mysprite;
                    }
                }
                if (m1 != null)
                {
                    if (m1.id == id)
                    {
                        circle.enabled = true;
                    }
                    else
                    {
                        circle.enabled = false;
                    }
                }
                if (m2 != null)
                {
                    if (m2.id == id)
                    {
                        circle.enabled = true;
                    }
                    else
                    {
                        circle.enabled = false;
                    }
                }
                if (m3 != null)
                {
                    if (m3.id == id)
                    {
                        circle.enabled = true;
                    }
                    else
                    {
                        circle.enabled = false;
                    }
                }
                if (m4 != null)
                {
                    if (m4.id == id)
                    {
                        circle.enabled = true;
                    }
                    else
                    {
                        circle.enabled = false;
                    }
                }
                if (m5 != null)
                {
                    if (m5.id == id)
                    {
                        circle.enabled = true;
                    }
                    else
                    {
                        circle.enabled = false;
                    }
                }
                if (m6 != null)
                {
                    if (m6.id == id)
                    {
                        circle.enabled = true;
                    }
                    else
                    {
                        circle.enabled = false;
                    }
                }
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        level = 1;

    }
    private void setInfText()
    {
        TextMeshPro tmpLevel = upLevel.GetComponent<TextMeshPro>();
        tmpLevel.SetText("Level: " + level);
    }
    private void setInfDamages()
    {
        TextMeshPro tmpAd = tad.GetComponent<TextMeshPro>();
    
        TextMeshPro tmpEb = teb.GetComponent<TextMeshPro>();
    

        GameObject myObject = null;
        GameObject[] items = GameObject.FindGameObjectsWithTag("itemimages");
        GameObject[] guns = GameObject.FindGameObjectsWithTag("weapon");

        foreach (var item in guns)
        {
            MachineGun6Model m6 = item.GetComponent<MachineGun6Model>();
            MachineGun5Model m5 = item.GetComponent<MachineGun5Model>();
            MachineGun4Model m4 = item.GetComponent<MachineGun4Model>();
            MachineGun3Model m3 = item.GetComponent<MachineGun3Model>();
            MachineGun2Model m2 = item.GetComponent<MachineGun2Model>();
            MachineGunModel m1 = item.GetComponent<MachineGunModel>();

            if (m2 != null)
            {
                if (m2.id == id)
                {
                    myObject = item;
                    ad = getWithBonus(m2.atackDamage, m2.Bonus[0]);
                    eb = getWithBonus(m2.flameDamage, m2.Bonus[2]);
                    myrange = m2.range;
                
                    dmgType.SetText(m2.weaponDamageType);
                    int count = 0;
                    gunname = 2;
                    foreach (var i in items)
                    {
                        SpriteRenderer sr = i.GetComponent<SpriteRenderer>();
                        if (m2.items.Count > count)
                        {
                            int myResource = 0;
                            myResource = m2.items[count];
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
            else if (m1 != null)
            {
                if (m1.id == id)
                {
                    myObject = item;
                    ad = getWithBonus(m1.atackDamage, m1.Bonus[0]);
                    eb = getWithBonus(m1.positionDamage, m1.Bonus[2]);
                    myrange = m1.range;
               
                    dmgType.SetText(m1.weaponDamageType);
                    int count = 0;
                    gunname = 1;
                    foreach (var i in items)
                    {
                        SpriteRenderer sr = i.GetComponent<SpriteRenderer>();
                        if (m1.items.Count > count)
                        {
                            int myResource = 0;
                            myResource = m1.items[count];
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
            else if (m3 != null)
            {
                if (m3.id == id)
                {
                    myObject = item;
                    ad = getWithBonus(m3.atackDamage, m3.Bonus[0]);
                    eb = getWithBonus(m3.glacierDamage, m3.Bonus[2]);
                    myrange = m3.range;
                  
                    dmgType.SetText(m3.weaponDamageType);
                    int count = 0;
                    gunname = 3;
                    foreach (var i in items)
                    {
                        SpriteRenderer sr = i.GetComponent<SpriteRenderer>();
                        if (m3.items.Count > count)
                        {
                            int myResource = 0;
                            myResource = m3.items[count];
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
            else if (m4 != null)
            {
                if (m4.id == id)
                {
                    myObject = item;
                    ad = getWithBonus(m4.atackDamage, m4.Bonus[0]);
                
                    eb = getWithBonus(m4.lightDamage, m4.Bonus[2]);
                    myrange = m4.range;
              
                    gunname = 4;
                    int count = 0;
                    foreach (var i in items)
                    {
                        SpriteRenderer sr = i.GetComponent<SpriteRenderer>();
                        if (m4.items.Count > count)
                        {
                            int myResource = 0;
                            myResource = m4.items[count];
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
            else if (m5 != null)
            {
                if (m5.id == id)
                {
                    myObject = item;
                    ad = getWithBonus(m5.atackDamage, m5.Bonus[0]);
                    eb = getWithBonus(m5.lightDamage, m5.Bonus[2]);
                    myrange = m5.range;
                
                    dmgType.SetText(m5.weaponDamageType);
                    gunname = 5;
                    int count = 0;
                    foreach (var i in items)
                    {
                        SpriteRenderer sr = i.GetComponent<SpriteRenderer>();
                        if (m5.items.Count > count)
                        {
                            int myResource = 0;
                            myResource = m5.items[count];
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
            else if (m6 != null)
            {
                if (m6.id == id)
                {
                    myObject = item;
                    ad = getWithBonus(m6.atackDamage, m6.Bonus[0]);
                
                    eb = getWithBonus(m6.flameDamage, m6.Bonus[2]);
                    myrange = m6.range;
              
                    dmgType.SetText(m6.weaponDamageType);
                    gunname = 6;
                    int count = 0;
                    foreach (var i in items)
                    {
                        SpriteRenderer sr = i.GetComponent<SpriteRenderer>();
                        if (m6.items.Count > count)
                        {
                            int myResource = 0;
                            myResource = m6.items[count];
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
        tmpAd.SetText("" + ad);
     
        tmpEb.SetText("" + eb);
     
    }
    private int getWithBonus(int based, int basedBonus)
    {
        int fully = (int)(based + (based * basedBonus * 0.01f));
        return fully;
    }
    // Update is called once per frame
    void Update()
    {
        TextMeshPro tmpYourMoney = yourMoney.GetComponent<TextMeshPro>();
        GameObject generator = GameObject.Find("IdGenerator");
        IdGenerator idGenerator = generator.GetComponent<IdGenerator>();
        tmpYourMoney.SetText("" + idGenerator.gold + "$");
        SpriteRenderer[] insideItems = gameObject.GetComponentsInChildren<SpriteRenderer>();
        SpriteRenderer insideItem = insideItems[1];
        if (isCreate && insideItem.color == Color.red)
        {
            
            GameObject[] guns = GameObject.FindGameObjectsWithTag("weapon");
            foreach (var item in guns)
            {
                MachineGun6Model m6 = item.GetComponent<MachineGun6Model>();
                MachineGun5Model m5 = item.GetComponent<MachineGun5Model>();
                MachineGun4Model m4 = item.GetComponent<MachineGun4Model>();
                MachineGun3Model m3 = item.GetComponent<MachineGun3Model>();
                MachineGun2Model m2 = item.GetComponent<MachineGun2Model>();
                MachineGunModel m1 = item.GetComponent<MachineGunModel>();
                SpriteRenderer[] circle = item.GetComponentsInChildren<SpriteRenderer>();
                SpriteRenderer circleRender = null;
                foreach (var x in circle)
                {
                    if (x.name == "Range")
                    {
                        circleRender = x;
                    }
                }
                if (m1 != null)
                {
                    if (m1.id == id)
                    {
                        if (getWithBonus(m1.atackDamage, m1.Bonus[0]) != ad || getWithBonus(m1.positionDamage, m1.Bonus[2]) != eb || m1.range != myrange)
                        {
                            if (m1.range != myrange)
                            {
                                circleRender.transform.localScale = new Vector3(Mathf.Sqrt(m1.range * 2), Mathf.Sqrt(m1.range * 2), Mathf.Sqrt(m1.range * 2));
                            }
                            ad = getWithBonus(m1.atackDamage, m1.Bonus[0]);
                            eb = getWithBonus(m1.positionDamage, m1.Bonus[2]);
                            myrange = m1.range;
                            TextMeshPro tmpAd = tad.GetComponent<TextMeshPro>();
                            TextMeshPro tmpEb = teb.GetComponent<TextMeshPro>();
                            tmpAd.SetText(""+ad);
                            tmpEb.SetText("" + eb);
                        
                        }
                        break;

                    }

                }
                else if (m2 != null)
                {
                    if (m2.id == id)
                    {
                        if (getWithBonus(m2.atackDamage, m2.Bonus[0]) != ad  || getWithBonus(m2.flameDamage, m2.Bonus[2]) != eb || m2.range != myrange)
                        {
                            if (m2.range != myrange)
                            {
                                circleRender.transform.localScale = new Vector3(Mathf.Sqrt(m2.range * 2), Mathf.Sqrt(m2.range * 2), Mathf.Sqrt(m2.range * 2));
                            }
                            ad = getWithBonus(m2.atackDamage, m2.Bonus[0]);
                            eb = getWithBonus(m2.flameDamage, m2.Bonus[2]);
                            myrange = m2.range;
                       
                            TextMeshPro tmpAd = tad.GetComponent<TextMeshPro>();                           
                            TextMeshPro tmpEb = teb.GetComponent<TextMeshPro>();            

                            tmpAd.SetText("" + ad);                           
                            tmpEb.SetText("" + eb);
                          
                        }
                        break;

                    }

                }
                else if (m3 != null)
                {
                    if (m3.id == id)
                    {
                        if (getWithBonus(m3.atackDamage, m3.Bonus[0]) != ad || getWithBonus(m3.glacierDamage, m3.Bonus[2]) != eb || m3.range != myrange)
                        {
                            if (m3.range != myrange)
                            {
                                circleRender.transform.localScale = new Vector3(Mathf.Sqrt(m3.range * 2), Mathf.Sqrt(m3.range * 2), Mathf.Sqrt(m3.range * 2));
                            }
                            ad = getWithBonus(m3.atackDamage, m3.Bonus[0]);
                           
                            eb = getWithBonus(m3.glacierDamage, m3.Bonus[2]);
                            myrange = m3.range;
                           
                            TextMeshPro tmpAd = tad.GetComponent<TextMeshPro>();                         
                            TextMeshPro tmpEb = teb.GetComponent<TextMeshPro>();                       
                            tmpAd.SetText("" + ad);                       
                            tmpEb.SetText("" + eb);
                         
                        }
                        break;

                    }

                }
                else if (m4 != null)
                {
                    if (m4.id == id)
                    {
                        if (getWithBonus(m4.atackDamage, m4.Bonus[0]) != ad  || getWithBonus(m4.lightDamage, m4.Bonus[2]) != eb || m4.range != myrange )
                        {
                            if (m4.range != myrange)
                            {
                                circleRender.transform.localScale = new Vector3(Mathf.Sqrt(m4.range * 2), Mathf.Sqrt(m4.range * 2), Mathf.Sqrt(m4.range * 2));
                            }
                            ad = getWithBonus(m4.atackDamage, m4.Bonus[0]);                           
                            eb = getWithBonus(m4.lightDamage, m4.Bonus[2]);                           
                            TextMeshPro tmpAd = tad.GetComponent<TextMeshPro>();                          
                            TextMeshPro tmpEb = teb.GetComponent<TextMeshPro>();
                            tmpAd.SetText("" + ad);                         
                            tmpEb.SetText("" + eb);
                        
                        }
                    }

                }
                if (m5 != null)
                {
                    if (m5.id == id)
                    {
                        if (getWithBonus(m5.atackDamage, m5.Bonus[0]) != ad  || getWithBonus(m5.positionDamage, m5.Bonus[2]) != eb || m5.range != myrange )
                        {
                            if (m5.range != myrange)
                            {
                                circleRender.transform.localScale = new Vector3(Mathf.Sqrt(m5.range * 2), Mathf.Sqrt(m5.range * 2), Mathf.Sqrt(m5.range * 2));
                            }
                            ad = getWithBonus(m5.atackDamage, m5.Bonus[0]);
                            eb = getWithBonus(m5.positionDamage, m5.Bonus[2]);
                            myrange = m5.range;
                          
                            TextMeshPro tmpAd = tad.GetComponent<TextMeshPro>();
                          
                            TextMeshPro tmpEb = teb.GetComponent<TextMeshPro>();
                     

                            tmpAd.SetText("" + ad);
                        
                            tmpEb.SetText("" + eb);
                         
                        }
                        break;

                    }

                }
                if (m6 != null)
                {
                    if (m6.id == id)
                    {
                        if (getWithBonus(m6.atackDamage, m6.Bonus[0]) != ad || getWithBonus(m6.flameDamage, m6.Bonus[2]) != eb || m6.range != myrange)
                        {
                            if (m6.range != myrange)
                            {
                                circleRender.transform.localScale = new Vector3(Mathf.Sqrt(m6.range * 2), Mathf.Sqrt(m6.range * 2), Mathf.Sqrt(m6.range * 2));
                            }
                            ad = getWithBonus(m6.atackDamage, m6.Bonus[0]);
                            eb = getWithBonus(m6.flameDamage, m6.Bonus[2]);
                            myrange = m6.range;
                            TextMeshPro tmpAd = tad.GetComponent<TextMeshPro>();

                            TextMeshPro tmpEb = teb.GetComponent<TextMeshPro>();


                            tmpAd.SetText("" + ad);

                            tmpEb.SetText("" + eb);

                            break;
                        }
                    }

                }
            }
           

        }

    }
    private void DpsWeapon()
    {
        GunDps gpds = damagepersecond.GetComponent<GunDps>();
        gpds.id = id;

    }
}
