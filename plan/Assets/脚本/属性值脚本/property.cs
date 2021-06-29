using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class property : MonoBehaviour
{
    [Header("½ÇÉ«ÊôÐÔ")]
    public float HP;
    public float ARMOR;
    
    public GameObject DeadBody;
    [HideInInspector] public POOL P=null;

    [HideInInspector] public float hp;
    private float armor;
    private void OnEnable()
    {
        hp = HP;
        armor = ARMOR;

    }
    
    public void Hurt(float ATK)
    {
        hp -=ATK - armor;
        
        if (hp <= 0)
        {
            DeadBody.transform.position = this.gameObject.transform.position;
            Instantiate(DeadBody);
            if (P!=null)
            {
                P.ReturnPool(this.gameObject);
                P.GetComponent<NPCMake>().MostCount++;
            }
            else
            {
                GetComponent<rebirth>().enabled = true;
                
            }
            
        }
        if (this.gameObject.GetComponent<Unmatched>() != null)
        {
            this.gameObject.GetComponent<Unmatched>().enabled = true;
            
        }
        else
        {
            if(ATK-armor>0)
            {
                gameObject.GetComponent<flicker>().enabled = true;
            }
        }
    }
}
