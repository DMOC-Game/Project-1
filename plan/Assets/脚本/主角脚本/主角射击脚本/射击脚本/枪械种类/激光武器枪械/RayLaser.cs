
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayLaser : MonoBehaviour
{
    [SerializeField] private float LaserCoolDown;
    [SerializeField] private GameObject Laser;
    [SerializeField] private int POOLCount;
    [SerializeField] private int LaserCount;
    [SerializeField] private float Range;
    [SerializeField] private float Accuracy;
    [SerializeField] private int Hurt;
    [SerializeField] private float ReturnTime;
    private ShottingChange S;
    private float  LeftCoolDown;
    POOL P;

    private void Start()
    {
        P = gameObject.AddComponent<POOL>();
        S = gameObject.GetComponentInParent<ShottingChange>();
        if (transform.parent != null) transform.position = transform.parent.position;
        LaserFade Give = Laser.GetComponent<LaserFade>();
        Give.Range = Range;
        Give.Accuracy = Accuracy;
        Give.GUN = gameObject;
        Give.hurt = Hurt;
        Give.P = P;
        Give.returnTime = ReturnTime;
        
        P.GetGameObject(this.gameObject, POOLCount, Laser);
        
        
        
        LeftCoolDown = LaserCoolDown;
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && LeftCoolDown <= 0)
        {
            
            for (int i = 0; i < LaserCount; i++)
            {
                P.GetPoolOne();
                LeftCoolDown = LaserCoolDown;
            }
        }
        LeftCoolDown -= Time.deltaTime;
        S.time = LaserCoolDown;
        S.LeftTime = LeftCoolDown;
    }
    
    
}
