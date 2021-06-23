using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFade : MonoBehaviour
{
    [SerializeField] private float Range;
    [SerializeField] private float Accuracy;
    private LineRenderer Line;
    public int LaserFadeTime = 60;
    public float Alpha=1;
    private void Awake()
    {
        Transform Player;
        Player = GameObject.Find("player").transform;
        Line = GetComponent<LineRenderer>();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Player.position;// Û±Í∑ΩœÚ
        mousePos.z = 0 ; mousePos = mousePos.normalized;
        LayerMask mask = 1 << 8 | 1 << 6;

        mousePos = mousePos + new Vector3(Random.Range(-Accuracy, Accuracy), Random.Range(-Accuracy, Accuracy),0);

        RaycastHit2D hit = Physics2D.Raycast(Player.position, mousePos, Range, mask);
        Line.SetPosition(0, new Vector3(Player.position.x, Player.position.y));
        if (hit.collider != null)
        {
            Line.SetPosition(1, new Vector3(hit.point.x, hit.point.y));
        }
        else
        {
            Line.SetPosition(1, mousePos * Range);
        }
    }
    /*private void OnEnable()
    {
        GetComponent<LineRenderer>().enabled = true;
    }*/
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

}
