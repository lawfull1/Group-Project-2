using System;
using System.Collections.Generic;
using UnityEngine;



public class Raycast : MonoBehaviour
{
    public GameObject hitBox;
    public GameObject player;
    public GameObject Line;
    private LineRenderer lineRen;
    private LineRenderer renderLine;
    public LayerMask Level;
    public Collider2D boxHit;
    private Vector3 change;
    public float minDis = 1f;
    public float maxDis = 200f;
    private LineRenderer lstRend;
    private GameObject lstLin;
    public GameObject raysPar;

    private GameObject RendLn;
    private LineRenderer RendR;

    public List<GameObject> lines;
    public List<GameObject> RenderingLines;
    public Material woh1;
    public GameObject Rend;
    public GameObject GameRender;

    private int RES = 2;
    private int Fov = 60;
    private float Dir;
    private float x;
    private float distance;
    private float Hight;

    float H = 31;
    float S = 100;
    float V = 100;

    private void Start()
    {

        lineRen = Line.GetComponent<LineRenderer>();
        renderLine = Line.GetComponent<LineRenderer>();
        for (var i = 0; i < 200; i++)
        {
            lstLin = Instantiate(Line, raysPar.transform);
            lines.Add(lstLin);
            RendLn = Instantiate(Rend, GameRender.transform);
            RenderingLines.Add(RendLn);
        }
        
    }

    private void Update()
    {

        RaycastHit2D rayCast = Physics2D.Raycast(player.transform.position, transform.TransformDirection(Vector2.up) * 10f, 100f, Level);
        Debug.DrawRay(player.transform.position, transform.TransformDirection(Vector2.up) * 10f, Color.red);

        for (var i = 0; i < 101; i++)
        {
            lstRend = lines[i].GetComponent<LineRenderer>();
            RaycastHit2D rayCast1 = Physics2D.Raycast(player.transform.position, transform.TransformDirection(Quaternion.Euler(0, 0, (i * 1f-50)*0.5f) * Vector2.up) * 10f, maxDis, Level);
            lstRend.SetPosition(0, player.transform.position);
            Render(rayCast1, i);
            if (rayCast1 == true){
                lstRend.SetPosition(1, rayCast1.point);
            }else{
                lstRend.SetPosition(1, raysPar.transform.position);
            }
        }
        for (var i = 101; i < 200; i++)
        {
            lstRend = lines[i].GetComponent<LineRenderer>();
            RaycastHit2D rayCast1 = Physics2D.Raycast(player.transform.position, transform.TransformDirection(Quaternion.Euler(0, 0, (i*1f-20)*0.5f) * Vector2.up) * 10f, maxDis, Level);
            lstRend.SetPosition(0, player.transform.position);
            Render(rayCast1, i);
            if (rayCast1 == true){
                lstRend.SetPosition(1, rayCast1.point);
            }else{
                lstRend.SetPosition(1, raysPar.transform.position);
            }
            
        }
        
    }
  
    void Render(RaycastHit2D rayCast1, int i)
    {
        distance = rayCast1.distance;
        x = (RES / 2) - 240;
        Dir = transform.rotation.z;
        Hight = distance * Mathf.Atan(Hight);
        Hight = 4000 / Hight;
        Hight = Hight / 200;
        
        V = Hight;
        RendR = RenderingLines[i].GetComponent<LineRenderer>();
        if (!(distance == 0)) {
            Color renderingColor = new Color();
            Material mats = new Material(Shader.Find("Unlit/Color"));
            renderingColor = Color.HSVToRGB(0.10f, 1, MathF.Log(V));
            mats.SetColor("_Color", renderingColor);
            Debug.Log(V);
            RendR.SetPosition(0, GameRender.transform.TransformPoint(((i * x) / 1200f) + 11, Hight, 0));
            RendR.SetPosition(1, GameRender.transform.TransformPoint(((i * x) / 1200f) + 11, -Hight, 0));
            RendR.gameObject.SetActive(true);
            RendR.material = mats;
        }
        else
        {
            RendR.gameObject.SetActive(false);

        }
        
        
    }




}

