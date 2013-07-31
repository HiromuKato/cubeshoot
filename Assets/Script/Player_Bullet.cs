using UnityEngine;
using System.Collections;

public class Player_Bullet : MonoBehaviour {
	
	private Vector3 move = new Vector3(0,1,0);
	private bool p_bullet_flag = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += move * Time.deltaTime*10;
		if(transform.position.y > 10){
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter(Collider other){
		/*
		if(other.tag == "enemy"){
			Destroy(gameObject);
		}
		*/
	}
}
