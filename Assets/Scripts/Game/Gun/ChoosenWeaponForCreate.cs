using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosenWeaponForCreate : MonoBehaviour
{
    public GameObject menu;

    // Start is called before the first frame update
    private void OnMouseDown()
    {
        int price = 0;
        GameObject myItem = null;
        GameObject[] allArea = GameObject.FindGameObjectsWithTag("createweapon");
        foreach (var item in allArea)
        {
            SpriteRenderer[] insideItems = item.GetComponentsInChildren<SpriteRenderer>();
            SpriteRenderer insideItem = insideItems[1];
            if (insideItem.color == Color.green)
            {
                myItem = item;
                break;
            }
        }
        GameObject gun = null;
        if (gameObject.name == "weapon1")
        {
            gun = Resources.Load("mgun1") as GameObject;
        }
        if (gameObject.name == "weapon2")
        {
            gun = Resources.Load("mgun2") as GameObject;
        }
        if (gameObject.name == "weapon3")
        {
            gun = Resources.Load("mgun3") as GameObject;
        }
        if (gameObject.name == "weapon4")
        {
            gun = Resources.Load("mgun4") as GameObject;
        }
        if (gameObject.name == "weapon5")
        {
            gun = Resources.Load("mgun5") as GameObject;
        }
        if (gameObject.name == "weapon6")
        {
            gun = Resources.Load("mgun6") as GameObject;
        }
        price = PlayerPrefs.GetInt(gameObject.name + "price");
        if (gun != null && myItem != null)
        {
            GameObject idGenerator = GameObject.Find("IdGenerator");
            IdGenerator idg = idGenerator.GetComponent<IdGenerator>();

            if (idg.gold >= price)
            {


                GameObject myGun = Instantiate(gun, myItem.transform.position, Quaternion.identity);
                CreateWeapon cw = myItem.GetComponent<CreateWeapon>();
                MachineGun6Model mgm6 = myGun.GetComponent<MachineGun6Model>();
                MachineGun5Model mgm5 = myGun.GetComponent<MachineGun5Model>();
                MachineGun4Model mgm4 = myGun.GetComponent<MachineGun4Model>();
                MachineGun3Model mgm3 = myGun.GetComponent<MachineGun3Model>();
                MachineGun2Model mgm2 = myGun.GetComponent<MachineGun2Model>();
                MachineGunModel mgm = myGun.GetComponent<MachineGunModel>();
                idg.id2 += 1;
                cw.id = idg.id2;
                if (mgm2 != null)
                {
                    mgm2.id = idg.id2;
                    cw.money = 75;
                }
                else if (mgm != null)
                {
                    mgm.id = idg.id2;
                    cw.money = 100;
                }
                else if (mgm3 != null)
                {
                    mgm3.id = idg.id2;
                    cw.money = 50;
                }
                else if (mgm4 != null)
                {
                    mgm4.id = idg.id2;
                    cw.money = 50;
                }
                else if (mgm5 != null)
                {
                    mgm5.id = idg.id2;
                    cw.money = 100;
                }
                else if (mgm6 != null)
                {
                    mgm6.id = idg.id2;
                    cw.money = 125;
                }
                idg.gold -= price;
                cw.isCreate = true;

                menu.SetActive(false);
            }
        }
    }
    void Start()
    {

    }
}
