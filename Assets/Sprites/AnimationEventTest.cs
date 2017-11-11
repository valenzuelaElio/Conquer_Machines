using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventTest : MonoBehaviour {

	public ParticleSystem particle1;
	public ParticleSystem particle2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void animationTest1(){
		Debug.Log("Hola Mundo eventx");
		particle1.Play();
		particle2.Play();
	}
}
