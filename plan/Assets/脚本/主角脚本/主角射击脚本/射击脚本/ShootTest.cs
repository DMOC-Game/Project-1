using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Vector3 Mouse;
    public bool Shooting;   //���������־;
    public int coolDown;    //��ȴʱ��
    public float lastTime,curTime;
    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Pos;
        curTime = Time.time;
        if (curTime - Time.time > 0.1)
        {
            lastTime = Time.time;
            coolDown--;
        }
        Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);//ȡ����Ļ�������е����λ��
        Mouse.z = 0;
        if (Input.GetMouseButtonDown(0))
        {
            Shooting = true;
        }else if (Input.GetMouseButtonUp(0))
        {
            Shooting = false;
        }

        if (Shooting && coolDown == 0)
        {
            Transform Player = GameObject.Find("Player").transform;
            coolDown = 5;
            Pos = Player.position - Mouse;
            Instantiate(Player);
        }
        
    }
    private void FixedUpdate()
    {
        
    }
}
