using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreNode : MonoBehaviour {

    Button MyButton;
    public DataNode MyNode;
    public Text type;
    Image MyImage;

    void Start()
    {
        MyButton = GetComponent<Button>();
        MyButton.onClick.AddListener(Selected);

        type.text = MyNode.node_id;
    }

    void Selected()
    {
        Game.GameInstance.currentSelectedCoreNode = (Core)this.MyNode;
        if (Game.GameInstance.currentSelectedCoreNode != null)
        {
            Debug.Log(Game.GameInstance.currentSelectedCoreNode.node_id + " Seleccionado");
        }
    }

}
