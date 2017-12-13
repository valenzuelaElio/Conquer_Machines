using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDissapear : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.up * 80 * Time.deltaTime);
		
	}
}
