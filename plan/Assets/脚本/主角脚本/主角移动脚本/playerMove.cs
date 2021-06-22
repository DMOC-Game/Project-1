using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    private Vector3 Mouse;
    [SerializeField]private float MoveSpeed;
 
    [SerializeField] private float DashSpeed;//冲刺速度
    private float lastDash=-10f;//最后一次冲刺时间
    [SerializeField] private float DashTime;//一次冲刺时间
    private float DashLeft;//冲刺剩余时间
    [SerializeField] private float DashCD;//冷却时间
    private bool IsDash;//判断是否可以冲刺
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//获得当前脚本所在的2D刚体组件
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);//取得屏幕到世界中的鼠标位置
        //Mouse.z = 0;
        //transform.up = (Mouse - transform.position).normalized; //玩家旋转
        
        moveH = Input.GetAxisRaw("Horizontal");//获得水平移动轴
        moveV = Input.GetAxisRaw("Vertical");//获得垂直移动轴
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time>=lastDash+DashCD)
            {
                ReadyToDash();
            }
        }
    }
    void FixedUpdate()//这个是unity自带的，和上面的Updata大致一样，区别是上面是按帧执行，下面是按固定秒执行
    {
        Dash();
        if (IsDash) return;
        PlayerMove();
    }

    void PlayerMove()
    {
        rb.velocity = new Vector2(moveH*MoveSpeed, moveV*MoveSpeed);
    }

    void ReadyToDash()
    {
        IsDash = true;
        DashLeft = DashTime;
        lastDash=Time.time; 
    }


    void Dash()
    {
        if(IsDash)
        {
            if(DashLeft>0)
            {
                rb.velocity =new Vector2(moveH * DashSpeed, moveV * DashSpeed);
                DashLeft -= Time.deltaTime;
                ShadowPool.instance.GetPoolOne();
            }
            else
            {
                IsDash = false;
            }
        }
    }
}
