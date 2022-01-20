using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthBoxModel : MonoBehaviour
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
        boxArmour = 120;
        boxHealth = 1500;
        boxDamage = 5;
        boxFlameResist = 90;
        boxPositionResist = 110;
        boxGlacierResist = 200;
        boxLightResist = 200;
    }
}
