using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimation : MonoBehaviour
{
    public int Atack { get; set; }
    public int gunid { get; set; }
    public int boxid { get; set; }

    public string DamageType { get; set; }
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        DamageType = "flamedamage";
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = new Color32(255, 255, 255, 200);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localScale.x > 3)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }
    }
}
