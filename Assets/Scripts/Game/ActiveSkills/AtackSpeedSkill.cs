using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtackSpeedSkill : MonoBehaviour
{
    // Start is called before the first frame update
    public Image cooldown;
    private float timer, asValue,addedtime;
    private IdGenerator ig;
    private int thetime;
    
    void Start()
    {
        GameObject idGenerator = GameObject.Find("IdGenerator");
        ig = idGenerator.GetComponent<IdGenerator>();
        Button buttonFire = gameObject.GetComponent<Button>();
        buttonFire.onClick.AddListener(asclick);
        string[] infoSkill2 = PlayerPrefs.GetString("asSkill").Split(';');
        asValue = float.Parse(infoSkill2[0]);
        thetime = int.Parse(infoSkill2[2]);
      
    }
    private void asclick()
    {
        if (timer <= 0)
        {
            addAs();
            timer = thetime;
        }
    }
    private void addAs()
    {
        GameObject[] weapons = GameObject.FindGameObjectsWithTag("weapon");
        foreach(GameObject weapon in weapons)
        {
            MachineGunModel mg = weapon.GetComponent<MachineGunModel>();
            MachineGun2Model mg2 = weapon.GetComponent<MachineGun2Model>();
            MachineGun3Model mg3 = weapon.GetComponent<MachineGun3Model>();
            MachineGun4Model mg4 = weapon.GetComponent<MachineGun4Model>();
            MachineGun5Model mg5 = weapon.GetComponent<MachineGun5Model>();
            MachineGun6Model mg6 = weapon.GetComponent<MachineGun6Model>();
            if (mg != null)
            {
                mg.atackSpeed += asValue;
                ig.addeds.Add(mg.id);
            }
            else if (mg2 != null)
            {
                mg2.atackSpeed += asValue;
                ig.addeds.Add(mg2.id);
            }
            else if (mg3 != null)
            {
                mg3.atackSpeed += asValue;
                ig.addeds.Add(mg3.id);
            }
            else if (mg4 != null)
            {
                mg4.atackSpeed += asValue;
                ig.addeds.Add(mg4.id);
            }
            else if (mg5 != null)
            {
                mg5.Bonus[0] += (int)(asValue * 50);
                ig.addeds.Add(mg5.id);
            }
            else if (mg6 != null)
            {
                mg6.atackSpeed += asValue;
                ig.addeds.Add(mg6.id);
            }
        }
        ig.isAdded = true;
    }
    // Update is called once per frame
    void Update()
    {
        timer = ig.atackspeedtimer;
        cooldown.fillAmount = timer / thetime;
    }
}
