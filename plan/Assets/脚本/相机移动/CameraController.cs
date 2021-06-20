using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;//���ڻ��palyer��transform���
    [SerializeField]private float smoothSpeed;//����ƶ��ٶ�,ǰ׺��[SerializeField],����ʹ��������unity��������޸Ĳ���
    [SerializeField]private float minx,miny,maxx,maxy;
    private void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void LateUpdate()//ִ��ʱ�䲻��update������Ϊ���������ƶ�����������ƶ�
    {
        transform.position = Vector3.Lerp(transform.position,new Vector3(target.position.x,target.position.y,-10),smoothSpeed*Time.deltaTime);
        //��һ��������ʾ��ǰλ�ã������λ�ã����ڶ���������ʾĿ��λ�ã����Ҫ���ĵط�����player��
        //����������Ϊ�ƶ��ٶȣ����ƶ�����������ʱ��
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,minx,maxx),Mathf.Clamp(transform.position.y,miny,maxy),transform.position.z);
       // Mathf.Clamp()1:��ϣ�����ƵĲ�����2��3:���������Χ�������Сֵ
    }
}
