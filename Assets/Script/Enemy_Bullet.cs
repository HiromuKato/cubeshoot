using UnityEngine;
using System.Collections;

public class Enemy_Bullet : MonoBehaviour {
	
	private GameObject player; 
	
	private Vector3 move = new Vector3(0,1,0);
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= move * Time.deltaTime*5;
		if(transform.position.y < -2){
			Destroy(gameObject);
		}		
	}	
}
