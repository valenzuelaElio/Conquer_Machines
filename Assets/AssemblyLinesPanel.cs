using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyLinesPanel : MonoBehaviour {

    private AssemblyLine[] allAssemblyLine;
    public GameObject AssemblyLineIconTemplate;

    void Start()
    {
        allAssemblyLine = GameState.Instance.GameData.AssemblyLines;

        for (int i = 0; i < allAssemblyLine.Length; i++)
        {
            GameObject assemblyLine = Instantiate(AssemblyLineIconTemplate) as GameObject;
            assemblyLine.SetActive(true);

            assemblyLine.GetComponent<AssemlbyLineTemplate>().AssemblyLineComponent = allAssemblyLine[i];
            //robot.GetComponent<RobotTemplate>().robotName.text = allAssemblyLine[i].RobotID;

            assemblyLine.transform.SetParent(AssemblyLineIconTemplate.transform.parent, false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
