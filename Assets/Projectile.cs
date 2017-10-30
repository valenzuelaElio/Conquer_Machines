using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private int Damage = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GoRight();
	}

    private void GoRight()
    {
        transform.Translate(Vector2.right * 10 * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Robot")
        {
            collision.collider.gameObject.GetComponent<RobotGo>().GetDamaged(this.Damage);
            Destroy(gameObject);
        }
    }

}
