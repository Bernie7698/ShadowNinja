using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject[] map;
	private int  MapDistance;    //下次地圖增加的距離
	// Use this for initialization
	void Start () {
		MapDistance = 0;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject FindMap = GameObject.FindGameObjectWithTag ("Map");
		if (FindMap == null) {
			MapDistance += 50;
			int RandomMap = Random.Range (0, map.Length);
			Instantiate (map[RandomMap],new Vector3(MapDistance,0,0),Quaternion.identity);
		}
	}
}
