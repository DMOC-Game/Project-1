using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    public Transform Tr;
    public Vector3 Pos;
    // Start is called before the first frame update
    void Start()
    {
        Tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;//��귽��
            LayerMask mask = LayerMask.GetMask("����");
            RaycastHit2D hit = Physics2D.Raycast(transform.position,mousePos,1000,mask);
            if (hit.collider!=null)//������������
            {
                print(hit.collider);
            }
        }
    }
}
