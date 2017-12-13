using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mision : MonoBehaviour, ITemplate {

    Button MyButton;
    Image MyImage;
    Color originalColor;
    public Text Completed;

    public DataMision MyMision { get; set; }
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
        return MyMision.mision_Id;
    }
    public void ShowData()
    {
        misionName.text = "" + MyMision.mision_Name;
    }

    public void Start()
    {
        MyButton = GetComponent<Button>();
        MyButton.onClick.AddListener(Selected);

        MyImage = GetComponent<Image>();
        this.originalColor = MyImage.color;

        this.Completed.gameObject.SetActive(this.MyMision.isCompleted);

    }

    void Update()
    {
        if (this.MyMision.isCompleted == true)
        {
            this.Completed.gameObject.SetActive(true);
        }

        if (Game.GameInstance.currentSelectedMision == null)
        {
            this.MyImage.color = Color.blue * 0.5f;
            return;
        }

        if (Game.GameInstance.currentSelectedMision.mision_Id == this.MyMision.mision_Id)
        {
            this.MyImage.color = this.originalColor;
        }
        else
        {
            this.MyImage.color = Color.blue * 0.5f;

        }
    }

    public void Selected()
    {
        Game.GameInstance.currentSelectedMision = this.MyMision;
    }
}
