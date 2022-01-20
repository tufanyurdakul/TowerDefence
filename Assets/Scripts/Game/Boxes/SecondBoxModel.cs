﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBoxModel : MonoBehaviour
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
        boxArmour = 30;
        boxHealth = 85;
        boxDamage = 5;
        boxFlameResist = 0;
        boxPositionResist = 5;
        boxGlacierResist = 5;
        boxLightResist = 5;
    }
}
