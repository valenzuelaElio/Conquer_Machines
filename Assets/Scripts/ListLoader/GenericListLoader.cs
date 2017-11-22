using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericListLoader : MonoBehaviour {
    public enum ElementListType
    {
        Extractors,
        Robots,
        Misions,
        AssemblyLine,
        Node_Core,
        Node_Upgrade,
        RawMaterial,
    }
    public ElementListType elementListType;
    public GameObject ItemTemplate;//Esto es lo que deveria instanciarse en la pantalla.
    public List<object> GenericList = new List<object>();

    void Start () {
        LoadList();
        for (int i = 0; i < GenericList.Count; i++)
        {
            GameObject obj = Instantiate(ItemTemplate) as GameObject;
            obj.SetActive(true);

            switch (elementListType)
            {
                case ElementListType.AssemblyLine:
                    obj.GetComponent<AssemblyLine>().MyAssemblyLine = (DataAssemblyLine)GenericList[i];
                    obj.GetComponent<AssemblyLine>().ShowData();
                    break;

                case ElementListType.Extractors:
                    obj.GetComponent<Extractor>().MyExtractor = (DataExtractor)GenericList[i];
                    obj.GetComponent<Extractor>().ShowData();
                    break;

                case ElementListType.Misions:
                    obj.GetComponent<Mision>().MyMision = (DataMision)GenericList[i];
                    obj.GetComponent<Mision>().ShowData();
                    break;

                case ElementListType.Robots:
                    obj.GetComponent<Robot>().MyRobot = (DataRobot)GenericList[i];
                    obj.GetComponent<Robot>().ShowData();
                    break;

                case ElementListType.Node_Core:
                    obj.GetComponent<CoreNode>().MyNode = (Core)GenericList[i];
                    //obj.GetComponent<CoreNode>().ShowData();
                    break;

                case ElementListType.Node_Upgrade:
                    obj.GetComponent<Node>().MyNode = (DataNode)GenericList[i];
                    obj.GetComponent<Node>().ShowData();
                    break;

                case ElementListType.RawMaterial:
                    break;
            }
            obj.transform.SetParent(ItemTemplate.transform.parent, false);
        }
    }

    void LoadList()
    {
        switch (elementListType)
        {
            case ElementListType.AssemblyLine:
                this.GenericList.Clear();
                for (int i = 0; i < DataManager.AllAssemblyLines.Count; i++)
                    if (DataManager.AllAssemblyLines != null)
                        this.GenericList.Add(DataManager.AllAssemblyLines[i]);
                break;

            case ElementListType.Extractors:
                this.GenericList.Clear();
                for (int i = 0; i < DataManager.AllExtractors.Count; i++)
                    if (DataManager.AllExtractors != null)
                        this.GenericList.Add(DataManager.AllExtractors[i]);
                break;
            case ElementListType.Misions:
                this.GenericList.Clear();
                for (int i = 0; i < DataManager.AllMisions.Count; i++)
                    if (DataManager.AllMisions != null)
                        this.GenericList.Add(DataManager.AllMisions[i]);
                break;

            case ElementListType.Node_Core:
                this.GenericList.Clear();
                for (int i = 0; i < DataManager.AllCores.Count; i++)
                    if (DataManager.AllCores != null)
                        this.GenericList.Add(DataManager.AllCores[i]);
                break;

            case ElementListType.Node_Upgrade:
                this.GenericList.Clear();
                for (int i = 0; i < DataManager.AllAssemblyLines.Count; i++)
                    if (DataManager.AllAssemblyLines != null)
                        this.GenericList.Add(DataManager.AllAssemblyLines[i]);
                break;

            case ElementListType.RawMaterial:
                this.GenericList.Clear();
                for (int i = 0; i < DataManager.AllExtractors.Count; i++)
                    if (DataManager.AllExtractors != null)
                        this.GenericList.Add(DataManager.AllExtractors[i]);
                break;

            case ElementListType.Robots:
                this.GenericList.Clear();
                for (int i = 0; i < DataManager.AllRobots.Count; i++)
                    if (DataManager.AllRobots != null)
                        this.GenericList.Add(DataManager.AllRobots[i]);
                break;

        }
    }

}
