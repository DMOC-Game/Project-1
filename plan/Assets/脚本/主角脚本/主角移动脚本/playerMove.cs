using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    private Vector3 Mouse;
    [SerializeField]private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//获得当前脚本所在的2D刚体组件
    }

    // Update is called once per frame
    void Update()
    {
        Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);//取得屏幕到世界中的鼠标位置
        Mouse.z = 0;
        //transform.up = (Mouse - transform.position).normalized; //玩家旋转
        moveH = Input.GetAxisRaw("Horizontal")*speed;//获得水平移动轴
        moveV = Input.GetAxisRaw("Vertical")*speed;//获得垂直移动轴
    }
    private void FixedUpdate()//这个是unity自带的，和上面的Updata大致一样，区别是上面是按帧执行，下面是按固定秒执行
    {
        rb.velocity += new Vector2(moveH, moveV);
    }
}
