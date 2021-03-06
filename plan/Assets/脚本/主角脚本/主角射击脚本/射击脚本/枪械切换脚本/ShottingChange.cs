using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShottingChange : MonoBehaviour
{
    
    [SerializeField] private GameObject A;
    [SerializeField] private GameObject B;
    [SerializeField] private GameObject C;
    [HideInInspector]public float time;
    [HideInInspector] public float LeftTime;
    private GameObject[] bag=new GameObject[10];
    
    private int LastGunIndex, NowIndex;

    // Start is called before the first frame update
    void Awake()
    {
        
        bag[0] = Instantiate(A);  
        bag[1] = Instantiate(B);
        bag[2] = Instantiate(C);
        for(int i=0;i<3;i++)
        {
            //bag[i].GetComponent<SpriteRenderer>().enabled = false;
            bag[i].transform.SetParent(this.transform);
            CHANGE(bag[i]);

        }
        CHANGE(bag[0]);
        bag[0].GetComponent<SpriteRenderer>().enabled =true;
        NowIndex =0;
        LastGunIndex = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetAxis("Mouse ScrollWheel")!=0)
        {
            CHANGE(bag[NowIndex]);
            if(Input.GetAxis("Mouse ScrollWheel")<0)
            {
                NowIndex = (NowIndex + 1) % LastGunIndex;
            }
            else
            {
                NowIndex--;
                if (NowIndex < 0) NowIndex = LastGunIndex - 1;
            }
            CHANGE(bag[NowIndex]);
            return;
        }

    }
    void CHANGE(GameObject G)
    {
        if(G.GetComponent <Shotting>()!= null)
        {
            G.GetComponent<Shotting>().enabled = !G.GetComponent<Shotting>().enabled;
            
        }
        else if(G.GetComponent<RayLaser>() != null)
        {
            
            G.GetComponent<RayLaser>().enabled = !G.GetComponent<RayLaser>().enabled;
        }
        G.GetComponent<SpriteRenderer>().enabled = !G.GetComponent<SpriteRenderer>().enabled;
    }
    
}

   