using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthBoxModel : MonoBehaviour
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
        boxArmour = 0;
        boxHealth = 370;
        boxDamage = 4;
        boxFlameResist = 35;
        boxPositionResist = 40;
        boxGlacierResist = 40;
        boxLightResist = 40;
    }
}
