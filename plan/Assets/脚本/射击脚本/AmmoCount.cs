using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCount : MonoBehaviour
{
    public RectTransform rt;
    static Vector3 Pos;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        int x, y;
        Pos = Input.mousePosition;
        x = Screen.width/2;y = Screen.height/2;
        //Pos.z = 0;
        rt.transform.localPosition = Pos - new Vector3(x,y,0);
    }
}
