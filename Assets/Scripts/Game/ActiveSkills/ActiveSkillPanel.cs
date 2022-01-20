using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActiveSkillPanel : MonoBehaviour
{
    public GameObject skills;
    public GameObject itemMenu;
    public GameObject upgradeMenu;
    private void OnMouseDown()
    {
        skills.SetActive(true);
        itemMenu.SetActive(false);
        upgradeMenu.SetActive(false);
    }
}
