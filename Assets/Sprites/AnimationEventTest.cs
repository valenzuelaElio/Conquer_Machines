using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventTest : MonoBehaviour {

	public ParticleSystem particle1;
	public ParticleSystem particle2;
	public ParticleSystem particle3;
	public ParticleSystem particle4;
	public ParticleSystem particle5;
	public GameObject obj1;
	public GameObject obj2;

	// Use this for initialization
	void Start () {
		obj1.SetActive(true);
		obj2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void animationTest1(){
		Debug.Log("Hola Mundo eventx");
		particle1.Play();
		particle2.Play();
		particle3.Play();
		particle4.Play();
		particle5.Play();

	}

	public void endCloseDoor(){
		gameObject.GetComponents<AudioSource>()[0].Play();
		if(obj1.activeSelf){
			obj1.SetActive(false);
			obj2.SetActive(true);
		}else{
			obj1.SetActive(true);
			obj2.SetActive(false);
		}
	}

	public void starCloseDoor(){
		gameObject.GetComponents<AudioSource>()[1].Play();
	}

	public void turnOff(){
		gameObject.transform.parent.gameObject.SetActive(false);
	}

}
