using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayLaser : MonoBehaviour
{
    LineRenderer Line;
    public Transform Player;
    public Vector3 Pos;
    // Start is called before the first frame update
    void Start()
    {
        Line = GetComponent<LineRenderer>();
        //Player = GameObject.Find("Player").transform;
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Player.position;//鼠标方向
            LayerMask mask = LayerMask.GetMask("敌人");
            RaycastHit2D hit = Physics2D.Raycast(Player.position,mousePos,1000,mask);
            //print(mousePos);print(Player.position);
            if (hit.collider!=null)//击中人物组检测
            {
                Line.SetPosition(0, new Vector3(hit.point.x,hit.point.y));
                Line.SetPosition(1, new Vector3(Player.position.x, Player.position.y));
            }
        }
    }
}
