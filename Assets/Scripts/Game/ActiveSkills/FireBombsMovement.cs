using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBombsMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] boxes;
    private Rigidbody2D rga;
    public int flamedamage { get; set; }
    public int id { get; set; }
    public int boxID { get; set; }
    public int magicPen { get; set; }
    
    void Start()
    {
        string[] infoSkill = PlayerPrefs.GetString("fireSkill").Split(',');
        flamedamage = int.Parse(infoSkill[0]);
        magicPen = int.Parse(infoSkill[1]);
        boxes = GameObject.FindGameObjectsWithTag("boxes");
        rga = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform boxTransform = null;
        if (boxes[id] != null)
        {
            boxTransform = boxes[id].transform;
            BoxesOnHit box = boxes[id].GetComponent<BoxesOnHit>();
            boxID = box.boxID;
        }
        
        if (boxTransform != null)
        {
            float offset = 90f;
            Vector2 direction = (Vector2)boxTransform.position - (Vector2)transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(Vector3.forward * (-80 + (angle + offset)));
            float arctan = Mathf.Atan2((boxTransform.position.y - gameObject.transform.position.y), (boxTransform.position.x - gameObject.transform.position.x));
            float sinx = Mathf.Sin(arctan);
            float cosx = Mathf.Cos(arctan);
            rga.velocity = new Vector2(cosx, sinx) * 25;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
