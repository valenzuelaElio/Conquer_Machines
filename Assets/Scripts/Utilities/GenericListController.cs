using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenericListController : MonoBehaviour {

    public Button Robots;
    public Button Nodes;
    public Button RawMaterials;

    public static int selected;

    private GenericListLoader list;

	void Start () {
        list = GetComponent<GenericListLoader>();

        Robots.onClick.AddListener(UpdateListToRobots);
        Nodes.onClick.AddListener(UpdateListToNodes);
        RawMaterials.onClick.AddListener(UpdateListRawMaterials);
	}
	
    public void UpdateListToRobots()
    {
        list.ItemTemplate.GetComponent<TemplateType>().Type = TemplateType.TemplateTypeEx.Robot;
        list.elementListType = GenericListLoader.ElementListType.Robots;
        list.UpdateList();
        selected = 0;
    }

    public void UpdateListToNodes()
    {
        list.ItemTemplate.GetComponent<TemplateType>().Type = TemplateType.TemplateTypeEx.Node;
        list.elementListType = GenericListLoader.ElementListType.Nodes;
        list.UpdateList();
        selected = 1;
    }

    public void UpdateListRawMaterials()
    {
        list.ItemTemplate.GetComponent<TemplateType>().Type = TemplateType.TemplateTypeEx.RawMaterial;
        list.elementListType = GenericListLoader.ElementListType.RawMaterial;
        list.UpdateList();
        selected = 2;

    }

}
