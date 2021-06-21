using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRush : MonoBehaviour
{
    private Rigidbody2D rb;
    private float rushSpeed=5f;
    private int sum;
    [SerializeField]private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveH, moveV;
        if (Input.GetButtonDown("Rush") && sum>=30)
        {
            sum = 0;
            moveH = Input.GetAxisRaw("Horizontal") * speed;//获得水平移动轴
            moveV = Input.GetAxisRaw("Vertical") * speed;//获得垂直移动轴
            //rb.velocity *= 5;
            rb.velocity += new Vector2(moveH, moveV);
            print(new Vector2(moveH, moveV));
        }

    }
    private void FixedUpdate()
    {
        sum=Mathf.Clamp(++sum,0,30);
        
    }
}
