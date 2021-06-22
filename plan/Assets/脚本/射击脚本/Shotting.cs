using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotting : MonoBehaviour
{
    [SerializeField]public GameObject BulletStyle;//����ͼƬ
    [SerializeField]public int ShottingNumberPool;//��ϻ������
    [SerializeField] public int ShottingCount;//һ��������ٷ�װ��(��δ����)
    [SerializeField] public float ShottingCD;//������
    [SerializeField] public float FlySpeed;//����ٶ�
    [SerializeField] public float hurt;//ÿ���ӵ�����˺�
    private float leftCd=0;
    private POOL BD;//����һ����ϻ
    void Awake()
    {
        var GiveBull= BulletStyle.GetComponent<OneBullet>();
        GiveBull.OneBulleSpeed = FlySpeed;
        GiveBull.hurt = hurt;
        BD = new POOL(gameObject, ShottingNumberPool, BulletStyle);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            leftCd -= Time.deltaTime;
            if(leftCd<=0)
            {
                BD.GetPoolOne();
                leftCd = ShottingCD;
            }
        }
    }
}
