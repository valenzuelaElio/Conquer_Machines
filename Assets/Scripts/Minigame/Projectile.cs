using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float Damage = 10;
    public float Speed = 10; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GoRight();
	}

    private void GoRight()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Robot")
        {
            Destroy(gameObject);
        }
    }

}
