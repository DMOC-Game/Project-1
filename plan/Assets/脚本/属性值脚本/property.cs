using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class property : MonoBehaviour
{
    [Header("½ÇÉ«ÊôÐÔ")]
    public float HP;
    public float ARMOR;
    void Update()
    {
        if (HP <= 0) Destroy(this.gameObject);
    }

    public void Hurt(float ATK)
    {
        HP -= ATK - ARMOR;
;
    }
}
