using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoxesOnHit : MonoBehaviour 
{
    public GameObject hpShow;
    private int boxHp, boxArmour, boxMaxHp, yourMaxHp, boxFlameResist, fireBombDamage, boxPositionResist, boxName, boxGlacierResist, boxLightResist, boxAtack, gunGold;
    public int boxAd { get; set; }
    public int boxID { get; set; }
    private bool hpActive = false, iced = false, item13;
    private DeleteBoxes deleteScript;
    private GameObject ice1, physicalText, flameText, fireImage, positionText, copyIceEfect, copyLightEfect, fire1, light1, position1;
    public Image hpSprite, hpB;
    public TextMeshProUGUI tmpHealth;
    private bool fireBombAtack = false, positionHit = false, flameHit = false, elektro = false, item3BonusAtack = false, book = false;
    private Animator anim;
    private float fireBombTimer = 0.2f, hpTimer = 1, iceTimer = 1f, flameHitTimer = 0.5f, nonElectroVeloctiy, elektroTimer = 1, atacktimer, boxBoss2Timer = 2;
    private FireBombsMovement ActiveSkillModel;
    private int passive1Count = 0, iceAreaId, ct;
    private bool atack, isDead, regeneration, item20, iceArea, item25passive;
    private float RestoreHp, atackTimerBackup, regenerationTimer, showHpTimer = 0.01f, showHpTimer2 = 0.1f;
    private List<float> positionArray, positionArrayTime;
    private List<int> positionArrayDamage, positionArrayId, item18Count, item18Ids, item19Count, item19Ids, item21Count, item21Ids,gun6Ids,gun6Counts;
    private GameObject goAmmo;
    private string boxAnimatorNumber = string.Empty;
    private float icedAreaX;
    private SpriteRenderer iced1, iced2, iced3, iced4;
    private List<AmmoModel> ammoes = new List<AmmoModel>();
    private List<AmmoModel> newammoes = new List<AmmoModel>();
    private Color dmgColor;
    // Start is called before the first frame update
    private void Awake()
    {
        RestoreHp = 1.5f;
        goAmmo = Resources.Load("Ammo") as GameObject;
        GameObject goIce1 = Resources.Load("IceEfect1") as GameObject;
        GameObject goIce2 = Resources.Load("IceEfect2") as GameObject;
        GameObject goIce3 = Resources.Load("IceEfect3") as GameObject;
        GameObject goIce4 = Resources.Load("IceEfect4") as GameObject;
        iced1 = goIce1.GetComponent<SpriteRenderer>();
        iced2 = goIce2.GetComponent<SpriteRenderer>();
        iced3 = goIce3.GetComponent<SpriteRenderer>();
        iced4 = goIce4.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        FirstBoxModel firstBox = gameObject.GetComponent<FirstBoxModel>();
        SecondBoxModel secondBox = gameObject.GetComponent<SecondBoxModel>();
        ThirdBoxModel thirdBox = gameObject.GetComponent<ThirdBoxModel>();
        FourthBoxModel fourthBox = gameObject.GetComponent<FourthBoxModel>();
        FifthBoxModel fifthBox = gameObject.GetComponent<FifthBoxModel>();
        SixthBoxModel sixthBox = gameObject.GetComponent<SixthBoxModel>();

        FirstBossBoxModel firstBossBox = gameObject.GetComponent<FirstBossBoxModel>();
        SecondBossBoxModel secondBossBox = gameObject.GetComponent<SecondBossBoxModel>();
      
        if (firstBox != null)
        {
            boxHp = firstBox.boxHealth;
            boxAd = firstBox.boxDamage;
            boxArmour = firstBox.boxArmour;
            boxMaxHp = firstBox.boxHealth;
            boxFlameResist = firstBox.boxFlameResist;
            boxPositionResist = firstBox.boxPositionResist;
            boxGlacierResist = firstBox.boxGlacierResist;
            boxLightResist = firstBox.boxLightResist;
            boxAtack = firstBox.boxDamage;
            gunGold = 10;
            boxName = 1;

        }
        else if (secondBox != null)
        {
            boxHp = secondBox.boxHealth;
            boxAd = secondBox.boxDamage;
            boxArmour = secondBox.boxArmour;
            boxMaxHp = secondBox.boxHealth;
            boxFlameResist = secondBox.boxFlameResist;
            boxPositionResist = secondBox.boxPositionResist;
            boxGlacierResist = secondBox.boxGlacierResist;
            boxLightResist = secondBox.boxLightResist;
            boxAtack = secondBox.boxDamage;
            gunGold = 20;
            boxName = 2;
        }
        else if (thirdBox != null)
        {
            boxHp = thirdBox.boxHealth;
            boxAd = thirdBox.boxDamage;
            boxArmour = thirdBox.boxArmour;
            boxMaxHp = thirdBox.boxHealth;
            boxFlameResist = thirdBox.boxFlameResist;
            boxPositionResist = thirdBox.boxPositionResist;
            boxGlacierResist = thirdBox.boxGlacierResist;
            boxLightResist = thirdBox.boxLightResist;
            boxAtack = thirdBox.boxDamage;
            gunGold = 30;
            boxName = 3;
            boxAnimatorNumber = "3";
        }
        else if (firstBossBox != null)
        {
            boxHp = firstBossBox.boxHealth;
            boxAd = firstBossBox.boxDamage;
            boxArmour = firstBossBox.boxArmour;
            boxMaxHp = firstBossBox.boxHealth;
            boxFlameResist = firstBossBox.boxFlameResist;
            boxPositionResist = firstBossBox.boxPositionResist;
            boxGlacierResist = firstBossBox.boxGlacierResist;
            boxLightResist = firstBossBox.boxLightResist;
            boxAtack = firstBossBox.boxDamage;
            gunGold = 40;
            boxName = 4;
        }
        else if (fourthBox != null)
        {
            boxHp = fourthBox.boxHealth;
            boxAd = fourthBox.boxDamage;
            boxArmour = fourthBox.boxArmour;
            boxMaxHp = fourthBox.boxHealth;
            boxFlameResist = fourthBox.boxFlameResist;
            boxPositionResist = fourthBox.boxPositionResist;
            boxGlacierResist = fourthBox.boxGlacierResist;
            boxLightResist = fourthBox.boxLightResist;
            boxAtack = fourthBox.boxDamage;
            boxAnimatorNumber = "4";
            gunGold = 50;
            boxName = 5;
        }
        else if (secondBossBox != null)
        {
            boxHp = secondBossBox.boxHealth;
            boxAd = secondBossBox.boxDamage;
            boxArmour = secondBossBox.boxArmour;
            boxMaxHp = secondBossBox.boxHealth;
            boxFlameResist = secondBossBox.boxFlameResist;
            boxPositionResist = secondBossBox.boxPositionResist;
            boxGlacierResist = secondBossBox.boxGlacierResist;
            boxLightResist = secondBossBox.boxLightResist;
            boxAtack = secondBossBox.boxDamage;
            gunGold = 50;
            boxName = 6;
        }
        else if (fifthBox != null)
        {
            boxHp = fifthBox.boxHealth;
            boxAd = fifthBox.boxDamage;
            boxArmour = fifthBox.boxArmour;
            boxMaxHp = fifthBox.boxHealth;
            boxFlameResist = fifthBox.boxFlameResist;
            boxPositionResist = fifthBox.boxPositionResist;
            boxGlacierResist = fifthBox.boxGlacierResist;
            boxLightResist = fifthBox.boxLightResist;
            boxAtack = fifthBox.boxDamage;
            boxAnimatorNumber = "5";
            gunGold = 55;
            boxName = 7;
        }
        else if (sixthBox != null)
        {
            boxHp = sixthBox.boxHealth;
            boxAd = sixthBox.boxDamage;
            boxArmour = sixthBox.boxArmour;
            boxMaxHp = sixthBox.boxHealth;
            boxFlameResist = sixthBox.boxFlameResist;
            boxPositionResist = sixthBox.boxPositionResist;
            boxGlacierResist = sixthBox.boxGlacierResist;
            boxLightResist = sixthBox.boxLightResist;
            boxAtack = sixthBox.boxDamage;
            boxAnimatorNumber = "6";
            gunGold = 55;
            boxName = 8;
        }
        fireImage = Resources.Load("FireEfect") as GameObject;
        ice1 = Resources.Load("ice1") as GameObject;
        fire1 = Resources.Load("flame1") as GameObject;
        light1 = Resources.Load("light1") as GameObject;
        position1 = Resources.Load("position1") as GameObject;
        physicalText = Resources.Load("PhysicalText") as GameObject;
        flameText = Resources.Load("FlameText") as GameObject;
        positionText = Resources.Load("PositionText") as GameObject;


        GameObject deletebox = GameObject.Find("DeleteBoxes");
        deleteScript = deletebox.GetComponent<DeleteBoxes>();
        yourMaxHp = deleteScript.maxHealth;
        Rigidbody2D boxVelocity = gameObject.GetComponent<Rigidbody2D>();
        nonElectroVeloctiy = boxVelocity.velocity.x;
        positionArray = new List<float>();
        positionArrayTime = new List<float>();
        positionArrayDamage = new List<int>();
        positionArrayId = new List<int>();
        item18Count = new List<int>();
        item18Ids = new List<int>();
        item19Count = new List<int>();
        item19Ids = new List<int>();
        item21Count = new List<int>();
        item21Ids = new List<int>();
        gun6Ids = new List<int>();
        gun6Counts = new List<int>();

        tmpHealth.SetText($"{boxHp}/{ boxMaxHp}");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hit = collision.gameObject;
        if (hit.tag == "ammo")
        {
            item25passive = false;
            item20 = false;
            book = false;
            bool bounce = false;
            item13 = false;
            int item18 = 1;
            int item19 = 1;
            int item21 = 1;
            int item24 = 0;
            AmmoModel ammo = hit.GetComponent<AmmoModel>();
            if (ammo.ids.Count > 0)
            {
                foreach (var ids in ammo.ids)
                {
                    if (ids == boxID)
                    {
                        bounce = true;
                        break;
                    }
                }
                if (!bounce)
                {
                    if (ammo.bounceid != boxID)
                    {
                        bounce = true;
                    }
                }

            }
           
            
            if (!bounce)
            {
                foreach (var item in ammo.items)
                {
                    if (item == 2)
                    {
                        int damage = (int)((float)boxHp * 3 * 0.01f);
                        int atack = GetHitDamageWithResist(damage, damage, damage, damage, damage, ammo.weaponDamageType);
                        OtherDamages(atack, ammo.weaponDamageType, ammo.gunname, ammo.gunid);
                    }
                    else if (item == 3)
                    {
                        if (boxHp < (int)(boxMaxHp / 2))
                        {
                            item3BonusAtack = true;
                        }
                        else
                        {
                            item3BonusAtack = false;
                        }
                    }
                    else if (item == 4)
                    {
                        book = true;
                        if (iced)
                        {
                            int atack = GetHitDamageWithResist(0, 0, 10, 0, ammo.magicPenetration, "icedamage");
                            OtherDamages(atack, "icedamage", ammo.gunname, ammo.gunid);
                        }
                    }
                    else if (item == 13)
                    {
                        item13 = true;
                    }
                    else if (item == 14)
                    {
                        bool create = true;

                        if (ammo.countBounce > 3)
                        {
                            create = false;
                            Destroy(hit);
                        }
                        if (create)
                        {
                            GameObject[] anotherBox = GameObject.FindGameObjectsWithTag("boxes");
                            if (anotherBox.Length > ammo.ids.Count)
                            {
                                GameObject bounceAmmo = Instantiate(goAmmo, gameObject.transform.position, gameObject.transform.rotation);
                                AmmoModel model = bounceAmmo.GetComponent<AmmoModel>();
                                if (ammo.isBounce)
                                {
                                    model.ids = ammo.ids;
                                    model.countBounce = ammo.countBounce;
                                    model.countBounce++;

                                }
                                model.ids.Add(boxID);
                                model.atackDamage = 1 + (int)((float)ammo.atackDamage * 0.5f);
                                model.flameDamage = 1 + (int)((float)ammo.flameDamage * 0.5f);
                                model.criticaldamage = ammo.criticaldamage;
                                model.criticalChance = ammo.criticalChance;
                                model.glacierDamage = 1 + (int)((float)ammo.glacierDamage * 0.5f);
                                model.positionDamage = 1 + (int)((float)ammo.positionDamage * 0.5f);
                                model.lightDamage = 1 + (int)((float)ammo.lightDamage * 0.5f);
                                model.weaponDamageType = ammo.weaponDamageType;
                                model.bonusAtack = 1 + (int)((float)ammo.bonusAtack * 0.5f);
                                model.bonusAp = 1 + (int)(ammo.bonusAp * 0.5f);
                                model.elementalBonus = 1 + (int)((float)ammo.elementalBonus * 0.5f);
                                model.armorPenetration = ammo.armorPenetration;
                                model.magicPenetration = ammo.magicPenetration;
                                model.magic = 1 + (int)((float)ammo.magic * 0.5f);
                                model.items = ammo.items;
                                model.passive = ammo.passive;
                                model.gunid = ammo.gunid;
                                model.gunname = ammo.gunname;
                                model.isBounce = true;
                            }

                        }
                    }
                    else if (item == 17)
                    {
                        regeneration = true;
                        regenerationTimer = 2;
                    }
                    else if (item == 18)
                    {
                        bool insert = false;
                        if (item18Ids.Count > 0)
                        {
                            for (int i = 0; i < item18Ids.Count; i++)
                            {
                                if (item18Ids[i] == ammo.gunid)
                                {
                                    item18Count[i]++;
                                    insert = true;
                                    if (item18Count[i] % 3 == 0)
                                    {
                                        item18 = 2;
                                        break;
                                    }
                                }
                            }
                        }
                        if (!insert)
                        {
                            item18Count.Add(1);
                            item18Ids.Add(ammo.gunid);
                        }
                    }
                    else if (item == 19)
                    {
                        bool insert = false;
                        if (item19Ids.Count > 0)
                        {
                            for (int i = 0; i < item19Ids.Count; i++)
                            {
                                if (item19Ids[i] == ammo.gunid)
                                {
                                    item19Count[i]++;
                                    insert = true;
                                    if (item19Count[i] % 3 == 0)
                                    {
                                        item19 = 2;
                                        break;
                                    }
                                }
                            }
                        }
                        if (!insert)
                        {
                            item19Count.Add(1);
                            item19Ids.Add(ammo.gunid);
                        }
                    }
                    else if (item == 20)
                    {
                        item20 = true;
                    }
                    else if (item == 21)
                    {
                        bool insert = false;
                        if (item21Ids.Count > 0)
                        {
                            for (int i = 0; i < item21Ids.Count; i++)
                            {
                                if (item21Ids[i] == ammo.gunid)
                                {
                                    item21Count[i]++;
                                    insert = true;
                                    if (item21Count[i] % 3 == 0)
                                    {
                                        item21 = 2;
                                        break;
                                    }
                                }
                            }
                        }
                        if (!insert)
                        {
                            item21Count.Add(1);
                            item21Ids.Add(ammo.gunid);
                        }
                    }
                    else if (item == 24)
                    {
                        item24 = 10;
                    }
                    else if (item == 25)
                    {
                        item25passive = true;
                    }
                }
                if (ammo.gunname == 5)
                {
                    ammo.atackDamage += item24;
                    ammoes.Add(ammo);

                }
                else
                {
                    if (ammo.gunname != 6)
                    {
                        PhysicalDamage(ammo.atackDamage + item24, ammo.bonusAtack, ammo.lifeSteal, ammo.criticalChance, ammo.criticaldamage, ammo.armorPenetration, ammo.gunname, ammo.gunid);
                    }
                }
                if (ammo.item1Passive > 0 && ammo.item1Passive % 3 == 0)
                {
                    boxArmour -= (int)((boxArmour * 15) / 100);
                }
                int bonusAp = ammo.gunname == 6 ? ammo.bonusAtack : 0;
                int flamedamage6 = 0;
                if (ammo.passive.ToLower().Replace(" ", "") == "increaseflame")
                {

                    bool insert = false;
                    int count6 = 0;
                    if (gun6Ids.Count > 0)
                    {
                        for (int i = 0; i < gun6Ids.Count; i++)
                        {
                            if (gun6Ids[i] == ammo.gunid)
                            {
                                gun6Counts[i]++;
                                count6 = gun6Counts[i];
                                insert = true;
                            }
                        }
                    }
                    if (!insert)
                    {
                        gun6Counts.Add(1);
                        gun6Ids.Add(ammo.gunid);
                    }
                    flamedamage6 = (int)(ammo.flameDamage * 0.1f * count6);
                    OtherDamages(ammo.weaponDamageType, (ammo.flameDamage + flamedamage6) * item18, ammo.glacierDamage * item19, ammo.lightDamage * item21, ammo.positionDamage, ammo.elementalBonus, ammo.magic, ammo.bonusAp + bonusAp, ammo.magicPenetration,ammo.criticalChance,ammo.criticaldamage, ammo.gunname, ammo.gunid);

                }
                else
                {
                    OtherDamages(ammo.weaponDamageType, (ammo.flameDamage + flamedamage6) * item18, ammo.glacierDamage * item19, ammo.lightDamage * item21, ammo.positionDamage, ammo.elementalBonus, ammo.magic, ammo.bonusAp + bonusAp, ammo.magicPenetration, ammo.gunname, ammo.gunid);
                    Passive(ammo.passive, ammo.weaponDamageType, ammo.flameDamage * item18, ammo.glacierDamage * item19, ammo.lightDamage, ammo.positionDamage, ammo.elementalBonus, ammo.magic, ammo.bonusAp + bonusAp, ammo.magicPenetration, ammo.gunid);
                }
               
                if (ammo.gunname != 5)
                {
                    Destroy(hit);
                }


            }

        }
        if (hit.tag == "explosion")
        {
            ExplosionAnimation ex = hit.GetComponent<ExplosionAnimation>();
            if (ex.boxid != boxID)
            {
                OtherDamages(ex.Atack, ex.DamageType, 2, ex.gunid);
            }
        }
        if (hit.tag == "firebomb")
        {

            ActiveSkillModel = hit.GetComponent<FireBombsMovement>();
            if (ActiveSkillModel.boxID == boxID)
            {
                fireBombDamage = (int)(ActiveSkillModel.flamedamage * 0.01f * boxMaxHp);
                fireBombDamage = GetFlameDamageWithResist(fireBombDamage, ActiveSkillModel.magicPen);
                fireBombAtack = true;
                Destroy(hit);
            }

        }
        if (hit.name == "DeleteBoxes")
        {
            if (!anim.GetBool("isAtack"))
            {
                anim.SetBool("isAtack", true);
                Rigidbody2D boxV = gameObject.GetComponent<Rigidbody2D>();
                boxV.velocity = new Vector2(0, 0);
            }
        }
        IceArea icearea = hit.GetComponent<IceArea>();
        if (hit.tag == "icedarea" && icearea.id != boxID)
        {
            iceAreaId = icearea.id;
            Rigidbody2D boxV = gameObject.GetComponent<Rigidbody2D>();
            icedAreaX = boxV.velocity.x;
            iceArea = true;
            boxV.velocity = new Vector3(icedAreaX * 0.75f, 0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject hit = collision.gameObject;
        IceArea icearea = hit.GetComponent<IceArea>();
        if (hit.tag == "icedarea" && icearea.id != boxID)
        {
            Rigidbody2D boxV = gameObject.GetComponent<Rigidbody2D>();
            iceArea = false;
            if (boxV.velocity.x + (icedAreaX * 0.25f) < nonElectroVeloctiy)
            {
                boxV.velocity = new Vector2(nonElectroVeloctiy, 0);

            }
            else
            {
                boxV.velocity = new Vector2(boxV.velocity.x + (icedAreaX * 0.25f), 0);

            }
        }
        if (hit.tag == "ammo")
        {

            AmmoModel m = hit.GetComponent<AmmoModel>();
            if (m.gunname == 5)
            {
                for (int i = 0; i < ammoes.Count; i++)
                {
                    if (ammoes[i].count == m.count)
                    {
                        newammoes.Add(ammoes[i]);
                        ammoes.RemoveAt(i);
                    }
                }
                bool isWrite = false;
                int count = 0;
                for (int x = 0; x < newammoes.Count; x++)
                {
                    bool isthere = false;
                    foreach (var item in ammoes)
                    {
                        if (item.count == newammoes[x].count)
                        {
                            isthere = true;
                            break;
                        }
                    }
                    if (isthere)
                    {
                        break;
                    }
                    else
                    {
                        isWrite = true;
                        count++;
                        break;
                    }

                }
                if (isWrite)
                {
                    int ad = 0;
                    int id = 0;
                    int gunname = 0;
                    for (int i = 0; i < newammoes.Count; i++)
                    {
                        ad += GetPhysicalDamage(newammoes[i].atackDamage, newammoes[i].bonusAtack, newammoes[i].lifeSteal, newammoes[i].criticalChance, newammoes[i].criticaldamage, newammoes[i].armorPenetration, newammoes[i].gunname, newammoes[i].gunid);
                        id = newammoes[i].gunid;
                        gunname = newammoes[i].gunname;
                        newammoes.RemoveAt(i);
                        i--;
                    }
                    HitDamage(ad, gunname, id);
                    GameObject physicalDamageText = Instantiate(physicalText, gameObject.transform.position, Quaternion.identity);
                    TextMeshPro tmpPhysical = physicalDamageText.GetComponent<TextMeshPro>();
                    Rigidbody2D rbText = physicalDamageText.GetComponent<Rigidbody2D>();
                    rbText.velocity = new Vector2(0, 3);
                    tmpPhysical.SetText("" + ad);
                    Destroy(physicalDamageText, 0.5f);
                }
                Destroy(hit.gameObject);
            }

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (hpActive)
        {
            hpTimer -= Time.deltaTime;
            hpShow.SetActive(true);
            if (hpSprite.fillAmount != calculateHp())
            {
                showHpTimer -= Time.deltaTime;
                if (showHpTimer <= 0)
                {
                    float value = calculateHp();
                    if (hpSprite.fillAmount - (value / 5) > value)
                    {
                        hpSprite.fillAmount -= (value / 5);

                    }
                    else if (hpSprite.fillAmount + (value / 5) < value)
                    {
                        hpSprite.fillAmount += (value / 5);
                    }
                    else
                    {
                        hpSprite.fillAmount = value;

                    }
                    showHpTimer = 0.01f;
                }

                tmpHealth.SetText($"{boxHp}/{ boxMaxHp}");
            }
            if (hpTimer <= 0)
            {
                hpShow.SetActive(false);
                hpActive = false;
                hpTimer = 2;
            }
        }
        
        if (hpB.fillAmount != hpSprite.fillAmount)
        {
            showHpTimer2 -= Time.deltaTime;
            if (showHpTimer2 <= 0)
            {
                if (hpB.fillAmount - (hpSprite.fillAmount / 5) > hpSprite.fillAmount)
                {
                    hpB.fillAmount -= (hpSprite.fillAmount / 5);

                }
                else if (hpB.fillAmount + (hpSprite.fillAmount / 5) < hpSprite.fillAmount)
                {
                    hpB.fillAmount += (hpSprite.fillAmount / 5);
                }
                else
                {
                    hpB.fillAmount = hpSprite.fillAmount;

                }
                hpB.color = dmgColor;
                showHpTimer2 = 0.1f;
            }
        }

        if (iceArea)
        {
            bool isId = false;
            GameObject[] iceAreas = GameObject.FindGameObjectsWithTag("icedarea");
            foreach (var iceArea in iceAreas)
            {
                IceArea ia = iceArea.GetComponent<IceArea>();
                if (ia.id == iceAreaId)
                {
                    isId = true;
                    break;
                }
            }
            if (!isId)
            {
                Rigidbody2D boxV = gameObject.GetComponent<Rigidbody2D>();
                if (boxV.velocity.x + (icedAreaX * 0.25f) < nonElectroVeloctiy)
                {
                    boxV.velocity = new Vector2(nonElectroVeloctiy, 0);

                }
                else
                {
                    boxV.velocity = new Vector2(boxV.velocity.x + (icedAreaX * 0.25f), 0);

                }
                iceArea = false;
            }
        }
        if (boxHp < boxMaxHp)
        {
            float multiply = regeneration ? 0.5f : 1;
            RestoreHp -= Time.deltaTime;
            if (RestoreHp <= 0)
            {
                int restore = (int)((float)(boxMaxHp - boxHp) * 0.05f * multiply);
                if (boxName == 7)
                {
                    restore = (int)((float)(boxMaxHp - boxHp) * 0.1f * multiply);
                }
                if (boxHp + restore >= boxMaxHp)
                {
                    boxHp = boxMaxHp;
                }
                else
                {
                    boxHp += restore;
                }
                RestoreHp = 2;
            }
        }
        if (regenerationTimer > 0)
        {
            regenerationTimer -= Time.deltaTime;
        }
        if (regenerationTimer < 0 && regeneration)
        {
            regenerationTimer = 0;
            regeneration = false;
        }
        if (boxName == 6)
        {
            boxBoss2Timer -= Time.deltaTime;
            if (boxBoss2Timer <= 0)
            {
                boxFlameResist += 4;
                boxGlacierResist += 2;
                boxPositionResist += 1;
                boxLightResist += 1;
                boxBoss2Timer = 2.5f;
            }
        }
        if (fireBombAtack)
        {
            if (fireBombTimer > 0)
            {
                fireBombTimer -= Time.deltaTime;
            }
            if (fireBombTimer <= 0)
            {
                Instantiate(fireImage, transform.position, transform.rotation);
                OtherDamages(fireBombDamage, "flamedamage", 2, 0);
                fireBombTimer = 0.5f;
            }
        }
        if (positionArray.Count > 0 && positionArrayTime.Count > 0)
        {
            for (int i = 0; i < positionArray.Count; i++)
            {
                positionArray[i] -= Time.deltaTime;
                positionArrayTime[i] -= Time.deltaTime;
                if (positionArray[i] < 0)
                {
                    positionArray.RemoveAt(i);
                    positionArrayTime.RemoveAt(i);
                    positionArrayDamage.RemoveAt(i);
                    positionArrayId.RemoveAt(i);
                    break;
                }
                else
                {
                    if (positionArrayTime[i] <= 0)
                    {
                        OtherDamages("poison", 0, 0, 0, positionArrayDamage[i], 0, 0, 0, 0, 1, positionArrayId[i]);
                        positionArrayTime[i] = 1;
                    }
                }
            }
        }

        if (iced)
        {
            iceTimer -= Time.deltaTime;
            if (iceTimer <= 0)
            {
                Rigidbody2D rgBox = gameObject.GetComponent<Rigidbody2D>();
                if (!anim.GetBool("isAtack"))
                {
                    rgBox.velocity = new Vector2(nonElectroVeloctiy, 0);
                }
                iced = false;
                iceTimer = 1;
            }
            else
            {
                if (iceTimer < 0.85f && iceTimer > 0.65)
                {
                    SpriteRenderer iced0 = copyIceEfect.GetComponent<SpriteRenderer>();
                    iced0.sprite = iced1.sprite;
                }
                else if (iceTimer <= 0.7f && iceTimer > 0.5f)
                {
                    SpriteRenderer iced0 = copyIceEfect.GetComponent<SpriteRenderer>();
                    iced0.sprite = iced2.sprite;
                }
                else if (iceTimer <= 0.5f && iceTimer > 0.25f)
                {
                    SpriteRenderer iced0 = copyIceEfect.GetComponent<SpriteRenderer>();
                    iced0.sprite = iced3.sprite;
                }
                else if (iceTimer < 0.25f)
                {
                    SpriteRenderer iced0 = copyIceEfect.GetComponent<SpriteRenderer>();
                    iced0.sprite = iced4.sprite;
                }

            }
        }
        if (flameHit)
        {
            flameHitTimer -= Time.deltaTime;
            if (flameHitTimer <= 0)
            {
                flameHit = true;
                flameHitTimer = 0.5f;
            }
        }
        if (elektro)
        {
            if (copyLightEfect != null)
            {

                if (copyLightEfect.transform.localScale.y < 0.8f)
                {
                    if (copyLightEfect.transform.localScale.y + 0.01f > 0.8f)
                    {
                        copyLightEfect.transform.localScale = new Vector3(0.8f, 0.8f, 0);
                    }
                    else
                    {
                        copyLightEfect.transform.localScale += new Vector3(0, 0.01f, 0);
                    }
                }
                if (copyLightEfect.transform.localScale.y >= 0.8f)
                {
                    Rigidbody2D rgBox = gameObject.GetComponent<Rigidbody2D>();
                    if (copyIceEfect != null)
                    {
                        copyIceEfect.GetComponent<SpriteRenderer>().sprite = iced4.sprite;
                        Destroy(copyIceEfect, 0.25f);
                        iced = false;
                        iceTimer = 1f;
                        elektroTimer += 0.5f;

                    }
                    rgBox = gameObject.GetComponent<Rigidbody2D>();
                    rgBox.velocity = new Vector2(0, 0);
                    Destroy(copyLightEfect);
                }
            }
            else
            {
                elektroTimer -= Time.deltaTime;
                if (elektroTimer <= 0)
                {
                    Rigidbody2D rgBox = gameObject.GetComponent<Rigidbody2D>();
                    if (!anim.GetBool("isAtack"))
                    {
                        rgBox.velocity = new Vector2(nonElectroVeloctiy, 0);
                    }
                    elektro = false;
                    elektroTimer = 1;
                }
            }
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("atack" + boxAnimatorNumber) && !atack)
        {
            atacktimer = anim.runtimeAnimatorController.animationClips[1].length * (1 / anim.GetCurrentAnimatorStateInfo(0).speed);
            atackTimerBackup = atacktimer;
            atack = true;
        }
        if (atack)
        {
            atacktimer -= Time.deltaTime;
            if (atacktimer <= 0)
            {
                GameObject castle = GameObject.Find("DeleteBoxes");
                DeleteBoxes db = castle.GetComponent<DeleteBoxes>();
                db.yourHealth -= boxAtack;
                atacktimer = atackTimerBackup;
            }
        }
    }
    private int GetPhysicalDamage(int atackDamage, int atackBonus, int lifesteal, int critical, int criticaldamage, int armorPen, int gunName, int id)
    {
        float add = 100 + (boxArmour - (boxArmour * 0.01f * armorPen));
        float armour = (100 / add);
        int atack = (int)(atackDamage + (atackDamage * atackBonus * 0.01f));
        bool crit = false;
        bool isExecute = false;
        if (critical > 0)
        {
            bool hitCritical = critical >= GetRandom();
            if (hitCritical)
            {
                if (item13)
                {
                    isExecute = item13Passive();
                }
                atack = HitCritical(atack, critical, criticaldamage);
                crit = true;
            }
        }
        atack = (int)(atack * armour);
        if (item3BonusAtack)
        {
            atack = (int)(atack + (int)((float)atack * 0.12f));

        }

        if (lifesteal > 0)
        {
            LifeSteal(atack, lifesteal);
        }






        if (crit)
        {
            if (item25passive)
            {
                atack += 30;
            }
        }

        if (isExecute)
        {
            atack = boxHp + 1;
        }
        return atack;
    }

    private void PhysicalDamage(int atackDamage, int atackBonus, int lifesteal, int critical, int criticaldamage, int armorPen, int gunName, int id)
    {
        ct++;
        float add = 100 + (boxArmour - (boxArmour * 0.01f * armorPen));
        float armour = (100 / add);
        int atack = (int)(atackDamage + (atackDamage * atackBonus * 0.01f));
        bool crit = false;
        bool isExecute = false;
        if (critical > 0)
        {
            bool hitCritical = critical >= GetRandom();
            if (hitCritical)
            {
                if (item13)
                {
                    isExecute = item13Passive();
                }
                atack = HitCritical(atack, critical, criticaldamage);
                crit = true;
            }
        }
        atack = (int)(atack * armour);
        if (item3BonusAtack)
        {
            atack = (int)(atack + (int)((float)atack * 0.12f));

        }

        if (lifesteal > 0)
        {
            LifeSteal(atack, lifesteal);
        }



        Vector3 v3;
        Vector3 v4 = Vector3.zero;

        if (passive1Count % 3 == 0 && passive1Count != 0)
        {
            v3 = new Vector3(0, -1, 0);
        }
        else
        {
            v3 = new Vector3(0, 0, 0);

        }


        if (crit)
        {
            if (item25passive)
            {
                atack += 30;
            }
        }
        if (!isExecute)
        {
            HitDamage(atack, gunName, id);
        }
        if (isExecute)
        {
            atack = boxHp + 1;
            HitDamage(boxHp + 1, gunName, id);
        }

        if (ct % 3 == 1)
        {
            v4 = new Vector3(0.7f, 0, 0);
        }
        else if (ct % 3 == 2)
        {
            v4 = new Vector3(-0.7f, 0, 0);
        }
        GameObject physicalDamageText = Instantiate(physicalText, gameObject.transform.position + v3 + v4, Quaternion.identity);
        TextMeshPro tmpPhysical = physicalDamageText.GetComponent<TextMeshPro>();
        Rigidbody2D rbText = physicalDamageText.GetComponent<Rigidbody2D>();
        rbText.velocity = new Vector2(0, 3);
        tmpPhysical.SetText("" + atack);
        Destroy(physicalDamageText, 0.5f);



    }
    public void Passive(string passive, string damageType, int flamedamage, int glacierdamage, int lightdamage, int positiondamage, int elementalbonus, int magic, int magicbonus, int magicpen, int id)
    {
        int atack = 0;
        if (passive.ToLower().Replace(" ", "") == "explosion")
        {
            if (damageType.ToLower().Replace(" ", "") == "flamedamage")
            {
                atack = (int)(flamedamage + (flamedamage * (elementalbonus) * 0.01f) + (glacierdamage / 5) + (lightdamage / 5) + (positiondamage / 5) + ((magic * 0.5f) + ((magic * 0.5f) * magicbonus * 0.01f)));
                GameObject explosion = Resources.Load("Explosion") as GameObject;
                GameObject copyExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
                ExplosionAnimation model = copyExplosion.GetComponent<ExplosionAnimation>();
                model.Atack = atack;
                model.gunid = id;
                model.boxid = this.boxID;
            }
        }
        else if (passive.ToLower().Replace(" ", "") == "poison")
        {
            if (damageType.ToLower().Replace(" ", "") == "poisondamage")
            {
                positionArray.Add(4);
                positionArrayTime.Add(0.5f);
                positionArrayDamage.Add(positiondamage);
                positionArrayId.Add(id);
            }
        }
        else if (passive.ToLower().Replace(" ", "") == "freeze")
        {
            if (!iced)
            {
                if (damageType.ToLower().Replace(" ", "") == "icedamage")
                {
                    float iceDefance = (float)(100 / (100 + (float)boxGlacierResist));
                    float number = ((float)((glacierdamage + magic) * 2)) * iceDefance;
                    float icedPercent = (1 - (100 / (100 + (((float)glacierdamage * 3) + ((float)magic) * 2)))) * iceDefance;
                    int myRandom = GetRandom();
                    if (myRandom <= (int)number)
                    {
                        Rigidbody2D rgBox = gameObject.GetComponent<Rigidbody2D>();
                        rgBox.velocity = new Vector2(rgBox.velocity.x - (rgBox.velocity.x * icedPercent), 0);
                        GameObject iceeffect = (GameObject)Resources.Load("IceEfect");
                        copyIceEfect = Instantiate(iceeffect, gameObject.transform.position, gameObject.transform.rotation);
                        copyIceEfect.transform.SetParent(gameObject.transform);
                        if (item20)
                        {
                            GameObject icedArea = (GameObject)Resources.Load("IceArea");
                            GameObject copyIceArea = Instantiate(icedArea, gameObject.transform.position, gameObject.transform.rotation);
                            copyIceArea.transform.SetParent(gameObject.transform);
                            IceArea icearea = copyIceArea.GetComponent<IceArea>();
                            icearea.id = boxID;
                        }
                        if (book)
                        {
                            iceTimer += 2.5f;
                        }
                        Destroy(copyIceEfect, iceTimer);
                        iced = true;
                    }
                }
            }
        }
        else if (passive.ToLower().Replace(" ", "") == "elektroshock")
        {

            if (damageType.ToLower().Replace(" ", "") == "lightdamage")
            {
                float lightDefance = (float)(100 / (100 + (float)boxLightResist));
                float number = ((float)((lightdamage + magic))) * lightDefance;
                if (iced)
                {
                    number *= 5;
                }
                int myRandom = GetRandom();
                if (myRandom <= (int)number)
                {
                    if (!elektro)
                    {
                        Rigidbody2D rgBox = gameObject.GetComponent<Rigidbody2D>();
                        nonElectroVeloctiy = rgBox.velocity.x;
                        rgBox.velocity = new Vector2(rgBox.velocity.x - (rgBox.velocity.x * 0), 0);
                        GameObject lightEfect = (GameObject)Resources.Load("lightEffect");
                        copyLightEfect = Instantiate(lightEfect, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), gameObject.transform.rotation);
                        copyLightEfect.transform.SetParent(gameObject.transform);
                        copyLightEfect.transform.localScale = new Vector3(0.3f, 0.01f, 0);
                        Destroy(copyLightEfect, 2);
                        elektro = true;
                    }

                }
            }

        }
    }
    public int GetFlameDamageWithResist(int flameatack, int magicpen)
    {
        float flameresist = 100 + (boxFlameResist - (boxFlameResist * 0.01f * magicpen));
        float resistance = (100 / flameresist);
        flameatack = (int)(flameatack * resistance);
        flameatack = flameatack <= 1 ? 1 : flameatack;
        return flameatack;
    }
    public int GetHitDamageWithResist(int flamedamage, int positiondamage, int glacierdamage, int lightdamage, int magicpen, string damageType)
    {
        int atack = 0;
        if (damageType == "flamedamage")
        {
            float flameresist = 100 + (boxFlameResist - (boxFlameResist * 0.01f * magicpen));
            float resistance = (100 / flameresist);
            flamedamage = (int)(flamedamage * resistance);
            flamedamage = flamedamage <= 1 ? 1 : flamedamage;
            atack = flamedamage;
        }
        else if (damageType == "poisondamage")
        {
            float flameresist = 100 + (boxPositionResist - (boxPositionResist * 0.01f * magicpen));
            float resistance = (100 / flameresist);
            positiondamage = (int)(positiondamage * resistance);
            positiondamage = positiondamage <= 1 ? 1 : positiondamage;
            atack = positiondamage;
        }
        else if (damageType == "icedamage")
        {
            float flameresist = 100 + (boxGlacierResist - (boxGlacierResist * 0.01f * magicpen));
            float resistance = (100 / flameresist);
            glacierdamage = (int)(glacierdamage * resistance);
            glacierdamage = glacierdamage <= 1 ? 1 : glacierdamage;
            atack = glacierdamage;
        }
        else if (damageType == "lightdamage")
        {
            float flameresist = 100 + (boxLightResist - (boxLightResist * 0.01f * magicpen));
            float resistance = (100 / flameresist);
            lightdamage = (int)(lightdamage * resistance);
            lightdamage = lightdamage <= 1 ? 1 : lightdamage;
            atack = lightdamage;
        }
        return atack;
    }
    public void OtherDamages(int damage, string damageType, int gunName, int id)
    {
        HitDamage(damage, gunName, id);
        Color32 x = Color.red;
        float place = -0.5f;
        damage = damage <= 1 ? 1 : damage;
        if (damageType == "icedamage")
        {
            x = Color.blue;
            place = 1;
            Instantiate(ice1, transform.position, transform.rotation);
        }
        else if (damageType == "lightdamage")
        {
            Instantiate(light1, transform.position, transform.rotation);
            x = Color.yellow;
            place = 0.5f;
        }
        else if (damageType == "positiondamage")
        {
            x = new Color32(139, 0, 139, 255);
            place = -0.5f;
            GameObject p1 = Instantiate(position1, transform.position, transform.rotation);
            p1.transform.SetParent(gameObject.transform);
        }
        else if (damageType == "flamedamage")
        {
            Instantiate(fire1, transform.position, transform.rotation);
        }

        GameObject flameDamageText = Instantiate(flameText, transform.position + new Vector3(place, place, 0), Quaternion.identity);
        TextMeshPro tmpFlame = flameDamageText.GetComponent<TextMeshPro>();
        tmpFlame.color = x;
        tmpFlame.SetText("" + (int)damage);
    }
    public void OtherDamages(string damageType, int flamedamage, int glacierdamage, int lightdamage, int positiondamage, int elementalbonus, int magic, int magicbonus, int magicpen, int gunname, int id)
    {
        int atack = 0;
        if (damageType.ToLower().Replace(" ", "") == "flamedamage")
        {
            dmgColor = Color.red;
            float plus = 1;
            if (iced)
            {
                plus -= 0.5f;
            }
            if (positionHit)
            {
                plus += 0.5f;
            }
            atack = (int)((flamedamage + (flamedamage * (elementalbonus) * 0.01f) + (glacierdamage / 2) + (lightdamage / 2) + (positiondamage / 2) + (magic + (magic * magicbonus * 0.01f))) * plus);
           
            float flameresist = 100 + (boxFlameResist - (boxFlameResist * 0.01f * magicpen));
            float resistance = (100 / flameresist);
            atack = (int)(atack * resistance);
            if (item3BonusAtack)
            {
                atack = (int)(atack + (atack * 0.12f));
            }
            GameObject flameDamageText = Instantiate(flameText, transform.position, Quaternion.identity);
            TextMeshPro tmpFlame = flameDamageText.GetComponent<TextMeshPro>();
            GameObject firehit = Instantiate(fire1, transform.position, transform.rotation);
            firehit.transform.SetParent(gameObject.transform);
            atack = atack <= 1 ? 1 : atack;
            tmpFlame.SetText("" + (int)atack);
        }
        else if (damageType.ToLower().Replace(" ", "") == "poison")
        {
            dmgColor = new Color32(255, 0, 174, 255);
            float plus = 1;
            if (flameHit)
            {
                plus += 0.5f;
            }
            atack = (int)(((flamedamage / 2) + (glacierdamage / 2) + (lightdamage / 2) + (positiondamage + (positiondamage * (elementalbonus) * 0.01f)) + ((magic / 2) + (magic * magicbonus * 0.005f))) * plus);
            float positionresist = 100 + (boxPositionResist - (boxPositionResist * 0.01f * magicpen));
            float resistance = (100 / positionresist);
            atack = (int)(atack * resistance);
            if (item3BonusAtack)
            {
                atack = (int)(atack + (int)((float)atack * 0.12f));
            }
            GameObject positionDamageText = Instantiate(positionText, transform.position, Quaternion.identity);
            TextMeshPro tmpPosition = positionDamageText.GetComponent<TextMeshPro>();
            GameObject p1 = Instantiate(position1, transform.position, transform.rotation);
            p1.transform.SetParent(gameObject.transform);
            atack = atack <= 1 ? 1 : atack;
            tmpPosition.SetText("" + (int)atack);
        }
        else if (damageType.ToLower().Replace(" ", "") == "icedamage")
        {
            dmgColor = Color.blue;
            float plus = 1;
            if (flameHit)
            {
                plus -= 0.5f;
            }
            atack = (int)(((flamedamage / 4) + (glacierdamage + (glacierdamage * (elementalbonus) * 0.01f)) + (lightdamage / 2) + (positiondamage / 2) + ((magic / 2) + (magic * magicbonus * 0.005f))) * plus);
            float glacierresist = 100 + (boxGlacierResist - (boxGlacierResist * 0.01f * magicpen));
            float resistance = (100 / glacierresist);
            atack = (int)(atack * resistance);
            if (item3BonusAtack)
            {
                atack = (int)(atack + (atack * 0.12f));
            }
            GameObject positionDamageText = Instantiate(positionText, transform.position, Quaternion.identity);
            TextMeshPro tmpPosition = positionDamageText.GetComponent<TextMeshPro>();
            tmpPosition.color = Color.blue;
            atack = atack <= 1 ? 1 : atack;
            tmpPosition.SetText("" + (int)atack);
            Instantiate(ice1, transform.position, transform.rotation);
        }
        else if (damageType.ToLower().Replace(" ", "") == "lightdamage")
        {
            dmgColor = Color.yellow;
            float plus = 1;
            if (flameHit)
            {
                plus += 0.5f;
            }
            if (iced)
            {
                plus += 1;
            }
            if (positionHit)
            {
                plus += 0.25f;
            }
            atack = (int)(((flamedamage / 2) + (glacierdamage / 2) + (lightdamage + (lightdamage * (elementalbonus) * 0.01f)) + (positiondamage / 2) + ((magic / 2) + (magic * magicbonus * 0.005f))) * plus);
            float lightresist = 100 + (boxLightResist - (boxLightResist * 0.01f * magicpen));
            float resistance = (100 / lightresist);
            atack = (int)(atack * resistance);
            if (item3BonusAtack)
            {
                atack = (int)(atack + (atack * 0.12f));
            }
            GameObject positionDamageText = Instantiate(positionText, transform.position, Quaternion.identity);
            TextMeshPro tmpPosition = positionDamageText.GetComponent<TextMeshPro>();
            tmpPosition.color = Color.yellow;
            atack = atack <= 1 ? 1 : atack;
            tmpPosition.SetText("" + (int)atack);
            Instantiate(light1, transform.position, transform.rotation);
        }
        HitDamage(atack, gunname, id);
    }
    public void OtherDamages(string damageType, int flamedamage, int glacierdamage, int lightdamage, int positiondamage, int elementalbonus, int magic, int magicbonus, int magicpen,int critical,int criticaldamage, int gunname, int id)
    {
        int atack = 0;
        if (damageType.ToLower().Replace(" ", "") == "flamedamage")
        {
            bool isExecute = false;
            bool crit = false;

            dmgColor = Color.red;
            float plus = 1;
            if (iced)
            {
                plus -= 0.5f;
            }
            if (positionHit)
            {
                plus += 0.5f;
            }
            atack = (int)((flamedamage + (flamedamage * (elementalbonus) * 0.01f) + (glacierdamage / 2) + (lightdamage / 2) + (positiondamage / 2) + (magic + (magic * magicbonus * 0.01f))) * plus);
            if (critical > 0)
            {
                bool hitCritical = critical >= GetRandom();
                if (hitCritical)
                {
                    if (item13)
                    {
                        isExecute = item13Passive();
                    }
                    atack = HitCritical(atack, critical, criticaldamage);
                    crit = true;
                }
            }
            float flameresist = 100 + (boxFlameResist - (boxFlameResist * 0.01f * magicpen));
            float resistance = (100 / flameresist);
            atack = (int)(atack * resistance);
            if (item3BonusAtack)
            {
                atack = (int)(atack + (atack * 0.12f));
            }
            GameObject flameDamageText = Instantiate(flameText, transform.position, Quaternion.identity);
            TextMeshPro tmpFlame = flameDamageText.GetComponent<TextMeshPro>();
            GameObject firehit = Instantiate(fire1, transform.position, transform.rotation);
            firehit.transform.SetParent(gameObject.transform);
            atack = atack <= 1 ? 1 : atack;
            if (crit)
            {
                tmpFlame.fontSize += 4;
            }
            if (isExecute)
            {
                atack = boxHp + 1;
                HitDamage(boxHp + 1, gunname, id);
            }
            else if (!isExecute)
            {
                HitDamage(atack, gunname, id);
            }
            tmpFlame.SetText("" + (int)atack);
        }
      
    }

    private void LifeSteal(int damage, int lifesteal)
    {
        GameObject deletebox = GameObject.Find("DeleteBoxes");
        deleteScript = deletebox.GetComponent<DeleteBoxes>();
        int hp = deleteScript.yourHealth;
        if (hp < yourMaxHp)
        {
            if (damage * lifesteal * 0.01f < 1)
            {
                if (hp + 1 <= yourMaxHp)
                {
                    deleteScript.yourHealth += 1;
                }
                else
                {
                    deleteScript.yourHealth = yourMaxHp;
                }
            }
            else
            {
                if (hp + (int)(damage * 0.01f * lifesteal) <= yourMaxHp)
                {
                    deleteScript.yourHealth += (int)(damage * 0.01f * lifesteal);
                }
                else
                {
                    deleteScript.yourHealth = yourMaxHp;
                }
            }
        }


    }
    private int HitCritical(int atackDamage, int critical, int criticaldamage)
    {
        return (int)(atackDamage * (2 + ((critical + criticaldamage) * 0.01f)));
    }
    private void HitDamage(int atack, int gunName, int id)
    {
        hpActive = true;
        hpTimer = 2;
        if (atack <= 1)
        {
            atack = 1;
        }
        boxHp -= atack;
        writedamage(atack, gunName, id);
        if (boxHp <= 0 && !isDead)
        {
            isDead = true;
            GameObject idGenerator = GameObject.Find("IdGenerator");
            IdGenerator generator = idGenerator.GetComponent<IdGenerator>();
            generator.gold += gunGold;
            if (copyLightEfect != null)
            {
                Destroy(copyLightEfect);
            }
            if (copyIceEfect != null)
            {
                Destroy(copyIceEfect);
            }
            Passive9And21(gunName, id);
            Destroy(gameObject);
        }


    }
    private void Passive9And21(int gunname, int id)
    {
        GameObject castle = GameObject.Find("DeleteBoxes");
        DeleteBoxes db = castle.GetComponent<DeleteBoxes>();
        if (db.yourHealth < db.maxHealth)
        {
            if (gunname == 1)
            {
                GameObject[] gun1s = GameObject.FindGameObjectsWithTag("weapon");
                foreach (var item in gun1s)
                {
                    MachineGunModel gmodel = item.GetComponent<MachineGunModel>();
                    if (gmodel != null)
                    {
                        if (gmodel.id == id)
                        {
                            foreach (var items in gmodel.items)
                            {
                                if (items == 9)
                                {
                                    db.yourHealth += 1;
                                    break;
                                }
                            }
                            foreach (var items in gmodel.items)
                            {
                                if (items == 21)
                                {
                                    GameObject idGenerator = GameObject.Find("IdGenerator");
                                    IdGenerator ig = idGenerator.GetComponent<IdGenerator>();
                                    ig.gold += 10;
                                    break;
                                }
                            }
                        }
                    }
                }

            }
            else if (gunname == 2)
            {
                GameObject[] gun2s = GameObject.FindGameObjectsWithTag("weapon");
                foreach (var item in gun2s)
                {
                    MachineGun2Model gmodel2 = item.GetComponent<MachineGun2Model>();
                    if (gmodel2 != null)
                    {
                        if (gmodel2.id == id)
                        {
                            foreach (var items in gmodel2.items)
                            {
                                if (items == 9)
                                {
                                    db.yourHealth += 1;
                                    break;
                                }
                            }
                            foreach (var items in gmodel2.items)
                            {
                                if (items == 21)
                                {
                                    GameObject idGenerator = GameObject.Find("IdGenerator");
                                    IdGenerator ig = idGenerator.GetComponent<IdGenerator>();
                                    ig.gold += 10;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else if (gunname == 3)
            {
                GameObject[] gun3s = GameObject.FindGameObjectsWithTag("weapon");
                foreach (var item in gun3s)
                {
                    MachineGun3Model gmodel3 = item.GetComponent<MachineGun3Model>();
                    if (gmodel3 != null)
                    {
                        foreach (var items in gmodel3.items)
                        {
                            if (items == 9)
                            {
                                db.yourHealth += 1;
                                break;
                            }
                        }
                        foreach (var items in gmodel3.items)
                        {
                            if (items == 21)
                            {
                                GameObject idGenerator = GameObject.Find("IdGenerator");
                                IdGenerator ig = idGenerator.GetComponent<IdGenerator>();
                                ig.gold += 10;
                                break;
                            }
                        }
                    }
                }
            }
            else if (gunname == 4)
            {
                GameObject[] gun4s = GameObject.FindGameObjectsWithTag("weapon");
                foreach (var item in gun4s)
                {
                    MachineGun4Model gmodel4 = item.GetComponent<MachineGun4Model>();
                    if (gmodel4 != null)
                    {
                        foreach (var items in gmodel4.items)
                        {
                            if (items == 9)
                            {
                                db.yourHealth += 1;
                                break;
                            }
                        }
                        foreach (var items in gmodel4.items)
                        {
                            if (items == 21)
                            {
                                GameObject idGenerator = GameObject.Find("IdGenerator");
                                IdGenerator ig = idGenerator.GetComponent<IdGenerator>();
                                ig.gold += 10;
                                break;
                            }
                        }
                    }
                }
            }
            else if (gunname == 5)
            {
                GameObject[] gun4s = GameObject.FindGameObjectsWithTag("weapon");
                foreach (var item in gun4s)
                {
                    MachineGun5Model gmodel5 = item.GetComponent<MachineGun5Model>();
                    if (gmodel5 != null)
                    {
                        foreach (var items in gmodel5.items)
                        {
                            if (items == 9)
                            {
                                db.yourHealth += 1;
                                break;
                            }
                        }
                        foreach (var items in gmodel5.items)
                        {
                            if (items == 21)
                            {
                                GameObject idGenerator = GameObject.Find("IdGenerator");
                                IdGenerator ig = idGenerator.GetComponent<IdGenerator>();
                                ig.gold += 10;
                                break;
                            }
                        }
                    }
                }
            }
        }

    }
    private void writedamage(int atack, int gunname, int id)
    {
        if (gunname == 1)
        {
            GameObject[] gun1s = GameObject.FindGameObjectsWithTag("weapon");
            foreach (var item in gun1s)
            {
                MachineGunModel gmodel = item.GetComponent<MachineGunModel>();
                if (gmodel != null)
                {
                    if (gmodel.id == id)
                    {
                        gmodel.totaldamage += atack;
                        break;
                    }
                }
            }

        }
        else if (gunname == 2)
        {
            GameObject[] gun2s = GameObject.FindGameObjectsWithTag("weapon");
            foreach (var item in gun2s)
            {
                MachineGun2Model gmodel2 = item.GetComponent<MachineGun2Model>();
                if (gmodel2 != null)
                {
                    if (gmodel2.id == id)
                    {
                        gmodel2.totaldamage += atack;
                        break;
                    }
                }
            }
        }
        else if (gunname == 3)
        {
            GameObject[] gun3s = GameObject.FindGameObjectsWithTag("weapon");
            foreach (var item in gun3s)
            {
                MachineGun3Model gmodel3 = item.GetComponent<MachineGun3Model>();
                if (gmodel3 != null)
                {
                    if (gmodel3.id == id)
                    {
                        gmodel3.totaldamage += atack;
                        break;
                    }
                }
            }
        }
        else if (gunname == 4)
        {
            GameObject[] gun4s = GameObject.FindGameObjectsWithTag("weapon");
            foreach (var item in gun4s)
            {
                MachineGun4Model gmodel4 = item.GetComponent<MachineGun4Model>();
                if (gmodel4 != null)
                {
                    if (gmodel4.id == id)
                    {
                        gmodel4.totaldamage += atack;
                    }
                }
            }
        }
        else if (gunname == 5)
        {
            GameObject[] gun5s = GameObject.FindGameObjectsWithTag("weapon");
            foreach (var item in gun5s)
            {
                MachineGun5Model gmodel5 = item.GetComponent<MachineGun5Model>();
                if (gmodel5 != null)
                {
                    if (gmodel5.id == id)
                    {
                        gmodel5.totaldamage += atack;
                    }
                }
            }
        }
        else if (gunname == 6)
        {
            GameObject[] gun6s = GameObject.FindGameObjectsWithTag("weapon");
            foreach (var item in gun6s)
            {
                MachineGun6Model gmodel6 = item.GetComponent<MachineGun6Model>();
                if (gmodel6 != null)
                {
                    if (gmodel6.id == id)
                    {
                        gmodel6.totaldamage += atack;
                    }
                }
            }
        }
    }
 
    private int GetRandom()
    {
        return Random.Range(1, 101);
    }
    private float calculateHp()
    {
        float hpDist2 = (float)boxHp / (float)boxMaxHp;
        return hpDist2;
    }
    private bool item13Passive()
    {
        bool isExecute;
        float percent = ((float)boxHp / (float)boxMaxHp);
        isExecute = percent < 0.12f ? true : false;
        return isExecute;
    }
}
