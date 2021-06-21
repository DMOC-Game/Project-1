using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;//���ڻ��palyer��transform���
    [SerializeField]private float smoothSpeed;//����ƶ��ٶ�,ǰ׺��[SerializeField],����ʹ��������unity��������޸Ĳ���
    [SerializeField]private float minx,miny,maxx,maxy;
    private void LateUpdate()//ִ��ʱ�䲻��update������Ϊ���������ƶ�����������ƶ�
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(Mathf.Clamp(target.position.x,minx,maxx), Mathf.Clamp(target.position.y,miny,maxy),-10),
            smoothSpeed*Time.deltaTime);
        //��һ��������ʾ��ǰλ�ã������λ�ã����ڶ���������ʾĿ��λ�ã����Ҫ���ĵط�����player��
        //����������Ϊ�ƶ��ٶȣ����ƶ�����������ʱ��
       // Mathf.Clamp()1:��ϣ�����ƵĲ�����2��3:���������Χ�������Сֵ
    }
}
