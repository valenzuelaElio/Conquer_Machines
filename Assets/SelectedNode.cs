using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectedNode : MonoBehaviour {

    private Image MyImage;

    void Start () {
        this.MyImage = GetComponent<Image>();
        //currentAL = Game.GameInstance.currentSelectedAssemblyLine;
        this.Show(false);
    }

    private void Show(bool showMe)
    {
        this.MyImage.enabled = showMe;
        //MyImage.color = new Color(MyImage.color.r, MyImage.color.g, MyImage.color.b, 0);
        for (int i = 0; i < this.transform.childCount; i++)
            this.transform.GetChild(i).gameObject.SetActive(showMe);
    }

    void Update () {

        if (Game.GameInstance.currentSelectedNode != null)
        {
            //Debug.Log("Mostrar Panel De Creacion");
            this.Show(true);
        }
        else
        {
            //Debug.Log("Cerrar Panel De Creacion");
            this.Show(false);
        }

	}

    public void FinishCreation()
    {
        if (Game.GameInstance.currentSelectedCoreNode == null)
        {
            Debug.Log("Core Nulo");
        }

        if (Game.GameInstance.currentSelectedAssemblyLine == null)
        {
            Debug.Log("Assembly Line Nulo");
        }

        if (Game.GameInstance.currentSelectedCoreNode != null
            && Game.GameInstance.currentSelectedAssemblyLine != null)
        {
            Game.GameInstance.currentSelectedAssemblyLine.coreNode = Game.GameInstance.currentSelectedCoreNode;
            Debug.Log("Nodo Acoplado");
            Game.GameInstance.currentSelectedAssemblyLine = null;
            Game.GameInstance.currentSelectedNode = null;
            //Show(false);

        }
    }

}
