using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollByButtons : MonoBehaviour {

    public Button Up;
    public Button Down;

    bool scrollUp;
    bool scrollDown;

    RectTransform MyContentSR;

	void Start () {
        Up.onClick.AddListener(ScrollUp);
        Down.onClick.AddListener(ScrollDown);

        this.MyContentSR = GetComponent<RectTransform>();
	}

    private void Update()
    {
        if (scrollDown == true)
        {
            //this.ScrollDown();
            float toReach = this.MyContentSR.anchoredPosition.y + 150;
            Vector2 target = new Vector2(0f, toReach);

            //for (int i = (int)this.MyContentSR.anchoredPosition.y; i < toReach; i+=(int)(10 * Time.deltaTime))
            while (Vector2.Distance(this.MyContentSR.anchoredPosition, target) >= 0.05f)
            {
                //Debug.Log("Position " + this.MyContentSR.anchoredPosition);
                //this.MyContentSR.anchoredPosition = new Vector3(this.MyContentSR.anchoredPosition.x, i);
                //this.scrollDown = false;

                this.MyContentSR.anchoredPosition = Vector2.Lerp(this.MyContentSR.anchoredPosition, target, 1f * Time.deltaTime);
                Debug.Log("Position " + this.MyContentSR.anchoredPosition);
                this.scrollDown = false;    
            }
        }

        if (scrollUp == true)
        {
            //this.ScrollDown();
            float toReach = this.MyContentSR.anchoredPosition.y - 150;
            Vector2 target = new Vector2(0f, toReach);

            //for (int i = (int)this.MyContentSR.anchoredPosition.y; i < toReach; i+=(int)(10 * Time.deltaTime))
            while (Vector2.Distance(this.MyContentSR.anchoredPosition, target) >= -0.05f)
            {
                //Debug.Log("Position " + this.MyContentSR.anchoredPosition);
                //this.MyContentSR.anchoredPosition = new Vector3(this.MyContentSR.anchoredPosition.x, i);
                //this.scrollDown = false;

                this.MyContentSR.anchoredPosition = Vector2.Lerp(this.MyContentSR.anchoredPosition, target, 0.1f * Time.deltaTime);
                Debug.Log("Position " + this.MyContentSR.anchoredPosition);
                this.scrollUp = false;
            }
        }

    }

    private void ScrollDown()
    {
        this.scrollDown = true;
    }

    private void ScrollUp()
    {
        this.scrollUp = true;
    }



}
