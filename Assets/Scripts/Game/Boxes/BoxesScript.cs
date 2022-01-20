using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesScript : MonoBehaviour
{
    private Rigidbody2D rgBox;
   
    // Start is called before the first frame update
    void Start()
    {
        FirstBoxModel fbx = gameObject.GetComponent<FirstBoxModel>();
        SecondBoxModel sbx = gameObject.GetComponent<SecondBoxModel>();
        ThirdBoxModel tbx = gameObject.GetComponent<ThirdBoxModel>();
        FourthBoxModel fthbx = gameObject.GetComponent<FourthBoxModel>();
        FifthBoxModel fithbx = gameObject.GetComponent<FifthBoxModel>();
        SixthBoxModel sithbx = gameObject.GetComponent<SixthBoxModel>();

        FirstBossBoxModel fbbx = gameObject.GetComponent<FirstBossBoxModel>();
        SecondBossBoxModel scbx = gameObject.GetComponent<SecondBossBoxModel>();

        rgBox = gameObject.GetComponent<Rigidbody2D>();
        if (fbbx != null || fithbx != null)
        {
            rgBox.velocity = new Vector2(-0.7f, 0);
        }
        if (fbx != null || sbx != null || fthbx != null || scbx)
        {
            rgBox.velocity = new Vector2(-1f, 0);
        }
        else if (sithbx != null)
        {
            rgBox.velocity = new Vector2(-1.2f, 0);
        }
        if (tbx != null)
        {
            rgBox.velocity = new Vector2(-1.5f, 0);
        }
    }
}
