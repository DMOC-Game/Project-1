using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmoCount : MonoBehaviour
{
    public RectTransform rt;
    private Image I;
    private ShottingChange S;
    static Vector3 Pos;
    
    // Start is called before the first frame update
    void Awake()
    {
        rt = GetComponent<RectTransform>();
        I = GetComponent<Image>();
        S = GameObject.Find("player").GetComponentInChildren<ShottingChange>();
    }

    // Update is called once per frame
    void Update()
    {
        //移动到鼠标位置
        int x, y;
        Pos = Input.mousePosition;
        x = Screen.width/2;y = Screen.height/2;
        //Pos.z = 0;
        rt.transform.localPosition = Pos - new Vector3(x,y,0);
        //进度条
        I.fillAmount =Mathf.Clamp((S.time-S.LeftTime)/S.time * 0.25f ,0,0.25f);
    }
}
