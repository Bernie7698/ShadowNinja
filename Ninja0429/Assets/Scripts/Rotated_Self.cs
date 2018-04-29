using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotated_Self : MonoBehaviour {

	public float speed = -1000;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * speed * Time.deltaTime);
	}
}
