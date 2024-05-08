using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    public BoxCollider2D plaeyrBox;
    public List<BoxCollider2D> enimeBoxes;
    //boo who Im coding it for you and there isn't anything you can do
    private int spawnCount = 0;
    private bool isBoss;
    private int calculateSpawnCount;
    private int level = 1;
    private int whichNode;
    public GameObject enmi;
    //stupid thing as placeholder till I can unstupid don't judge it technically works ig
    private int enmiePlace1;
    private int enmiePlace2;
    private int enmiePlace3;
    private bool enmieBoss1 = false;
    private bool enmieBoss2 = false;
    private bool enmieBoss3 = false;
    private int bossCalc;
    private bool isBossReady = false;
    void Start()
    {
        calculateSpawnCount = level * 3;
        enmiePlace1 = 0;
        enmiePlace2 = 0;
        enmiePlace3 = 0;
    }

    void placeEnmie()
    {
        if(enmieBoss1 == false && enmieBoss2 == false && enmieBoss3 == false && isBossReady == true)
        {
            bossCalc = Random.Range(1, 6);
            if (bossCalc == 1)
            {
                enmieBoss1 = true;
                print("Enimie 1 " + enmieBoss1);
            }
            if (bossCalc == 2 || bossCalc == 3)
            {
                enmieBoss2 = true;
                print("Enimie 2 " + enmieBoss2);
            }
            if(bossCalc >= 4)
            {
                enmieBoss3 = true;
                print("Enimie 3 " + enmieBoss3);
            }
        }
        GameObject go1 = GameObject.Instantiate(enmi);
        go1.transform.position = transform.position;
    }

    void Update()
    {
        if (spawnCount < calculateSpawnCount)
        {
            whichNode = Random.Range(1, 4);
            if(whichNode != enmiePlace1 && whichNode != enmiePlace2 && whichNode != enmiePlace3)
            {
                if(enmiePlace1 == 0)
                {
                    enmiePlace1 = whichNode;
                }
               else if (enmiePlace2 == 0)
                {
                    enmiePlace2 = whichNode;
                }
                else if (enmiePlace3 == 0)
                {
                    enmiePlace3 = whichNode;
                    isBossReady = true;
                }
                print("Node " + whichNode);
                placeEnmie();
                spawnCount++;
            }
            
        }
    }
}
