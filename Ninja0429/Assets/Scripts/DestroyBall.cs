using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour {

	private float DestroyTime = 3;
	private float Timer = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Timer += Time.deltaTime;
		if (Timer > DestroyTime) {
			Destroy (gameObject);
		}
	}
	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag != "Ball") {
			Destroy (gameObject);
		}
	}
}
