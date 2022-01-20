using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemPanel : MonoBehaviour
{
    public GameObject buyPanel;
    public int id { get; set; }
    private void OnMouseDown()
    {
        buyPanel.SetActive(true);
        Time.timeScale = 0;
        ItemsClick ic = buyPanel.GetComponent<ItemsClick>();
        ic.id = id;
        GameObject[] weapons = GameObject.FindGameObjectsWithTag("weapon");
        Button[] items = buyPanel.GetComponentsInChildren<Button>();
        foreach (var myItem in items)
        {
            myItem.interactable = true;
        }
        foreach (var item in weapons)
        {
            MachineGun2Model mg2 = item.GetComponent<MachineGun2Model>();
            MachineGunModel mg = item.GetComponent<MachineGunModel>();
            MachineGun3Model mg3 = item.GetComponent<MachineGun3Model>();
            MachineGun4Model mg4 = item.GetComponent<MachineGun4Model>();
            MachineGun5Model mg5 = item.GetComponent<MachineGun5Model>();
            MachineGun6Model mg6 = item.GetComponent<MachineGun6Model>();

            if (mg2 != null)
            {
                if (mg2.id == id)
                {
                    
                    if (mg2.items.Count >= 6)
                    {
                        foreach(var btn in items)
                        {
                            if (btn.name != "Close")
                            {
                                btn.interactable = false;
                            }
                        }
                    }
                    for (int i = 0; i < mg2.items.Count; i++)
                    {
                        foreach (var btn in items)
                        {
                            if (btn.name == ""+mg2.items[i])
                            {
                                btn.interactable = false;
                            }
                        }
                    }
                }
            }
            else if (mg != null)
            {
                if (mg.id == id)
                {
                    if (mg.items.Count >= 6)
                    {
                        foreach (var btn in items)
                        {
                            if (btn.name != "Close")
                            {
                                btn.interactable = false;
                            }
                        }
                    }
                    for (int i = 0; i < mg.items.Count; i++)
                    {
                        foreach (var btn in items)
                        {
                            if (btn.name == "" + mg.items[i])
                            {
                                btn.interactable = false;
                            }
                        }
                    }
                }
            }
            else if (mg3 != null)
            {
                if (mg3.id == id)
                {
                    if (mg3.items.Count >= 6)
                    {
                        foreach (var btn in items)
                        {
                            if (btn.name != "Close")
                            {
                                btn.interactable = false;
                            }
                        }
                    }
                    for (int i = 0; i < mg3.items.Count; i++)
                    {
                        foreach (var btn in items)
                        {
                            if (btn.name == "" + mg3.items[i])
                            {
                                btn.interactable = false;
                            }
                        }
                    }
                }
            }
            else if (mg4 != null)
            {
                if (mg4.id == id)
                {
                    if (mg4.items.Count >= 6)
                    {
                        foreach (var btn in items)
                        {
                            if (btn.name != "Close")
                            {
                                btn.interactable = false;
                            }
                        }
                    }
                    for (int i = 0; i < mg4.items.Count; i++)
                    {
                        foreach (var btn in items)
                        {
                            if (btn.name == "" + mg4.items[i])
                            {
                                btn.interactable = false;
                            }
                        }
                    }
                }
            }
            else if (mg5 != null)
            {
                if (mg5.id == id)
                {
                    if (mg5.items.Count >= 6)
                    {
                        foreach (var btn in items)
                        {
                            if (btn.name != "Close")
                            {
                                btn.interactable = false;
                            }
                        }
                    }
                    for (int i = 0; i < mg5.items.Count; i++)
                    {
                        foreach (var btn in items)
                        {
                            if (btn.name == "" + mg5.items[i])
                            {
                                btn.interactable = false;
                            }
                        }
                    }
                }
            }
            else if (mg6 != null)
            {
                if (mg6.id == id)
                {
                    if (mg6.items.Count >= 6)
                    {
                        foreach (var btn in items)
                        {
                            if (btn.name != "Close")
                            {
                                btn.interactable = false;
                            }
                        }
                    }
                    for (int i = 0; i < mg6.items.Count; i++)
                    {
                        foreach (var btn in items)
                        {
                            if (btn.name == "" + mg6.items[i])
                            {
                                btn.interactable = false;
                            }
                        }
                    }
                }
            }
        }
    }
}
