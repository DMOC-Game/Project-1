using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Vector3 Mouse;
    public bool Shooting;   //���������־;
    public int coolDown;    //��ȴʱ��
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);//ȡ����Ļ�������е����λ��
        Mouse.z = 0;
        if (Input.GetMouseButtonDown(0))
        {
            Shooting = true;
        }else if (Input.GetMouseButtonUp(0))
        {
            Shooting = false;
        }
        /*
        if(Shooting && coolDown == 0)
        {

        }
        */
    }
    private void FixedUpdate()
    {
        
    }
}
