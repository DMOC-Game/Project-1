using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Vector3 Mouse;
    public bool Shooting;   //持续射击标志;
    public int coolDown;    //冷却时间
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);//取得屏幕到世界中的鼠标位置
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
