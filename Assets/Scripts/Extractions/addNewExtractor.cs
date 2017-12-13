using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addNewExtractor : MonoBehaviour {

    private GenericListLoader gll;
    public static int index = 10;

    void Start()
    {
        this.gll = GetComponent<GenericListLoader>();
    }

    public void addNew()
    {
        DataExtractor newExtractor = new DataExtractor();
        newExtractor.Id = "EX00" + index;
        index++;

        newExtractor.rawMaterial_Id = "";
        newExtractor.rawMaterial_initialQnty = 0;
        newExtractor.rawMaterial_recolectedQnty = 0;

        newExtractor.robot_id = "";
        newExtractor.robot_initialQnty = 0;
        newExtractor.robot_Left = 0;

        DataManager.AllExtractors.Add(newExtractor);
        this.gll.UpdateList();


    }
}
