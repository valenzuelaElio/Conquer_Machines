using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInEditor : MonoBehaviour {

#if UNITY_EDITOR

    void Awake()
    {
        if (GameState.Instance == null)
        {
            string path = "Assets/DataFolder/test001Xml.xml";
            DataManager.CreateDataMapExample(path);
            GameState.CreateGame(DataManager.DataMaster);
        }
        Destroy(this);
    }
#endif
}
