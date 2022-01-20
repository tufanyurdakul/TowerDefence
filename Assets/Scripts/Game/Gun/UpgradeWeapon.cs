using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeWeapon : MonoBehaviour
{
    public GameObject money, level , ad , asp , ap , eb,crit,range,arpen, mrpen,damagetype;
    private GameObject myItem;
    private void OnMouseDown()
    {
        GameObject generator = GameObject.Find("IdGenerator");
        IdGenerator idGenerator = generator.GetComponent<IdGenerator>();

        myItem = null;
        GameObject[] allArea = GameObject.FindGameObjectsWithTag("createweapon");
        foreach (var item in allArea)
        {
            SpriteRenderer[] insideItems = item.GetComponentsInChildren<SpriteRenderer>();
            SpriteRenderer insideItem = insideItems[1];
            if (insideItem.color == Color.red)
            {
                myItem = item;
                break;
            }
        }
        CreateWeapon cw = myItem.GetComponent<CreateWeapon>();

        if (cw.money <= idGenerator.gold)
        {
            GameObject[] allWeapon = GameObject.FindGameObjectsWithTag("weapon");
            foreach (var item in allWeapon)
            {
                MachineGun6Model mg6 = item.GetComponent<MachineGun6Model>();

                MachineGun5Model mg5 = item.GetComponent<MachineGun5Model>();
                MachineGun4Model mg4 = item.GetComponent<MachineGun4Model>();
                MachineGun3Model mg3 = item.GetComponent<MachineGun3Model>();
                MachineGun2Model mg2 = item.GetComponent<MachineGun2Model>();
                MachineGunModel mg = item.GetComponent<MachineGunModel>();
                if (mg2 != null)
                {
                    if (mg2.id == cw.id)
                    {
                        mg2.upgrade();
                        idGenerator.gold -= cw.money;
                        cw.level++;
                        cw.money = cw.level * 75;
                        setInfText();
                        break;
                    }
                }
                else if (mg != null)
                {
                    if (mg.id == cw.id)
                    {
                        mg.upgrade();
                        idGenerator.gold -= cw.money;
                        cw.level++;
                        cw.money = cw.level * 100;
                        setInfText();
                        break;
                    }
                }
                else if (mg3 != null)
                {
                    if (mg3.id == cw.id)
                    {
                        mg3.upgrade();
                        idGenerator.gold -= cw.money;
                        cw.level++;
                        cw.money = cw.level * 50;
                        setInfText();
                        break;
                    }
                }
                else if (mg4 != null)
                {
                    if (mg4.id == cw.id)
                    {
                        mg4.upgrade();
                        idGenerator.gold -= cw.money;
                        cw.level++;
                        cw.money = cw.level * 50;
                        setInfText();
                        break;
                    }
                }
                else if (mg5 != null)
                {
                    if (mg5.id == cw.id)
                    {
                        mg5.upgrade();
                        idGenerator.gold -= cw.money;
                        cw.level++;
                        cw.money = cw.level * 100;
                        setInfText();
                        break;
                    }
                }
                else if (mg6 != null)
                {
                    if (mg6.id == cw.id)
                    {
                        mg6.upgrade();
                        idGenerator.gold -= cw.money;
                        cw.level++;
                        cw.money = cw.level * 100;
                        setInfText();
                        break;
                    }
                }
            }
        }

    }
   
    private void setInfText()
    {
        CreateWeapon cw = myItem.GetComponent<CreateWeapon>();
        TextMeshPro tmpLevel = level.GetComponent<TextMeshPro>();
        TextMeshPro tmpUpMoney = money.GetComponent<TextMeshPro>();

        tmpLevel.SetText("Level: " + cw.level);
        tmpUpMoney.SetText(cw.money + "$");
    }
  
   
}
