using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoModel : MonoBehaviour
{
    private int bulletVelocity;
    public Vector3 gunPosition { private get; set; }
    public string passive { get; set; }
    public int atackDamage { get; set; }
    public int armorPenetration { get; set; }
    public int magicPenetration { get; set; }
    public int magic { get; set; }
    public string weaponDamageType { get; set; }
    public int criticalChance { get; set; }
    public int lifeSteal { get; set; }
    public int bonusAtack { get; set; }
    public int bonusAp { get; set; }
    public int elementalBonus { get; set; }
    public int flameDamage { get; set; }
    public int glacierDamage { get; set; }
    public int lightDamage { get; set; }
    public int positionDamage { get; set; }
    public int item1 { get; set; }
    public int item2 { get; set; }
    public int item3 { get; set; }
    public int item4 { get; set; }
    public int item5 { get; set; }
    public int item6 { get; set; }
    public int item1Passive { get;  set; }
    public List<int> items;
    public int gunname { get; set; }
    public int criticaldamage { get; set; }
    public int countBounce { get; set; }
    public bool isBounce { get; set; }
    private Rigidbody2D rgb;
    public List<int> ids { get; set; }
    public int gunid { get; set; }
    public int range { get; set; }
    public int count { get; set; }
    public int bounceid { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        items = new List<int>();
        ids = new List<int>();
        rgb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBounce)
        {
            if (countBounce < 4)
            {
                GameObject box = null;
                GameObject[] anotherBox = GameObject.FindGameObjectsWithTag("boxes");
                foreach (var item in anotherBox)
                {
                    bool controlSameBox = true;
                    BoxesOnHit boh = item.GetComponent<BoxesOnHit>();
                    foreach (var items in ids)
                    {
                        if (boh.boxID == items)
                        {
                            controlSameBox = false;
                        }
                        else
                        {
                            Vector3 x = gameObject.transform.position - item.transform.position;
                            float y = x.sqrMagnitude;
                            if (y > 15)
                            {
                                controlSameBox = false;
                            }
                        }
                    }
                    if (controlSameBox)
                    {
                        box = item;
                    }
                    if (controlSameBox)
                    {
                        float offset = 90f;
                        Vector2 direction = (Vector2)gameObject.transform.position - (Vector2)box.transform.position;
                        direction.Normalize();
                        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        gameObject.transform.rotation = Quaternion.Euler(Vector3.forward * (90 + (angle + offset)));
                        float arctan = Mathf.Atan2((gameObject.transform.position.y - box.transform.position.y), (gameObject.transform.position.x - box.transform.position.x));
                        float sinx = Mathf.Sin(arctan);
                        float cosx = Mathf.Cos(arctan);
                        Rigidbody2D rgb = gameObject.GetComponent<Rigidbody2D>();
                        rgb.velocity = new Vector2(-cosx, -sinx) * 20;
                        if (box == null)
                        {
                            Destroy(gameObject);
                        }
                        bounceid = boh.boxID;
                        break;
                    }

                }
                if (rgb.velocity == new Vector2(0,0))
                {
                    Destroy(gameObject);
                }
                if (box == null)
                {
                    Destroy(gameObject);
                }
                
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
        if (gunname == 5)
        {
            Vector3 x = gameObject.transform.position - gunPosition;
            float y = x.sqrMagnitude;
            if (y > range)
            {
                Destroy(gameObject);
            }
        }
    }
}
