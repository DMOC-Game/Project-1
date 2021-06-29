
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
    LaserFade Give;

    private void Start()
    {
        
        S = gameObject.GetComponentInParent<ShottingChange>();
        if (transform.parent != null) transform.position = transform.parent.position;
        Give = Laser.GetComponent<LaserFade>();
        Give.Range = Range;
        Give.Accuracy = Accuracy;
        Give.GUN = gameObject;
        Give.hurt = Hurt;
        
        Give.returnTime = ReturnTime;
        
       
        
        
        
        LeftCoolDown = LaserCoolDown;
    }
    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        transform.right = (mouse - transform.position).normalized;
        if (transform.position.x < mouse.x) transform.localScale = new Vector3(1, 1, 1);
        else transform.localScale = new Vector3(1, -1, 1);
        if (Input.GetMouseButton(0) && LeftCoolDown <= 0)
        {
            
            for (int i = 0; i < LaserCount; i++)
            {
                Instantiate(Give);
                LeftCoolDown = LaserCoolDown;
            }
        }
        LeftCoolDown -= Time.deltaTime;
        S.time = LaserCoolDown;
        S.LeftTime = LeftCoolDown;
    }
    
    
}
