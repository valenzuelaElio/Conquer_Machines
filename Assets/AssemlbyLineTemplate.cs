using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemlbyLineTemplate : MonoBehaviour {
    private AssemblyLine assemblyLine;
    public AssemblyLine AssemblyLineComponent { get { return assemblyLine; } set { assemblyLine = value; } }

    //public Dictionary<string, GameObject> Nodes;
    public GameObject Node1;
    public GameObject Node2;
    public GameObject Node3;
    public GameObject Node4;

    public GameObject RobotResult;

    /*
    void Start () {

        switch (assemblyLine.AssemblyLineNodes.Count)
        {
            case 0:
                Node1.SetActive(false);
                Node2.SetActive(false);
                Node3.SetActive(false);
                Node4.SetActive(false);
                break;

            case 1:
                Node1.SetActive(true);
                Node2.SetActive(false);
                Node3.SetActive(false);
                Node4.SetActive(false);
                break;

            case 2:
                Node1.SetActive(true);
                Node2.SetActive(true);
                Node3.SetActive(false);
                Node4.SetActive(false);
                break;

            case 3:
                Node1.SetActive(true);
                Node2.SetActive(true);
                Node3.SetActive(true);
                Node4.SetActive(false);
                break;

            case 4:
                Node1.SetActive(true);
                Node2.SetActive(true);
                Node3.SetActive(true);
                Node4.SetActive(true);
                break;

        }

	}
	*/
	// Update is called once per frame
	void Update () {
		
	}
}
