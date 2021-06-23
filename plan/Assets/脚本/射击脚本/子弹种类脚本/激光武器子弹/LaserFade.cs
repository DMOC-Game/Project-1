using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFade : MonoBehaviour
{
    [HideInInspector] public float Range;
    [HideInInspector] public float Accuracy;
    [HideInInspector] public POOL P;
    [HideInInspector] public GameObject GUN;
    [HideInInspector] public int hurt;
    [HideInInspector] public float returnTime;
    private float LeftTime;
    private LineRenderer Line;
    public float Alpha=1;
    private void OnEnable()
    {
        
        Line = GetComponent<LineRenderer>();
        LeftTime = returnTime;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - GUN.transform.position;// Û±Í∑ΩœÚ
        mousePos.z = 0 ; mousePos = mousePos.normalized;
        LayerMask mask = 1 << 8 | 1 << 6;

        mousePos = mousePos + new Vector3(Random.Range(-Accuracy, Accuracy), Random.Range(-Accuracy, Accuracy),0);

        RaycastHit2D hit = Physics2D.Raycast(GUN.transform.position, mousePos, Range, mask);
        Line.SetPosition(0, new Vector3(GUN.transform.position.x, GUN.transform.position.y));
        if (hit.collider != null)
        {
            Line.SetPosition(1, new Vector3(hit.point.x, hit.point.y));
            hit.collider.gameObject.GetComponent<property>().Hurt(hurt);
        }
        else
        {
            Line.SetPosition(1, mousePos * Range);
        }
    }
    private void Update()
    {
        if (LeftTime <= 0) P.ReturnPool(this.gameObject);
        LeftTime -= Time.deltaTime;
    }
    /*private void OnEnable()
    {
        GetComponent<LineRenderer>().enabled = true;
    }*/

}
