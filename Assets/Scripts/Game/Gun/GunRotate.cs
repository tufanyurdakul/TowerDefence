using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GunRotate : MonoBehaviour
{
    public Image asImage;
    public SpriteRenderer rangeSprite;
    private GameObject ammo;
    private MachineGun2Model gun2;
    private MachineGunModel gun;
    private MachineGun3Model gun3;
    private MachineGun4Model gun4;
    private MachineGun5Model gun5;
    private MachineGun6Model gun6;

    private int range;
    private int gunName;
    private float atackSpeed, atackSpeedTimer = 0 , increasesAspTimer;
    private int bulletVelocity, atackDamage, armorPenetration, magicPenetration, magic, criticalChance, lifeSteal, bonusAtack, bonusAp, elementalBonus, flameDamage, glacierDamage, lightDamage, positionDamage,itemId,criticaldamage;
    private string weaponDamageType, passive;
    private Vector3 FirstPosition;
    public List<int> items;
    private int item5count , item7count;
    private List<int> idOfAtackSpeed;
    private bool increasesAtackSpeed;
    private int count;
    public int item1Passive { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        items = new List<int>();
        idOfAtackSpeed = new List<int>();

    }
    void Start()
    {
        //Get Ammo
        ammo = Resources.Load("Ammo") as GameObject;
        //Get Ammo Values
        FirstPosition = gameObject.transform.position;
        gun6 = gameObject.GetComponent<MachineGun6Model>();
        gun5 = gameObject.GetComponent<MachineGun5Model>();
        gun4 = gameObject.GetComponent<MachineGun4Model>();
        gun3 = gameObject.GetComponent<MachineGun3Model>();
        gun2 = gameObject.GetComponent<MachineGun2Model>();
        gun = gameObject.GetComponent<MachineGunModel>();
        if (gun2 != null)
        {
            gunName = 2;
            range = gun2.range;
            atackSpeed = 1 / gun2.atackSpeed;
            bulletVelocity = gun2.bulletVelocity;
            atackSpeedTimer = atackSpeed;
            atackDamage = gun2.atackDamage;
            passive = gun2.passive;
            armorPenetration = gun2.armorPenetration;
            magicPenetration = gun2.magicPenetration;
            magic = gun2.magic;
            weaponDamageType = gun2.weaponDamageType;
            criticalChance = gun2.criticalChance;
            lifeSteal = gun2.lifeSteal;
            bonusAtack = gun2.Bonus[0];
            bonusAp = gun2.Bonus[1];
            elementalBonus = gun2.Bonus[2];
            flameDamage = gun2.flameDamage;
            glacierDamage = gun2.glacierDamage;
            lightDamage = gun2.lightDamage;
            positionDamage = gun2.positionDamage;
            itemId = gun2.id;
        }
        else if (gun != null)
        {
            gunName = 1;
            range = gun.range;
            atackSpeed = 1 / gun.atackSpeed;
            bulletVelocity = gun.bulletVelocity;
            atackSpeedTimer = atackSpeed;
            atackDamage = gun.atackDamage;
            passive = gun.passive;
            armorPenetration = gun.armorPenetration;
            magicPenetration = gun.magicPenetration;
            magic = gun.magic;
            weaponDamageType = gun.weaponDamageType;
            criticalChance = gun.criticalChance;
            lifeSteal = gun.lifeSteal;
            bonusAtack = gun.Bonus[0];
            bonusAp = gun.Bonus[1];
            elementalBonus = gun.Bonus[2];
            flameDamage = gun.flameDamage;
            glacierDamage = gun.glacierDamage;
            lightDamage = gun.lightDamage;
            positionDamage = gun.positionDamage;
            itemId = gun.id;
        }
        else if (gun3 != null)
        {
            gunName = 3;
            range = gun3.range;
            atackSpeed = 1 / gun3.atackSpeed;
            bulletVelocity = gun3.bulletVelocity;
            atackSpeedTimer = atackSpeed;
            atackDamage = gun3.atackDamage;
            passive = gun3.passive;
            armorPenetration = gun3.armorPenetration;
            magicPenetration = gun3.magicPenetration;
            magic = gun3.magic;
            weaponDamageType = gun3.weaponDamageType;
            criticalChance = gun3.criticalChance;
            lifeSteal = gun3.lifeSteal;
            bonusAtack = gun3.Bonus[0];
            bonusAp = gun3.Bonus[1];
            elementalBonus = gun3.Bonus[2];
            flameDamage = gun3.flameDamage;
            glacierDamage = gun3.glacierDamage;
            lightDamage = gun3.lightDamage;
            positionDamage = gun3.positionDamage;
            itemId = gun3.id;
        }
        else if (gun4 != null)
        {
            gunName = 4;
            range = gun4.range;
            atackSpeed = 1 / gun4.atackSpeed;
            bulletVelocity = gun4.bulletVelocity;
            atackSpeedTimer = atackSpeed;
            atackDamage = gun4.atackDamage;
            passive = gun4.passive;
            armorPenetration = gun4.armorPenetration;
            magicPenetration = gun4.magicPenetration;
            magic = gun4.magic;
            weaponDamageType = gun4.weaponDamageType;
            criticalChance = gun4.criticalChance;
            lifeSteal = gun4.lifeSteal;
            bonusAtack = gun4.Bonus[0];
            bonusAp = gun4.Bonus[1];
            elementalBonus = gun4.Bonus[2];
            flameDamage = gun4.flameDamage;
            glacierDamage = gun4.glacierDamage;
            lightDamage = gun4.lightDamage;
            positionDamage = gun4.positionDamage;
            itemId = gun4.id;
        }
        if (gun5 != null)
        {
            gunName = 5;
            range = gun5.range;
            atackSpeed = 1 / gun5.atackSpeed;
            bulletVelocity = gun5.bulletVelocity;
            atackSpeedTimer = atackSpeed;
            atackDamage = gun5.atackDamage;
            passive = gun5.passive;
            armorPenetration = gun5.armorPenetration;
            magicPenetration = gun5.magicPenetration;
            magic = gun5.magic;
            weaponDamageType = gun5.weaponDamageType;
            criticalChance = gun5.criticalChance;
            lifeSteal = gun5.lifeSteal;
            bonusAtack = gun5.Bonus[0];
            bonusAp = gun5.Bonus[1];
            elementalBonus = gun5.Bonus[2];
            flameDamage = gun5.flameDamage;
            glacierDamage = gun5.glacierDamage;
            lightDamage = gun5.lightDamage;
            positionDamage = gun5.positionDamage;
            itemId = gun5.id;
        }
        if (gun6 != null)
        {
            gunName = 6;
            range = gun6.range;
            atackSpeed = 1 / gun6.atackSpeed;
            bulletVelocity = gun6.bulletVelocity;
            atackSpeedTimer = atackSpeed;
            atackDamage = gun6.atackDamage;
            passive = gun6.passive;
            armorPenetration = gun6.armorPenetration;
            magicPenetration = gun6.magicPenetration;
            magic = gun6.magic;
            weaponDamageType = gun6.weaponDamageType;
            criticalChance = gun6.criticalChance;
            lifeSteal = gun6.lifeSteal;
            bonusAtack = gun6.Bonus[0];
            bonusAp = gun6.Bonus[1];
            elementalBonus = gun6.Bonus[2];
            flameDamage = gun6.flameDamage;
            glacierDamage = gun6.glacierDamage;
            lightDamage = gun6.lightDamage;
            positionDamage = gun6.positionDamage;
            itemId = gun6.id;
        }
        rangeSprite.transform.localScale *= Mathf.Sqrt(range * 2);

    }

    // Update is called once per frame
    void Update()
    {
        asImage.fillAmount = atackSpeedTimer / atackSpeed;
        if (increasesAtackSpeed)
        {
            increasesAspTimer -= Time.deltaTime;
            if (increasesAspTimer <= 0)
            {
                GameObject[] guns = GameObject.FindGameObjectsWithTag("weapon");
                AddIt(-0.3f, guns , 0);
                idOfAtackSpeed = new List<int>();
                increasesAtackSpeed = false;
                increasesAspTimer = 4;
            }
        }
        if (gameObject.transform.position != FirstPosition)
        {
            Vector3 x = gameObject.transform.position - FirstPosition;
            gameObject.transform.position -= x / 5;
        }
        if (atackSpeedTimer > 0)
        {
            atackSpeedTimer -= Time.deltaTime;
        }
        if (atackSpeedTimer <= 0)
        {
            if (gunName == 1 || gunName == 3 || gunName == 5)
            {
                GameObject[] boxes = GameObject.FindGameObjectsWithTag("boxes");
                List<GameObject> rangedBoxes = new List<GameObject>();
                foreach (var box in boxes)
                {
                    Vector3 x = gameObject.transform.position - box.transform.position;
                    float y = x.sqrMagnitude;
                    if (y <= range)
                    {
                        rangedBoxes.Add(box);
                    }
                }
                if (rangedBoxes.Count > 0)
                {
                    GameObject box = rangedBoxes[0];
                    if (box != null)
                    {
                        float offset = 90f;
                        Vector2 direction = (Vector2)box.transform.position - (Vector2)transform.position;
                        direction.Normalize();
                        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.Euler(Vector3.forward * (-90 + (angle + offset)));

                    }
                    ThrowAmmo();
                }
            }
            else if (gunName == 2 || gunName == 4 || gunName == 6)
            {
                GameObject[] boxes = GameObject.FindGameObjectsWithTag("boxes");
                List<GameObject> rangedBoxes = new List<GameObject>();
                foreach (var box in boxes)
                {
                    Vector3 x = gameObject.transform.position - box.transform.position;
                    float y = x.sqrMagnitude;
                    if (y <= range)
                    {
                        rangedBoxes.Add(box);
                    }
                }
                if (rangedBoxes.Count > 1)
                {
                    GameObject box = rangedBoxes[1];
                    if (box != null)
                    {
                        float offset = 90f;
                        Vector2 direction = (Vector2)box.transform.position - (Vector2)transform.position;
                        direction.Normalize();
                        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.Euler(Vector3.forward * (-90 + (angle + offset)));
                        ThrowAmmo();
                    }
                }
                else if (rangedBoxes.Count > 0)
                {
                    GameObject box = rangedBoxes[0];
                    if (box != null)
                    {

                        float offset = 90f;
                        Vector2 direction = (Vector2)box.transform.position - (Vector2)transform.position;
                        direction.Normalize();
                        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.Euler(Vector3.forward * (-90 + (angle + offset)));
                        ThrowAmmo();
                    }
                }
            }
        }
    }
    private void ThrowAmmo()
    {
        count++;
        if (gunName == 2)
        {
            items = gun2.items;
            gun2 = gameObject.GetComponent<MachineGun2Model>();
            range = gun2.range;
            atackSpeed = 1 / gun2.atackSpeed;
            bulletVelocity = gun2.bulletVelocity;
            atackSpeedTimer = atackSpeed;
            atackDamage = gun2.atackDamage;
            passive = gun2.passive;
            armorPenetration = gun2.armorPenetration;
            magicPenetration = gun2.magicPenetration;
            magic = gun2.magic;
            weaponDamageType = gun2.weaponDamageType;
            criticalChance = gun2.criticalChance;
            lifeSteal = gun2.lifeSteal;
            bonusAtack = gun2.Bonus[0];
            bonusAp = gun2.Bonus[1];
            elementalBonus = gun2.Bonus[2];
            flameDamage = gun2.flameDamage;
            glacierDamage = gun2.glacierDamage;
            lightDamage = gun2.lightDamage;
            positionDamage = gun2.positionDamage;
            criticaldamage = gun2.criticaldamage;
            itemId = gun2.id;
            
        }
        else if (gunName == 1)
        {
            items = gun.items;
            gun = gameObject.GetComponent<MachineGunModel>();
            range = gun.range;
            atackSpeed = 1 / gun.atackSpeed;
            bulletVelocity = gun.bulletVelocity;
            atackSpeedTimer = atackSpeed;
            atackDamage = gun.atackDamage;
            passive = gun.passive;
            armorPenetration = gun.armorPenetration;
            magicPenetration = gun.magicPenetration;
            magic = gun.magic;
            weaponDamageType = gun.weaponDamageType;
            criticalChance = gun.criticalChance;
            lifeSteal = gun.lifeSteal;
            bonusAtack = gun.Bonus[0];
            bonusAp = gun.Bonus[1];
            elementalBonus = gun.Bonus[2];
            flameDamage = gun.flameDamage;
            glacierDamage = gun.glacierDamage;
            lightDamage = gun.lightDamage;
            positionDamage = gun.positionDamage;
            criticaldamage = gun.criticaldamage;
            itemId = gun.id;
        }
        else if (gunName == 3)
        {
            items = gun3.items;
            gun3 = gameObject.GetComponent<MachineGun3Model>();
            range = gun3.range;
            atackSpeed = 1 / gun3.atackSpeed;
            bulletVelocity = gun3.bulletVelocity;
            atackSpeedTimer = atackSpeed;
            atackDamage = gun3.atackDamage;
            passive = gun3.passive;
            armorPenetration = gun3.armorPenetration;
            magicPenetration = gun3.magicPenetration;
            magic = gun3.magic;
            weaponDamageType = gun3.weaponDamageType;
            criticalChance = gun3.criticalChance;
            lifeSteal = gun3.lifeSteal;
            bonusAtack = gun3.Bonus[0];
            bonusAp = gun3.Bonus[1];
            elementalBonus = gun3.Bonus[2];
            flameDamage = gun3.flameDamage;
            glacierDamage = gun3.glacierDamage;
            lightDamage = gun3.lightDamage;
            positionDamage = gun3.positionDamage;
            criticaldamage = gun3.criticaldamage;
            itemId = gun3.id;

        }
        else if (gunName == 4)
        {
            items = gun4.items;
            gun4 = gameObject.GetComponent<MachineGun4Model>();
            range = gun4.range;
            atackSpeed = 1 / gun4.atackSpeed;
            bulletVelocity = gun4.bulletVelocity;
            atackSpeedTimer = atackSpeed;
            atackDamage = gun4.atackDamage;
            passive = gun4.passive;
            armorPenetration = gun4.armorPenetration;
            magicPenetration = gun4.magicPenetration;
            magic = gun4.magic;
            weaponDamageType = gun4.weaponDamageType;
            criticalChance = gun4.criticalChance;
            lifeSteal = gun4.lifeSteal;
            bonusAtack = gun4.Bonus[0];
            bonusAp = gun4.Bonus[1];
            elementalBonus = gun4.Bonus[2];
            flameDamage = gun4.flameDamage;
            glacierDamage = gun4.glacierDamage;
            lightDamage = gun4.lightDamage;
            positionDamage = gun4.positionDamage;
            criticaldamage = gun4.criticaldamage;
            itemId = gun4.id;
           
        }
        else if (gunName == 5)
        {
            items = gun5.items;
            gun5 = gameObject.GetComponent<MachineGun5Model>();
            range = gun5.range;
            atackSpeed = 1 / gun5.atackSpeed;
            bulletVelocity = gun5.bulletVelocity;
            atackSpeedTimer = atackSpeed;
            atackDamage = gun5.atackDamage;
            passive = gun5.passive;
            armorPenetration = gun5.armorPenetration;
            magicPenetration = gun5.magicPenetration;
            magic = gun5.magic;
            weaponDamageType = gun5.weaponDamageType;
            criticalChance = gun5.criticalChance;
            lifeSteal = gun5.lifeSteal;
            bonusAtack = gun5.Bonus[0];
            bonusAp = gun5.Bonus[1];
            elementalBonus = gun5.Bonus[2];
            flameDamage = gun5.flameDamage;
            glacierDamage = gun5.glacierDamage;
            lightDamage = gun5.lightDamage;
            positionDamage = gun5.positionDamage;
            criticaldamage = gun5.criticaldamage;
            itemId = gun5.id;
        }
        else if (gunName == 6)
        {
            items = gun6.items;
            gun6 = gameObject.GetComponent<MachineGun6Model>();
            range = gun6.range;
            atackSpeed = 1 / gun6.atackSpeed;
            bulletVelocity = gun6.bulletVelocity;
            atackSpeedTimer = atackSpeed;
            atackDamage = gun6.atackDamage;
            passive = gun6.passive;
            armorPenetration = gun6.armorPenetration;
            magicPenetration = gun6.magicPenetration;
            magic = gun6.magic;
            weaponDamageType = gun6.weaponDamageType;
            criticalChance = gun6.criticalChance;
            lifeSteal = gun6.lifeSteal;
            bonusAtack = gun6.Bonus[0];
            bonusAp = gun6.Bonus[1];
            elementalBonus = gun6.Bonus[2];
            flameDamage = gun6.flameDamage;
            glacierDamage = gun6.glacierDamage;
            lightDamage = gun6.lightDamage;
            positionDamage = gun6.positionDamage;
            criticaldamage = gun6.criticaldamage;
            itemId = gun6.id;
        }
        foreach (var item in items)
        {
            if (item == 1)
            {
                item1Passive++;
                if (item1Passive % 3 == 0)
                {
                    atackDamage += (int)(atackDamage * 0.5f);
                    bonusAtack += (int)(bonusAtack * 0.5f);
                }
            }
            if (item == 5)
            {
                item5count++;
                if (item5count % 4 == 0)
                {
                    ThrowAmmo2();
                }
            }
            if (item == 7)
            {
                item7count++;
                if (item7count % 9 == 0)
                {
                    IncreaseAtackSpeed();
                }
            }
        }
        
        gameObject.transform.position += new Vector3(-0.3f, 0, 0);
        GameObject copyAmmo = Instantiate(ammo, transform.position, transform.rotation);
        Rigidbody2D rbCopyAmmo = copyAmmo.GetComponent<Rigidbody2D>();
        rbCopyAmmo.AddForce(gameObject.transform.right * bulletVelocity, ForceMode2D.Impulse);
        AmmoModel ammoModel = copyAmmo.GetComponent<AmmoModel>();
        ammoModel.atackDamage = atackDamage;
        ammoModel.passive = passive;
        ammoModel.armorPenetration = armorPenetration;
        ammoModel.magicPenetration = magicPenetration;
        ammoModel.magic = magic;
        ammoModel.weaponDamageType = weaponDamageType;
        ammoModel.criticalChance = criticalChance;
        ammoModel.lifeSteal = lifeSteal;
        ammoModel.bonusAtack = bonusAtack;
        ammoModel.bonusAp = bonusAp;
        ammoModel.elementalBonus = elementalBonus;
        ammoModel.flameDamage = flameDamage;
        ammoModel.glacierDamage = glacierDamage;
        ammoModel.lightDamage = lightDamage;
        ammoModel.positionDamage = positionDamage;
        ammoModel.items = items;
        ammoModel.item1Passive = item1Passive;
        Destroy(copyAmmo, 1.5f);
        atackSpeedTimer = atackSpeed;
        ammoModel.gunname = gunName;
        ammoModel.criticaldamage = criticaldamage;
        ammoModel.gunid = itemId;
        ammoModel.gunPosition = gameObject.transform.position;
        ammoModel.range = range;
        ammoModel.count = count;
        int countAmmo = 0;
        if (gunName == 5)
        {
            Transform[] ammoDirectory = gameObject.GetComponentsInChildren<Transform>();

            foreach (var item in ammoDirectory)
            {
                if (item.name == "AmmoTransform1")
                {
                    copyAmmo = Instantiate(ammo, item.transform.position, item.transform.rotation);
                    rbCopyAmmo = copyAmmo.GetComponent<Rigidbody2D>();
                    rbCopyAmmo.AddForce(item.transform.right * bulletVelocity, ForceMode2D.Impulse);
                    ammoModel = copyAmmo.GetComponent<AmmoModel>();
                    ammoModel.atackDamage = (int)(atackDamage / 3) + positionDamage + (magic / 2);
                    ammoModel.passive = passive;
                    ammoModel.armorPenetration = armorPenetration;
                    ammoModel.magicPenetration = magicPenetration;
                    ammoModel.magic = (magic);
                    ammoModel.weaponDamageType = weaponDamageType;
                    ammoModel.criticalChance = criticalChance;
                    ammoModel.lifeSteal = lifeSteal;
                    ammoModel.bonusAtack = bonusAtack;
                    ammoModel.bonusAp = bonusAp;
                    ammoModel.elementalBonus = elementalBonus;
                    ammoModel.flameDamage = flameDamage;
                    ammoModel.glacierDamage = glacierDamage;
                    ammoModel.lightDamage = lightDamage;
                    ammoModel.positionDamage = positionDamage;
                    ammoModel.items = items;
                    ammoModel.item1Passive = item1Passive;
                    Destroy(copyAmmo, 1.5f);
                    atackSpeedTimer = atackSpeed;
                    ammoModel.gunname = gunName;
                    ammoModel.criticaldamage = criticaldamage;
                    ammoModel.gunid = itemId;
                    ammoModel.gunPosition = gameObject.transform.position;
                    ammoModel.range = range;
                    ammoModel.count = count;
                    countAmmo++;
                    if (countAmmo == 4)
                    {
                        break;
                    }
                }
                else if (item.name == "AmmoTransform2")
                {
                    copyAmmo = Instantiate(ammo, item.transform.position, item.transform.rotation);
                    rbCopyAmmo = copyAmmo.GetComponent<Rigidbody2D>();
                    rbCopyAmmo.AddForce(item.transform.right * bulletVelocity, ForceMode2D.Impulse);
                    ammoModel = copyAmmo.GetComponent<AmmoModel>();
                    ammoModel.atackDamage = (int)(atackDamage / 3) + positionDamage + (magic / 2);
                    ammoModel.passive = passive;
                    ammoModel.armorPenetration = armorPenetration;
                    ammoModel.magicPenetration = magicPenetration;
                    ammoModel.magic = (magic);
                    ammoModel.weaponDamageType = weaponDamageType;
                    ammoModel.criticalChance = criticalChance;
                    ammoModel.lifeSteal = lifeSteal;
                    ammoModel.bonusAtack = bonusAtack;
                    ammoModel.bonusAp = bonusAp;
                    ammoModel.elementalBonus = elementalBonus;
                    ammoModel.flameDamage = flameDamage;
                    ammoModel.glacierDamage = glacierDamage;
                    ammoModel.lightDamage = lightDamage;
                    ammoModel.positionDamage = positionDamage;
                    ammoModel.items = items;
                    ammoModel.item1Passive = item1Passive;
                    Destroy(copyAmmo, 1.5f);
                    atackSpeedTimer = atackSpeed;
                    ammoModel.gunname = gunName;
                    ammoModel.criticaldamage = criticaldamage;
                    ammoModel.gunid = itemId;
                    ammoModel.gunPosition = gameObject.transform.position;
                    ammoModel.range = range;
                    ammoModel.count = count;
                    countAmmo++;
                    if (countAmmo == 4)
                    {
                        break;
                    }
                }
                else if (item.name == "AmmoTransform3")
                {
                    copyAmmo = Instantiate(ammo, item.transform.position, item.transform.rotation);
                    rbCopyAmmo = copyAmmo.GetComponent<Rigidbody2D>();
                    rbCopyAmmo.AddForce(item.transform.right * bulletVelocity, ForceMode2D.Impulse);
                    ammoModel = copyAmmo.GetComponent<AmmoModel>();
                    ammoModel.atackDamage = (int)(atackDamage / 3) + positionDamage + (magic / 2);
                    ammoModel.passive = passive;
                    ammoModel.armorPenetration = armorPenetration;
                    ammoModel.magicPenetration = magicPenetration;
                    ammoModel.magic = (magic);
                    ammoModel.weaponDamageType = weaponDamageType;
                    ammoModel.criticalChance = criticalChance;
                    ammoModel.lifeSteal = lifeSteal;
                    ammoModel.bonusAtack = bonusAtack;
                    ammoModel.bonusAp = bonusAp;
                    ammoModel.elementalBonus = elementalBonus;
                    ammoModel.flameDamage = flameDamage;
                    ammoModel.glacierDamage = glacierDamage;
                    ammoModel.lightDamage = lightDamage;
                    ammoModel.positionDamage = positionDamage;
                    ammoModel.items = items;
                    ammoModel.item1Passive = item1Passive;
                    Destroy(copyAmmo, 1.5f);
                    atackSpeedTimer = atackSpeed;
                    ammoModel.gunname = gunName;
                    ammoModel.criticaldamage = criticaldamage;
                    ammoModel.gunid = itemId;
                    ammoModel.gunPosition = gameObject.transform.position;
                    ammoModel.range = range;
                    ammoModel.count = count;
                    countAmmo++;
                    if (countAmmo == 4)
                    {
                        break;
                    }
                }
                else if (item.name == "AmmoTransform4")
                {
                    copyAmmo = Instantiate(ammo, item.transform.position, item.transform.rotation);
                    rbCopyAmmo = copyAmmo.GetComponent<Rigidbody2D>();
                    rbCopyAmmo.AddForce(item.transform.right * bulletVelocity, ForceMode2D.Impulse);
                    ammoModel = copyAmmo.GetComponent<AmmoModel>();
                    ammoModel.atackDamage = (int)(atackDamage / 3) + positionDamage + (magic / 2);
                    ammoModel.passive = passive;
                    ammoModel.armorPenetration = armorPenetration;
                    ammoModel.magicPenetration = magicPenetration;
                    ammoModel.magic = (magic);
                    ammoModel.weaponDamageType = weaponDamageType;
                    ammoModel.criticalChance = criticalChance;
                    ammoModel.lifeSteal = lifeSteal;
                    ammoModel.bonusAtack = bonusAtack;
                    ammoModel.bonusAp = bonusAp;
                    ammoModel.elementalBonus = elementalBonus;
                    ammoModel.flameDamage = flameDamage;
                    ammoModel.glacierDamage = glacierDamage;
                    ammoModel.lightDamage = lightDamage;
                    ammoModel.positionDamage = positionDamage;
                    ammoModel.items = items;
                    ammoModel.item1Passive = item1Passive;
                    Destroy(copyAmmo, 1.5f);
                    atackSpeedTimer = atackSpeed;
                    ammoModel.gunname = gunName;
                    ammoModel.criticaldamage = criticaldamage;
                    ammoModel.gunid = itemId;
                    ammoModel.gunPosition = gameObject.transform.position;
                    ammoModel.range = range;
                    ammoModel.count = count;
                    countAmmo++;
                    if (countAmmo == 4)
                    {
                        break;
                    }
                }

            }
        }
    }
    private void IncreaseAtackSpeed()
    {
        GameObject[] guns = GameObject.FindGameObjectsWithTag("weapon");
        if (idOfAtackSpeed.Count > 0)
        {
            AddIt(-0.3f, guns , 0);
            idOfAtackSpeed = new List<int>();
        }
            AddIt(0.3f, guns , 1);
        increasesAspTimer = 4;
        increasesAtackSpeed = true;
    }
    private void AddIt(float asp,GameObject[] guns , int value)
    {
        foreach (var item in guns)
        {
            MachineGun2Model mg2 = item.GetComponent<MachineGun2Model>();
            MachineGunModel mg = item.GetComponent<MachineGunModel>();
            MachineGun3Model mg3 = item.GetComponent<MachineGun3Model>();
            MachineGun4Model mg4 = item.GetComponent<MachineGun4Model>();
            MachineGun5Model mg5 = item.GetComponent<MachineGun5Model>();
            MachineGun6Model mg6 = item.GetComponent<MachineGun6Model>();

            if (mg2 != null)
            {
                if (value == 1)
                {
                    idOfAtackSpeed.Add(mg2.id);
                }
                foreach (var ids in idOfAtackSpeed)
                {
                    if (mg2.id == ids)
                    {
                        mg2.atackSpeed += asp;
                    }
                }

            }
            if (mg != null)
            {
                if (value == 1)
                {
                    idOfAtackSpeed.Add(mg.id);
                }
                foreach (var ids in idOfAtackSpeed)
                {
                    if (mg.id == ids)
                    {
                        mg.atackSpeed += asp;
                    }
                }

            }
            if (mg3 != null)
            {
                if (value == 1)
                {
                    idOfAtackSpeed.Add(mg3.id);
                }
                foreach (var ids in idOfAtackSpeed)
                {
                    if (mg3.id == ids)
                    {
                        mg3.atackSpeed += asp;
                    }
                }

            }
            if (mg4 != null)
            {
                if (value == 1)
                {
                    idOfAtackSpeed.Add(mg4.id);
                }
                foreach (var ids in idOfAtackSpeed)
                {
                    if (mg4.id == ids)
                    {
                        mg4.atackSpeed += asp;
                    }
                }
            }
            if (mg5 != null)
            {
                if (value == 1)
                {
                    idOfAtackSpeed.Add(mg5.id);
                }
                foreach (var ids in idOfAtackSpeed)
                {
                    if (mg5.id == ids)
                    {
                        mg5.atackDamage += (int)(asp * 50);
                    }
                }

            }
            if (mg6 != null)
            {
                if (value == 1)
                {
                    idOfAtackSpeed.Add(mg6.id);
                }
                foreach (var ids in idOfAtackSpeed)
                {
                    if (mg6.id == ids)
                    {
                        mg6.atackSpeed += asp;
                    }
                }

            }
        }
    }
    private void ThrowAmmo2()
    {
        if (item1Passive % 3 == 0 && item1Passive > 0)
        {
            atackDamage = (int)(atackDamage * 0.5f);
            bonusAtack = (int)(bonusAtack * 0.5f);
        }
        else
        {
            atackDamage = 0;
            bonusAtack = 0;
        }
        GameObject copyAmmo = Instantiate(ammo, transform.position, transform.rotation);
        Rigidbody2D rbCopyAmmo = copyAmmo.GetComponent<Rigidbody2D>();
        rbCopyAmmo.AddForce(gameObject.transform.right * (bulletVelocity * 2), ForceMode2D.Impulse);
        AmmoModel ammoModel = copyAmmo.GetComponent<AmmoModel>();
        ammoModel.atackDamage = atackDamage;
        ammoModel.passive = passive;
        ammoModel.armorPenetration = armorPenetration;
        ammoModel.magicPenetration = magicPenetration;
        ammoModel.magic = magic;
        ammoModel.weaponDamageType = weaponDamageType;
        ammoModel.criticalChance = criticalChance;
        ammoModel.lifeSteal = lifeSteal;
        ammoModel.bonusAtack = bonusAtack;
        ammoModel.bonusAp = bonusAp;
        ammoModel.elementalBonus = elementalBonus;
        ammoModel.flameDamage = flameDamage;
        ammoModel.glacierDamage = glacierDamage;
        ammoModel.lightDamage = lightDamage;
        ammoModel.positionDamage = positionDamage;
        ammoModel.items = items;
        ammoModel.item1Passive = item1Passive;
        Destroy(copyAmmo, 1.5f);
        atackSpeedTimer = atackSpeed;
        ammoModel.gunname = gunName;
        ammoModel.gunid = itemId;
        item5count++;
        if (item1Passive > 0)
        {
            item1Passive++;
        }
        if (item7count > 0)
        {
            item7count++;
        }
    }
}
