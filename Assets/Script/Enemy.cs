using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject enemyBullet; 
	public int score = 100;
	
	public GameObject hitParticle;
	
	private GameObject playerBullet; 

	
	private bool moveFlag = false;
	private float moveSpeed = 0.5f;
	
	// Use this for initialization
	void Start () {		
		StartCoroutine("CangeMoveFlag");
	}
	
	// Update is called once per frame
	void Update () {
		playerBullet = GameObject.Find("Player_Bullet(Clone)");
		
		//move
		if(moveFlag){
			transform.position += new Vector3(1,0,0) * Time.deltaTime * moveSpeed;
		}else {	
			transform.position -= new Vector3(1,0,0) * Time.deltaTime * moveSpeed;
		}
		
		//enemyShoot ();
	}
	
	IEnumerator CangeMoveFlag(){
		while(true){
			moveFlag = !moveFlag;
			yield return new WaitForSeconds(4f);
		}
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "pbullet"){			
			Instantiate(hitParticle, transform.position+new Vector3(0,0.5f,0), Quaternion.identity);
			Destroy(gameObject);
			Destroy(playerBullet);
			GameObject.Find ("GameController").SendMessage("playSE");
			GameObject.Find ("GameController").SendMessage("CountHit");
			GameObject.Find ("Score").SendMessage("AddScore", score);
		}
		if(other.tag == "ebullet"){
			//Destroy(playerBullet);
			//GameObject.Find ("Player");
		}
		
	}
	
	void enemyShoot() {
		//if(!GameObject.Find("Enemy_Bullet(Clone)")){
			Instantiate(enemyBullet, transform.position, Quaternion.identity);
		//}else{
			//
		//}
	}
		
}
