using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contrMain : MonoBehaviour
{
    public GameObject car;
    static public HealsBar hb;
    public GameObject hbOb;
    public GameObject roadMover;
    public GameObject randSpawn;
    public GameObject movPref;
    public bool end = false;
    private RoadMover rm;
    private RandomSpawn rs;
    private movingPrefabs mf;

    private void Start()
    {
        hb = hbOb.GetComponent<HealsBar>();
        hb.calculatedHeals(-100);
        rm = roadMover.GetComponent<RoadMover>();
        rs = randSpawn.GetComponent<RandomSpawn>();
        mf = movPref.GetComponent<movingPrefabs>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle" && collision.gameObject.layer == 8 && hb.realHeals != 100)
        {
            hb.calculatedHeals(-10);
        }
        else if (collision.gameObject.tag == "obstacle" && collision.gameObject.layer != 8)
        {
            hb.calculatedHeals(10);
        }
    }
    private void Update()
    {
        if (hb.realHeals == 0)
        {
            end = true;
            StopCoroutine(mf.enumerator);
            StopCoroutine(rs.spawn);
            StopCoroutine(rm.roadCoroutine);
        }


    }

}
