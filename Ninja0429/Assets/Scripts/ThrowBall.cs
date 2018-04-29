using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour {

	public GameObject blot;    //放置武器的預置物
	public float speed = 1500;  //子彈速度
	private Transform player;   //玩家位置
	private GameObject button;  //放置產生的光球
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			button = Instantiate (blot, transform.position, Quaternion.identity);
			if (player.transform.position.x < transform.position.x) {
				button.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * speed);
			} else {
				button.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * speed);
			}
		}	
	}
}
