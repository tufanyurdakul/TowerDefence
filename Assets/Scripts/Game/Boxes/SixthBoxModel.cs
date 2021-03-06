using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthBoxModel : MonoBehaviour
{
    public int boxArmour { get; set; }
    public int boxHealth { get; set; }
    public int boxFlameResist { get; set; }
    public int boxPositionResist { get; set; }
    public int boxDamage { get; set; }
    public int boxGlacierResist { get; set; }
    public int boxLightResist { get; set; }


    // Start is called before the first frame update
    void Awake()
    {
        boxArmour = 150;
        boxHealth = 6000;
        boxDamage = 2;
        boxFlameResist = 200;
        boxPositionResist = 100;
        boxGlacierResist = 100;
        boxLightResist = 100;
    }
}
