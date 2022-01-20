using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdBoxModel : MonoBehaviour
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
        boxHealth = 100;
        boxDamage = 6;
        boxFlameResist = 0;
        boxPositionResist = 3;
        boxGlacierResist = 12;
        boxLightResist = 12;
    }
}
