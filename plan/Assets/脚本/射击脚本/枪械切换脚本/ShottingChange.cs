using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShottingChange : MonoBehaviour
{
    
    [SerializeField] private GameObject A;
    [SerializeField] private GameObject B;
    private GameObject[] bag=new GameObject[10];
    private int LastGunIndex, NowIndex;

    // Start is called before the first frame update
    void Start()
    {

        bag[0] = Instantiate(A);  
        bag[1] = Instantiate(B);
        for(int i=0;i<2;i++)
        {
            bag[i].transform.SetParent(this.transform);
            bag[1].SetActive(false);
        }
        bag[0].SetActive(true);
        NowIndex=0;
        LastGunIndex = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel")!=0)
        {
            bag[NowIndex].SetActive(false);
            if(Input.GetAxis("Mouse ScrollWheel")<0)
            {
                NowIndex = (NowIndex + 1) % LastGunIndex;
            }
            else
            {
                NowIndex--;
                if (NowIndex < 0) NowIndex = LastGunIndex - 1;
            }
            bag[NowIndex].SetActive(true);
        }
    }
}
