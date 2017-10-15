using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisionTable : MonoBehaviour
{

    private Mision[] misionsTable;
    public Mision[] Misions { get { return misionsTable; } set { misionsTable = value; } }

    public GameObject MisionGO;
    private Text MisionText;

    // Use this for initialization
    void Start()
    {
        MisionText = MisionGO.GetComponent<Text>();
        misionsTable = GameState.Instance.DataManagerInstance.DataMaster.Misions;

        for (int i = 0; i < misionsTable.Length; i++)
        {
            MisionText.text = "Mision: " + misionsTable[i].Id + "\n";
            MisionText.text = MisionText.text + "Requerimientos: " + misionsTable[i].Requirements + "\n";
            MisionText.text = MisionText.text + "Dificultad: " + misionsTable[i].Dificulty + "\n";
            MisionText.text = MisionText.text + "Descripcion: " + misionsTable[i].Description + "\n";

            Vector3 newPos = new Vector3(transform.position.x, transform.position.y - 80 * i, transform.position.z);
            Text t = Instantiate(MisionText, newPos , Quaternion.identity);
            t.transform.parent = GameObject.Find("MisionsPanel").transform;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }


}
