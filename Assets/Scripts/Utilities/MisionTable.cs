using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisionTable : MonoBehaviour
{

    private Mision[] misionsTable;
    public Mision[] Misions { get { return misionsTable; } set { misionsTable = value; } }

    public GameObject MisionPanelTemplate;

    void Start()
    {
        misionsTable = GameState.Instance.GameData.Misions;
        for(int i = 0; i < misionsTable.Length; i++)
        {
            GameObject mision = Instantiate(MisionPanelTemplate) as GameObject;
            mision.SetActive(true);

            mision.GetComponent<MisionTemplate>().misionName.text = GameState.Instance.GameData.Misions[i].Id;

            mision.transform.SetParent(MisionPanelTemplate.transform.parent, false);
        }
    }


}
