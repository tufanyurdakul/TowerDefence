using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceArea : MonoBehaviour
{
    // Start is called before the first frame update
    public int id { get; set; }
    void Start()
    {
        Destroy(gameObject, 4);
    }
}
