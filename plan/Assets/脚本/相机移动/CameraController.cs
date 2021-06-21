using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;//用于获得palyer的transform组件
    [SerializeField]private float smoothSpeed;//相机移动速度,前缀的[SerializeField],可以使开发者在unity的组件中修改参数
    [SerializeField]private float minx,miny,maxx,maxy;
    private void LateUpdate()//执行时间不及update，这是为了让人物移动后，再让相机移动
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(Mathf.Clamp(target.position.x,minx,maxx), Mathf.Clamp(target.position.y,miny,maxy),-10),
            smoothSpeed*Time.deltaTime);
        //第一个参数表示当前位置（即相机位置），第二个参数表示目标位置（相机要到的地方，即player）
        //第三个参数为移动速度，即移动到那里所需时间
       // Mathf.Clamp()1:你希望限制的参数。2、3:限制这个范围的最大最小值
    }
}
