using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;//���ڻ��palyer��transform���
    [SerializeField]private float smoothSpeed;//����ƶ��ٶ�,ǰ׺��[SerializeField],����ʹ��������unity��������޸Ĳ���
    private void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void LateUpdate()//ִ��ʱ�䲻��update������Ϊ���������ƶ�����������ƶ�
    {
        transform.position = Vector3.Lerp(transform.position,new Vector3(target.position.x,target.position.y,-10),smoothSpeed*Time.deltaTime);
        //��һ��������ʾ��ǰλ�ã������λ�ã����ڶ���������ʾĿ��λ�ã����Ҫ���ĵط�����player��
        //����������Ϊ�ƶ��ٶȣ����ƶ�����������ʱ��
    }
}
