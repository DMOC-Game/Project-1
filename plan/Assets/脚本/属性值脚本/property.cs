using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class property : MonoBehaviour
{
    [Header("½ÇÉ«ÊôÐÔ")]
    public float HP;
    public float ARMOR;

    [HideInInspector] public POOL P=null;

    private float hp;
    private float armor;
    private void OnEnable()
    {
        hp = HP;
        armor = ARMOR;
    }
    public void Hurt(float ATK)
    {
        hp -=ATK - armor;
        print("DIE");
        if (hp <= 0)
        {
            
            if (P!=null) P.ReturnPool(this.gameObject);
            else
            {
                
                Destroy(this.gameObject);
            }
            
        }
        if (this.gameObject.GetComponent<Unmatched>() != null)
        {
            this.gameObject.GetComponent<Unmatched>().enabled = true;
        }
    }
}
