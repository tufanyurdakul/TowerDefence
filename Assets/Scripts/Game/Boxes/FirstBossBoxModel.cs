﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossBoxModel : MonoBehaviour
{
    // Start is called before the first frame update
 
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
        boxArmour = 0;
        boxHealth = 700;
        boxDamage = 10;
        boxFlameResist = 0;
        boxPositionResist = 0;
        boxGlacierResist = 0;
        boxLightResist = 0;
    }
}

