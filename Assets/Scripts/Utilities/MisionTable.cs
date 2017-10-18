using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisionTable : MonoBehaviour
{

    private Mision[] misionsTable;
    public Mision[] Misions { get { return misionsTable; } set { misionsTable = value; } }

    public GameObject MisionPanelTemplate;
    private Text MisionText;

    // Use this for initialization
    void Start()
    {
        
        misionsTable = GameState.Instance.GameData.Misions;
        /*
        for (int i = 0; i < misionsTable.Length; i++)
        {
            MisionText.text = "Mision: " + misionsTable[i].Id + "\n";
            MisionText.text = MisionText.text + "Requerimientos: " + misionsTable[i].Requirements + "\n";
            MisionText.text = MisionText.text + "Dificultad: " + misionsTable[i].Dificulty + "\n";
            MisionText.text = MisionText.text + "Descripcion: " + misionsTable[i].Description + "\n";

            Vector3 newPos = new Vector3(transform.position.x, transform.position.y + 180 * i, transform.position.z);
            GameObject temp = Instantiate(MisionGO, newPos , Quaternion.identity);
            temp.transform.parent = GameObject.Find("MisionsPanel").transform;
        }
        */

        for(int i = 0; i < misionsTable.Length; i++)
        {
            GameObject mision = Instantiate(MisionPanelTemplate) as GameObject;
            mision.SetActive(true);

            mision.GetComponent<MisionTemplate>().misionName.text = GameState.Instance.GameData.Misions[i].Id;

            mision.transform.SetParent(MisionPanelTemplate.transform.parent, false);
        }


    }


}
