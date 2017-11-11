using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisionTemplate : MonoBehaviour, ITemplate {

    public Mision MyMision { get; set; }
    public Text misionName;

    public int Cant()
    {
        return 1;
    }

    public string Description()
    {
        return MyMision.Description;
    }

    public string Id()
    {
        return MyMision.Id;
    }

    public void ShowData()
    {
        misionName.text = "" + MyMision.MisionName;
    }
}
