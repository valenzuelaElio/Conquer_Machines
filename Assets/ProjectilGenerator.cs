using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilGenerator : MonoBehaviour {
    public GameObject toInstantiate;

    private bool startToGen;
    public bool StartToGen { get { return startToGen; } set { startToGen = value; } }

    float StartTime;
    float TimeStamp;
    float Delay;

	// Use this for initialization
	void Start () {
        startToGen = false;
        StartTime = Time.time;
        Delay = 3;
	}
	
	// Update is called once per frame
	void Update () {


        TimeStamp = Time.time - StartTime;
        if(startToGen == true  && TimeStamp >= Delay)
        {
            Shoot();
            StartTime = Time.time;
        }

	}

    private void Shoot()
    {
        GameObject go = Instantiate(toInstantiate, transform.position, transform.rotation) as GameObject;
    }




}
