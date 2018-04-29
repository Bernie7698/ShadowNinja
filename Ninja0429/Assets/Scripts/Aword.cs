using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aword : MonoBehaviour {

	public float speed = -100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * speed * Time.deltaTime);
	}
	public void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
		//加分處
			AudioManager._instance.PlayAwordSound();
			Destroy (gameObject);
		}
	}
}
