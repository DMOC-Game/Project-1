using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class property : MonoBehaviour
{
    [Header("½ÇÉ«ÊôÐÔ")]
    public float HP;
    public float ARMOR;
    [HideInInspector] public POOL P=null;
    public void Hurt(float ATK)
    {
        HP -=ATK - ARMOR;
        print("DIE");
        if (HP <= 0)
        {
            
            if (P!=null) P.ReturnPool(this.gameObject);
            else
            {
                
                Destroy(this.gameObject);
            }
        }
    }
}
