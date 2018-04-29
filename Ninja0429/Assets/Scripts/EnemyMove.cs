using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
	private Transform player;     //玩家位置
	public float attackDistance = 25;
	private Animator anim;
	public float speed = 5;
	private bool IsTouch = false;   //子彈是否碰到敵人

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (player.position, transform.position);
		if (distance < attackDistance) {
			//進行攻擊
			anim.SetBool ("Run", true);
			if (player.position.x < transform.position.x) {
				//敵人在左邊
				transform.localScale = new Vector3 (-1, 1, 1);
			} else {
				//敵人在右邊
				transform.localScale = new Vector3 (1, 1, 1);
			}
			Vector3 dir = player.position - transform.position;
			//讓敵人慢慢靠近玩家
			if (IsTouch == false) {
				transform.position = dir.normalized * speed * Time.deltaTime + transform.position;
			}
		} else {
			anim.SetBool ("Run", false);
		}
	}
	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Ball" && IsTouch == false) {
			IsTouch = true;
			anim.SetTrigger ("Death");
		}
	}
	//當敵人死亡後播完身體顏色漸變動畫後要消失不見
	public void Death(){
		Destroy (gameObject);
	}
}