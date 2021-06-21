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
        rb = GetComponent<Rigidbody2D>();//��õ�ǰ�ű����ڵ�2D�������
    }

    // Update is called once per frame
    void Update()
    {
        Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);//ȡ����Ļ�������е����λ��
        Mouse.z = 0;
        //transform.up = (Mouse - transform.position).normalized; //�����ת
        moveH = Input.GetAxisRaw("Horizontal")*speed;//���ˮƽ�ƶ���
        moveV = Input.GetAxisRaw("Vertical")*speed;//��ô�ֱ�ƶ���
    }
    private void FixedUpdate()//�����unity�Դ��ģ��������Updata����һ���������������ǰ�ִ֡�У������ǰ��̶���ִ��
    {
        rb.velocity += new Vector2(moveH, moveV);
    }
}
