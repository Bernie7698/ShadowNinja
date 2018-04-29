using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour {

	public GameObject player;       //紀錄玩家資訊
	public GameObject enemy;        //敵人預製物
	public float attackDistance = 30;   //設定攻擊距離
	public float timer;
	public float CreateTime = 3.0f;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		float distance = Vector3.Distance (player.transform.position, 
			                                      transform.position);
		if (distance < attackDistance && timer > CreateTime) {
			Instantiate (enemy, transform.position, Quaternion.identity);
			timer = 0;
		}
	}
}
