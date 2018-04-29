using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCollisionDection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D Col){
		if (Col.tag == "Map") {
			Col.tag = "RunMap";
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "RunMap") {
			Destroy (col.gameObject);
		}
	}

}
