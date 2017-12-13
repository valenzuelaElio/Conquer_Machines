using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSceneInfoPanel : MonoBehaviour {

    public GameObject SceneInfo;

    private Button MyButton;
    private bool isActive = false;

	void Start () {
        this.MyButton = GetComponent<Button>();
        this.MyButton.onClick.AddListener(ShowSceneInfo);

        this.SceneInfo.SetActive(isActive);
	}

    public void ShowSceneInfo()
    {
        this.SceneInfo.SetActive(!isActive);
        this.isActive = !isActive;
    }
	
}
