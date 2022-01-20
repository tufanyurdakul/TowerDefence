using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IdGenerator : MonoBehaviour
{
    public int id { get; set; }
    public int id2 { get; set; }
    public int gold { get; set; }
    public int score { get; set; }
    public float firetimer { get; set; }
    public float atackspeedtimer { get; set; }
    public float addedtime { get; set; }
    public List<int> addeds { get; set; }
    public bool isAdded { get; set; }
    private float skill2Time;
    private float asvalue, astimer;
    public float timer { get; set; }
    private int wave, yourmission;
    private bool firstwave, secondwave, thirdwave, fourthwave;
    private TextMeshPro tmpvawe;
    // Start is called before the first frame update
    void Awake()
    {
        wave = 1;
        addeds = new List<int>();
        id = 0;
        id2 = 0;
        gold = 350;
        string[] infoSkill1 = PlayerPrefs.GetString("fireSkill").Split(',');
        string[] infoSkill2 = PlayerPrefs.GetString("asSkill").Split(';');
        atackspeedtimer = int.Parse(infoSkill2[2]);
        astimer = atackspeedtimer;
        addedtime = float.Parse(infoSkill2[1]);
        asvalue = float.Parse(infoSkill2[0]);
        skill2Time = addedtime;
        firetimer = int.Parse(infoSkill1[2]);
        yourmission = PlayerPrefs.GetInt("mission");
    }
    private void Start()
    {
        GameObject govawe = GameObject.Find("Wave");
        tmpvawe = govawe.GetComponent<TextMeshPro>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (firetimer > 0)
        {
            firetimer -= Time.deltaTime;
        }
        if (atackspeedtimer > 0)
        {
            atackspeedtimer -= Time.deltaTime;
        }
        if (isAdded)
        {
            atackspeedtimer = astimer;
            addedtime -= Time.deltaTime;
            if (addedtime <= 0)
            {
                isAdded = false;
                addedtime = skill2Time;
                mines();
            }
        }
        if (timer > 300 && !firstwave)
        {
            missions();
            firstwave = true;
        }
        else if (timer > 510 && !secondwave)
        {
            missions();
            secondwave = true;
        }
        else if (timer > 600 && !thirdwave)
        {
            missions();
            thirdwave = true;
        }
        else if (timer > 700 && !fourthwave)
        {
            missions();
            fourthwave = true;
        }

    }
    private void missions()
    {
        if (yourmission < wave)
        {
            PlayerPrefs.GetInt("mission", wave);
        }
        wave++;
        tmpvawe.SetText("Wave:" + wave);
    }
    private void mines()
    {
        GameObject[] weapons = GameObject.FindGameObjectsWithTag("weapon");
        foreach (GameObject weapon in weapons)
        {
            MachineGunModel mg = weapon.GetComponent<MachineGunModel>();
            MachineGun2Model mg2 = weapon.GetComponent<MachineGun2Model>();
            MachineGun3Model mg3 = weapon.GetComponent<MachineGun3Model>();
            MachineGun5Model mg5 = weapon.GetComponent<MachineGun5Model>();
            MachineGun4Model mg4 = weapon.GetComponent<MachineGun4Model>();
            MachineGun6Model mg6 = weapon.GetComponent<MachineGun6Model>();
            if (mg != null)
            {
                foreach (int id in addeds)
                {
                    if (mg.id == id)
                    {
                        mg.atackSpeed -= asvalue;
                    }
                }
            }
            else if (mg2 != null)
            {
                foreach (int id in addeds)
                {
                    if (mg2.id == id)
                    {
                        mg2.atackSpeed -= asvalue;
                    }
                }
            }
            else if (mg3 != null)
            {
                foreach (int id in addeds)
                {
                    if (mg3.id == id)
                    {
                        mg3.atackSpeed -= asvalue;
                    }
                }
            }
            else if (mg4 != null)
            {
                foreach (int id in addeds)
                {
                    if (mg4.id == id)
                    {
                        mg4.atackSpeed -= asvalue;
                    }
                }
            }
            else if (mg5 != null)
            {
                foreach (int id in addeds)
                {
                    if (mg5.id == id)
                    {
                        mg5.Bonus[0] -= (int) (asvalue * 50);
                    }
                }
            }
            else if (mg6 != null)
            {
                foreach (int id in addeds)
                {
                    if (mg6.id == id)
                    {
                        mg6.atackSpeed -= asvalue;
                    }
                }
            }
        }
        addeds = new List<int>();
    }


}
