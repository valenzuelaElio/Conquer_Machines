using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveUp : MonoBehaviour {

    public GameObject GiveUpPanel;

    private Button MyButton;
    private bool isActive = false;

    void Start()
    {
        this.MyButton = GetComponent<Button>();
        this.MyButton.onClick.AddListener(ShowSceneInfo);

        this.GiveUpPanel.SetActive(isActive);
    }

    public void ShowSceneInfo()
    {
        this.GiveUpPanel.SetActive(!isActive);
        this.isActive = !isActive;
    }
}
