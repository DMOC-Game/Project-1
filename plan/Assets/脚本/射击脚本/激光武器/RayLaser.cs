using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayLaser : MonoBehaviour
{
    int LaserCoolDown = 60;
    [SerializeField]private GameObject Laser;
    [SerializeField]private float DestroyTime;
    [SerializeField] private float CloneCount;
    GameObject NewLaser;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        print(LaserCoolDown);
        if (Input.GetMouseButton(0) && LaserCoolDown == 0)
        {
            LaserCoolDown = 60;
            for (int i = 0; i < CloneCount; i++)
            {
                NewLaser = Instantiate(Laser);
                Destroy(NewLaser, DestroyTime);
            }
        }
        if (LaserCoolDown > 0)
        { 
            LaserCoolDown--;
        };
    }
}
