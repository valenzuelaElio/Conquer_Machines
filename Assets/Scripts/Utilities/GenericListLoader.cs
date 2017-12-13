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
        Nodes,
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
                    break;

                case ElementListType.Extractors:
                    obj.GetComponent<Extractor>().MyExtractor = (DataExtractor)GenericList[i];
                    obj.GetComponent<Extractor>().ShowData();
                    break;

                    //Listo;
                case ElementListType.Misions:
                    obj.GetComponent<Mision>().MyMision = (DataMision)GenericList[i];
                    obj.GetComponent<Mision>().ShowData();
                    break;

                case ElementListType.Robots:
                    obj.GetComponent<Robot>().MyRobot = (DataRobot)GenericList[i];
                    obj.GetComponent<Robot>().ShowData();
                    break;

                case ElementListType.Node_Core:
                    obj.GetComponent<Node>().MyNode = (Core)GenericList[i];
                    obj.GetComponent<Node>().onList = true;
                    break;

                case ElementListType.Node_Upgrade:
                    obj.GetComponent<Node>().MyNode = (Upgrade)GenericList[i];
                    obj.GetComponent<Node>().onList = true;
                    break;

                case ElementListType.Nodes:
                    obj.GetComponent<Node>().MyNode = (DataNode)GenericList[i];

                    break;

                case ElementListType.RawMaterial:
                    obj.GetComponent<RawMaterial>().MyRawMaterial = (DataRawMaterial)GenericList[i];
                    break;
            }
            obj.transform.SetParent(ItemTemplate.transform.parent, false);
            //obj.transform.SetParent(this.transform, false);
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
                for (int i = 0; i < Game.GameInstance.PlayerInstance.Missions_completed.Count; i++)
                    if (Game.GameInstance.PlayerInstance.Missions_completed != null)
                        this.GenericList.Add(Game.GameInstance.PlayerInstance.Playable_Mission[DataManager.AllMisions[i].mision_Id]);
                break;

            case ElementListType.Node_Core:
                this.GenericList.Clear();
                for (int i = 0; i < DataManager.AllNodes.Count; i++)
                    if (DataManager.AllNodes != null)
                        if(DataManager.AllNodes[i].GetType().Equals(typeof(Core)))
                            this.GenericList.Add(DataManager.AllNodes[i]);
                break;

            case ElementListType.Node_Upgrade:
                this.GenericList.Clear();
                for (int i = 0; i < DataManager.AllNodes.Count; i++)
                    if (DataManager.AllNodes != null)
                        if(DataManager.AllNodes[i].GetType().Equals(typeof(Upgrade)))
                            this.GenericList.Add(DataManager.AllNodes[i]);
                break;

            case ElementListType.RawMaterial:
                this.GenericList.Clear();
                for (int i = 0; i < DataManager.AllRawMaterials.Count; i++)
                    if (DataManager.AllRawMaterials != null)
                        this.GenericList.Add(DataManager.AllRawMaterials[i]);
                break;

            case ElementListType.Robots:
                this.GenericList.Clear();
                for (int i = 0; i < DataManager.AllRobots.Count; i++)
                    if (Game.GameInstance.PlayerInstance.Player_Robots.ContainsKey(DataManager.AllRobots[i].robot_id))
                    {
                        this.GenericList.Add(Game.GameInstance.PlayerInstance.Player_Robots[DataManager.AllRobots[i].robot_id]);
                    }

                    //if (DataManager.AllRobots != null)
                        //this.GenericList.Add(DataManager.AllRobots[i]);
                break;

            case ElementListType.Nodes:
                this.GenericList.Clear();
                for (int i = 0; i < DataManager.AllNodes.Count; i++)
                    if (DataManager.AllNodes != null)
                        this.GenericList.Add(DataManager.AllNodes[i]);

                break;

        }
    }

    public void UpdateList()
    {
        RectTransform t = (RectTransform)this.ItemTemplate.GetComponent<RectTransform>().parent;
        //Debug.Log("Child size = " + t.childCount);
        for (int i = 0; i < this.GenericList.Count; i++)
        {
            if (t.childCount > 1)
            {
                Destroy(t.GetChild(i + 1).gameObject);
            }
        }

        LoadList();

        for (int i = 0; i < GenericList.Count; i++)
        {
            GameObject obj = Instantiate(ItemTemplate) as GameObject;
            obj.SetActive(true);

            switch (elementListType)
            {
                case ElementListType.AssemblyLine:
                    obj.GetComponent<AssemblyLine>().MyAssemblyLine = (DataAssemblyLine)GenericList[i];
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
                    if (ScenesManager.LastLoadedScene == "CM_2_RobotInventory")
                    {
                        obj.GetComponent<Robot>().enabled = true;
                        obj.GetComponent<Node>().enabled = false;
                        obj.GetComponent<RawMaterial>().enabled = false;
                        obj.GetComponent<TemplateType>().Type = TemplateType.TemplateTypeEx.Robot;
                    }

                    obj.GetComponent<Robot>().MyRobot = (DataRobot)GenericList[i];
                    obj.GetComponent<Robot>().ShowData();
                    break;

                case ElementListType.Node_Core:
                    obj.GetComponent<Node>().MyNode = GenericList[i] as Core;
                    obj.GetComponent<Node>().onList = true;
                    break;

                case ElementListType.Node_Upgrade:
                    obj.GetComponent<Node>().MyNode = GenericList[i] as Upgrade;
                    obj.GetComponent<Node>().onList = true;
                    break;

                case ElementListType.Nodes:
                    obj.GetComponent<Robot>().enabled = false;
                    obj.GetComponent<Node>().enabled = true;
                    obj.GetComponent<RawMaterial>().enabled = false;

                    obj.GetComponent<TemplateType>().Type = TemplateType.TemplateTypeEx.Node;
                    obj.GetComponent<Node>().MyNode = (DataNode)GenericList[i];

                    break;

                case ElementListType.RawMaterial:
                    obj.GetComponent<Robot>().enabled = false;
                    obj.GetComponent<Node>().enabled = false;
                    obj.GetComponent<RawMaterial>().enabled = true;

                    obj.GetComponent<TemplateType>().Type = TemplateType.TemplateTypeEx.RawMaterial;
                    obj.GetComponent<RawMaterial>().MyRawMaterial = (DataRawMaterial)GenericList[i];
                    break;
            }
            obj.transform.SetParent(ItemTemplate.transform.parent, false);
        }
    }

}
