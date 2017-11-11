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
        
    }
    public ElementListType elementListType;
    public GameObject ItemTemplate;//Esto es lo que deveria instanciarse en la pantalla.
    public object[] GenericList;

    void Start () {
        //Con esto se inicializa la informacion;
        SelectType();
        //GenericList = Game.Instance.GameData.Extractors;
        Debug.Log("Size = " + GenericList.Length);
        for (int i = 0; i < GenericList.Length; i++)
        {
            GameObject obj = Instantiate(ItemTemplate) as GameObject;
            obj.SetActive(true);

            //ItemTemplate.GetComponent<GenericTemplate>();
            //obj.GetComponent<>().id.text = GenericList[i].Id;
            switch (elementListType)
            {
                case ElementListType.AssemblyLine:
                    obj.GetComponent<AssemlbyLineTemplate>();
                    break;

                case ElementListType.Extractors:
                    obj.GetComponent<ExtractorTemplate>().MyExtractor = (Extractor)GenericList[i];
                    obj.GetComponent<ExtractorTemplate>().ShowData();
                    break;

                case ElementListType.Misions:
                    obj.GetComponent<MisionTemplate>().MyMision = (Mision)GenericList[i];
                    obj.GetComponent<MisionTemplate>().ShowData();
                    break;

                case ElementListType.Robots:
                    obj.GetComponent<RobotTemplate>().MyRobot = (Robot)GenericList[i];
                    obj.GetComponent<RobotTemplate>().ShowData();
                    break;
            }
            obj.transform.SetParent(ItemTemplate.transform.parent, false);
        }
    }

    void SelectType()
    {
        switch (elementListType)
        {
            case ElementListType.AssemblyLine: GenericList = Game.Instance.GameData.AssemblyLines; break;
            case ElementListType.Extractors: GenericList = Game.Instance.GameData.Extractors; break;
            case ElementListType.Misions: GenericList = Game.Instance.GameData.Misions; break;
            case ElementListType.Robots: GenericList = Game.Instance.GameData.Robots; break;
        }
    }

}
