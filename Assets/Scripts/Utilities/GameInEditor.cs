using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInEditor : MonoBehaviour {

#if UNITY_EDITOR

    void Awake()
    {
        if (Game.Instance == null)
        {
            string path = "Assets/DataFolder/test001Xml.xml";
            DataManager.CreateDataMapExample(path);
            Game.CreateGame(DataManager.DataMaster);
        }
        Destroy(this);
    }
#endif
}
