using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float force_move = 50;
	private Rigidbody2D playerRig2D;
	public float JumpVelocity = 10;    //玩家跳躍速度
	private Animator PlayerAnim;
	private Transform playerTran;
	private bool IsGround = false;
	private bool IsWall = false;
	private Transform WallTran;       //紀錄牆壁位置
	private bool isSlide = false;     //是否要滑行
	// Use this for initialization
	void Start () {
		playerRig2D = GetComponent<Rigidbody2D> ();
		PlayerAnim = GetComponent<Animator> ();
		playerTran = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		Vector2 velocity = playerRig2D.velocity;
		if (isSlide == false) {
			if (h > 0.05f) {
				playerRig2D.AddForce (Vector2.right * force_move);
				playerTran.localScale = new Vector3 (1, 1, 1);     //讓玩家朝向右方
			} else if (h < -0.05f) {
				playerRig2D.AddForce (Vector2.left * force_move);
				playerTran.localScale = new Vector3 (-1, 1, 1);    //讓玩家朝向左方
			}

			PlayerAnim.SetFloat ("horizontal", Mathf.Abs (h));
			if (IsGround && Input.GetKeyDown (KeyCode.Space)) {
				velocity.y = JumpVelocity;
				playerRig2D.velocity = velocity;
				if (IsWall == true) {
					playerRig2D.gravityScale = 5;
				}
			}
		} else {
		//當正在滑行的時候
			if (Input.GetKeyDown (KeyCode.Space)) {
				velocity.y = JumpVelocity;
				playerRig2D.velocity = velocity;
			}
		
		}
		PlayerAnim.SetFloat ("vertical", playerRig2D.velocity.y);
		if (IsWall == false || IsGround == true)
			isSlide = false;
	}
	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Ground") {
			IsGround = true;
		}
		if (col.collider.tag == "Wall") {
			IsWall = true;
			playerRig2D.velocity = Vector2.zero;
			playerRig2D.gravityScale = 5;
			WallTran = col.collider.transform;
		}
		PlayerAnim.SetBool ("isGround", IsGround);
		PlayerAnim.SetBool ("isWall", IsWall);
	}
	public void OnCollisionExit2D(Collision2D col){
		if (col.collider.tag == "Ground") {
			IsGround = false;
		}
		if (col.collider.tag == "Wall") {
			IsWall = false;
			playerRig2D.gravityScale = 20;
		}
		PlayerAnim.SetBool ("isGround", IsGround);
		PlayerAnim.SetBool ("isWall", IsWall);
	}
	public void ChangeDir(){
		isSlide = true;
		if (WallTran.position.x < transform.position.x) {
			transform.localScale = new Vector3 (1, 1, 1);
		} else {
			transform.localScale = new Vector3 (-1, 1, 1);
		}
			
	}
}
