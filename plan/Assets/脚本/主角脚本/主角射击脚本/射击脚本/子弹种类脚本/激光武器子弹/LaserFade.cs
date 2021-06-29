using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFade : MonoBehaviour
{
    [HideInInspector] public float Range;
    [HideInInspector] public float Accuracy;
    
    [HideInInspector] public GameObject GUN;
    [HideInInspector] public int hurt;
    [HideInInspector] public float returnTime;
    
    private LineRenderer Line;
    public float Alpha=1;
    private void OnEnable()
    {
        transform.position = new Vector3(0, 0, 0);
        Line = GetComponent<LineRenderer>();
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);// Û±Í∑ΩœÚ
        Vector3 NmousePos;
        mousePos.z = 0 ; //NmousePos = mousePos.normalized;
        LayerMask mask = 1 << 10 ;
        //print(mousePos);
        //print(mousePos.normalized+GUN.transform.position);

        NmousePos =  new Vector3(Random.Range(-Accuracy, Accuracy), Random.Range(-Accuracy, Accuracy),0);

        RaycastHit2D hit = Physics2D.Raycast(GUN.transform.position, (mousePos - GUN.transform.position).normalized + NmousePos, Range, mask);

        //Line.SetPosition(0, GUN.transform.position);
        //Line.SetPosition(1, mousePos + NmousePos);


        
        Line.SetPosition(0,GUN.transform.position);
        if (hit.collider != null)
        {
            //print(hit.point);
            Line.SetPosition(1, new Vector3(hit.point.x,hit.point.y));
            hit.collider.gameObject.GetComponent<property>().Hurt(hurt);
        }
        else
        {
            //Line.SetPosition(1, (mousePos.normalized  - GUN.transform.position) * Range );
            Line.SetPosition(1, (((mousePos-GUN.transform.position).normalized + NmousePos ).normalized * Range + GUN.transform.position) );
        }

    }
    private void Update()
    {
        Destroy(gameObject, returnTime);
    }
    /*private void OnEnable()
    {
        GetComponent<LineRenderer>().enabled = true;
    }*/

}
