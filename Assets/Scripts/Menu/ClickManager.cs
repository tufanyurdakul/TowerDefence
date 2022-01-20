using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    public Button btnmaps, btnweapons, btnskills, btnitems, btnoptions,play;
    public GameObject pnlmaps, pnlweapons, pnlskills, pnlitems, pnloptions;
    protected List<Button> btnList;
    protected List<GameObject> pnlList;
    // Start is called before the first frame update
    void Start()
    {
        btnList = new List<Button>();
        pnlList = new List<GameObject>();
        listAdd();
        play.onClick.AddListener(playScene);
        btnmaps.onClick.AddListener(maps);
        btnweapons.onClick.AddListener(weapon);
        btnskills.onClick.AddListener(skills);
        //btnitems.onClick.AddListener(items);
        //btnoptions.onClick.AddListener(options);
        btnmaps.interactable = false;
    }
    private void playScene()
    {
        SceneManager.LoadScene("Map2");
    }
    private void maps()
    {
        setFalse(0);
    }
    private void weapon()
    {
        setFalse(1);
    }
    private void skills()
    {
        setFalse(2);
    }
    //private void items()
    //{
    //    setFalse(3);
    //}
    //private void options()
    //{
    //    setFalse(4);
    //}
    private void listAdd()
    {
        btnList.Add(btnmaps);
        btnList.Add(btnweapons);
        btnList.Add(btnskills);
        //btnList.Add(btnitems);
        //btnList.Add(btnoptions);
        pnlList.Add(pnlmaps);
        pnlList.Add(pnlweapons);
        pnlList.Add(pnlskills);
        //pnlList.Add(pnlitems);
        //pnlList.Add(pnloptions);
    }
    private void setFalse(int index)
    {
        for (int i = 0; i<btnList.Count; i++)
        {
            if (i == index)
            {
                btnList[i].interactable = false;
                pnlList[i].SetActive(true);
            }
            else
            {
                btnList[i].interactable = true;
                pnlList[i].SetActive(false);
            }
        }
    }
    
}
