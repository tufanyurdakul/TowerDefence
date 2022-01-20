using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FireBombs : MonoBehaviour 
{
    private float thetime,timer = 0;
    private GameObject firebomb;
    private Transform fireTransform;
    private SpriteRenderer sp;
    public Image cooldown;
    private IdGenerator ig;

    // Start is called before the first frame update
    void Start()
    {
        Button buttonFire = gameObject.GetComponent<Button>();
        buttonFire.onClick.AddListener(fireclick);
        string[] infoSkill = PlayerPrefs.GetString("fireSkill").Split(',');
        thetime = int.Parse(infoSkill[2]);
        firebomb = Resources.Load("FireBombs") as GameObject;
        sp = gameObject.GetComponent<SpriteRenderer>();
        fireTransform = GameObject.Find("GunTransform").transform;
        GameObject idGenerator = GameObject.Find("IdGenerator");
        ig = idGenerator.GetComponent<IdGenerator>();
       
    }
    private void fireclick()
    {
        if (timer <= 0)
        {
            CreateFireBombs();
            ig.firetimer = thetime;
        }
    }
      private void CreateFireBombs()
    {
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("boxes");
        for (int count = 0; count < boxes.Length; count++)
        {

            GameObject copyBomb = Instantiate(firebomb, fireTransform.position, Quaternion.identity);
            FireBombsMovement fbm = copyBomb.GetComponent<FireBombsMovement>();
            fbm.id = count;
            Destroy(copyBomb, 3);
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer = ig.firetimer;
        cooldown.fillAmount = timer / thetime;
    }
}
