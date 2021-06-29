using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HP : MonoBehaviour
{
    private property P;
    private Image S;
    private float MaxHp;
    private void Start()
    {
        P = GameObject.Find("player").GetComponent<property>();
        S = gameObject.GetComponent<Image>();
        MaxHp = P.HP;
    }
    // Update is called once per frame
    void Update()
    {
        S.fillAmount = P.hp / MaxHp;

    }
}
