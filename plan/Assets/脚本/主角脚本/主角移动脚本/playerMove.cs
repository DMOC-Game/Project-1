using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    private Vector3 Mouse;
    [SerializeField]private float MoveSpeed;
 
    [SerializeField] private float DashSpeed;//����ٶ�
    private float lastDash=-10f;//���һ�γ��ʱ��
    [SerializeField] private float DashTime;//һ�γ��ʱ��
    private float DashLeft;//���ʣ��ʱ��
    [SerializeField] private float DashCD;//��ȴʱ��
    private bool IsDash;//�ж��Ƿ���Գ��
    private Image S;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//��õ�ǰ�ű����ڵ�2D�������
        S = GameObject.Find("Mp-I").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);//ȡ����Ļ�������е����λ��
        //Mouse.z = 0;
        //transform.up = (Mouse - transform.position).normalized; //�����ת
        
        if(!IsDash)
        {
            moveH = Input.GetAxisRaw("Horizontal");//���ˮƽ�ƶ���
            moveV = Input.GetAxisRaw("Vertical");//��ô�ֱ�ƶ���
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(lastDash<0)
            {
                ReadyToDash();
            }
        }
        lastDash -= Time.deltaTime;
        S.fillAmount = Mathf.Clamp(1-lastDash / DashCD,0,1);
    }
    void FixedUpdate()//�����unity�Դ��ģ��������Updata����һ���������������ǰ�ִ֡�У������ǰ��̶���ִ��
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
        lastDash=DashCD;
        
    }


    void Dash()
    {
        if(IsDash)
        {
            if(DashLeft>0)
            {
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("RedNpc"), true);
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("RedBullet"), true);
                rb.velocity =new Vector2(moveH * DashSpeed, moveV * DashSpeed);
                DashLeft -= Time.deltaTime;
                ShadowPool.instance.GetPoolOne();
            }
            else
            {
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("RedNpc"), false);
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("RedBullet"), false);
                IsDash = false;
            }
        }
    }
}
