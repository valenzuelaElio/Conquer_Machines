using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNewAssemblyLine : MonoBehaviour {

    private GenericListLoader gll;
    public static int index = 10;

	void Start () {
        this.gll = GetComponent<GenericListLoader>();
	}
	
    public void addNew()
    {
        index++;
        DataAssemblyLine newAssemblyLine = new DataAssemblyLine();
        newAssemblyLine.assembly_Line_Id = "AL00" + index;

        newAssemblyLine.core_id = "";
        newAssemblyLine.upgrade_Node_1 = "";
        newAssemblyLine.upgrade_Node_2 = "";
        newAssemblyLine.upgrade_Node_3 = "";

        DataManager.AllAssemblyLines.Add(newAssemblyLine);
        this.gll.UpdateList();


    }

}
