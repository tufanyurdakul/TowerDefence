using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBossBoxModel : MonoBehaviour
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
        boxArmour = 10;
        boxHealth = 4450;
        boxDamage = 11;
        boxFlameResist = 160;
        boxPositionResist = 80;
        boxGlacierResist = 20;
        boxLightResist = 40;
    }
}

