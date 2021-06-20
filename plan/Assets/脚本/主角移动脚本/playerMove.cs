using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//��õ�ǰ�ű����ڵ�2D�������
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal")*speed;//���ˮƽ�ƶ���
        moveV = Input.GetAxisRaw("Vertical")*speed;//��ô�ֱ�ƶ���
    }
    private void FixedUpdate()//�����unity�Դ��ģ��������Updata����һ���������������ǰ���ִ�У������ǰ�ִ֡��
    {
        rb.velocity = new Vector2(moveH, moveV);
    }
}
