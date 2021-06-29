using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rebirth : MonoBehaviour
{
    property P;
   
    private void OnEnable()
    {
        this.gameObject.transform.position = new Vector3(22+ Random.Range(-3, 3), 1+ Random.Range(-3, 3), 0);
        P=GetComponent<property>();
        P.hp = P.HP;
        GetComponent<rebirth>().enabled = false;
    }
    
}
