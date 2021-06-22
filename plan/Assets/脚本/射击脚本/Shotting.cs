using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotting : MonoBehaviour
{
    [SerializeField]public GameObject BulletStyle;
    [SerializeField]public int ShottingNumber;

    [SerializeField]public float ShottingSpeed;
    private BandOlier BD;
    void Awake()
    {
        BD = new BandOlier(gameObject, ShottingNumber, BulletStyle);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            BD.GetPoolOne();
        }
    }
}
