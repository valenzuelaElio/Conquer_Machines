using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameRewards : MonoBehaviour {

    private Image MyImage;
    public Text Rewards;
    
    private enum State { ShowRewards, NotShowRewards, Continue}
    private State MyState;

	void Start () {
        this.MyImage = GetComponent<Image>();
        this.Show(false);
        this.MyState = State.NotShowRewards;
	}

    private void Show(bool showMe)
    {
        this.MyImage.enabled = showMe;
        for (int i = 0; i < this.transform.childCount; i++)
            this.transform.GetChild(i).gameObject.SetActive(showMe);
    }

    void Update () {

        switch (this.MyState)
        {
            case State.ShowRewards:
                this.Rewards.text = "Rewards: \r\n - "
                    + Game.GameInstance.currentSelectedMision.cant1 + " " + DataManager.GetRawMaterial(Game.GameInstance.currentSelectedMision.Reward1).RawMaterialName + "\r\n - " +
                    + Game.GameInstance.currentSelectedMision.cant2 + " " + DataManager.GetRawMaterial(Game.GameInstance.currentSelectedMision.Reward2).RawMaterialName + "\r\n - " +
                    + Game.GameInstance.currentSelectedMision.cant3 + " " + DataManager.GetRawMaterial(Game.GameInstance.currentSelectedMision.Reward3).RawMaterialName + "\r\n";
                break;

            case State.Continue:
                Game.GameInstance.currentSelectedMision.isCompleted = true;
                ScenesManager.GoToScene(Game.GameInstance.GameData.ScenesNames[4]);
                break;
        }

        if (EnemyGenerator.ActualState == EnemyGenerator.BattleState.GameOver)
        {
            this.Show(true);
            this.MyState = State.ShowRewards;
        }
        else
        {
            this.Show(false);
        }
    }

    public void GoToMissionsList() {
        this.MyState = State.Continue;

    }

}
