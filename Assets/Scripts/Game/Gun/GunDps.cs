using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GunDps : MonoBehaviour
{
    public int id { get; set; }
    private TextMeshPro tmpdps;
    // Start is called before the first frame update
    void Start()
    {
        tmpdps = gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] guns = GameObject.FindGameObjectsWithTag("weapon");
        foreach (var item in guns)
        {
            MachineGun2Model mgm2 = item.GetComponent<MachineGun2Model>();
            MachineGunModel mgm = item.GetComponent<MachineGunModel>();
            MachineGun3Model mgm3 = item.GetComponent<MachineGun3Model>();
            MachineGun4Model mgm4 = item.GetComponent<MachineGun4Model>();
            MachineGun5Model mgm5 = item.GetComponent<MachineGun5Model>();
            MachineGun6Model mgm6 = item.GetComponent<MachineGun6Model>();

            if (mgm4 != null)
            {
                if (mgm4.id == id)
                {
                    tmpdps.SetText("Damage: " + mgm4.totaldamage);
                    break;
                }
            }
            if (mgm3 != null)
            {
                if (mgm3.id == id)
                {
                    tmpdps.SetText("Damage: " + mgm3.totaldamage);
                    break;
                }
            }
            if (mgm2 != null)
            {
                if (mgm2.id == id)
                {
                    tmpdps.SetText("Damage: " + mgm2.totaldamage);
                    break;
                }
            }
            if (mgm != null)
            {
                if (mgm.id == id)
                {
                    tmpdps.SetText("Damage: " + mgm.totaldamage);
                    break;
                }
            }
            if (mgm5 != null)
            {
                if (mgm5.id == id)
                {
                    tmpdps.SetText("Damage: " + mgm5.totaldamage);
                    break;
                }
            }
            if (mgm6 != null)
            {
                if (mgm6.id == id)
                {
                    tmpdps.SetText("Damage: " + mgm6.totaldamage);
                    break;
                }
            }
        }
    }
}
