using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public KeyCode keyCode_Left;
	public KeyCode keyCode_Right;
	public KeyCode keyCode_Bullet;
	public GameObject player_Bullet;
	
	public GameObject explode;
	public GameObject hitParticle;
	
	public AudioClip audioClip;
	AudioSource audioSource;
	public AudioClip audioClip2;
	AudioSource audioSource2;
	
	public int life = 100;
	
	private GameObject life_gui;
	private float reduce;
	private float life_pos;
	
	private Vector3 p_pos;
	private Vector3 move = new Vector3(1,0,0);
	//private bool playerBulletFlag = true;
	
	// Use this for initialization
	void Start () {
		life_gui = GameObject.Find("Life");
		reduce = life_gui.transform.localScale.x / 100;
		life_pos = life_gui.transform.position.x;
		
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = audioClip;	
		audioSource2 = gameObject.GetComponent<AudioSource>();
		audioSource2.clip = audioClip2;
		
		p_pos = transform.position;
		//Debug.Log(p_pos);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(keyCode_Left)){	
			transform.position -= move * Time.deltaTime*5;
			if(transform.position.x < -6.3f){
				transform.position = new Vector3(-6.3f,transform.position.y,0);
			}
		}
	
		if (Input.GetKey(keyCode_Right)){	
			transform.position += move * Time.deltaTime*5;
			if(transform.position.x > 6.3f){
				transform.position = new Vector3(6.3f,transform.position.y,0);;
			}
		}
		
		if (Input.GetKey(keyCode_Bullet)){
			 audioSource2.Play();
			//Debug.Log(playerBulletFlag);
			if(!GameObject.Find("Player_Bullet(Clone)")){
				//playerBulletFlag = false;
				Instantiate(player_Bullet, transform.position, Quaternion.identity);
			}else{
				//playerBulletFlag = false;
			}
		}
		
		if(transform.position.y < -1.5f){
			Destroy(gameObject);
			//Debug.Log("END!");
		};
		
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "ebullet"){
			Destroy(other.gameObject);
			if(!GameObject.Find("HitParticle(Clone)")){
				Instantiate(hitParticle, transform.position+new Vector3(0,0.5f,0), Quaternion.identity);
			}else{
				Destroy(GameObject.Find("HitParticle(Clone)"));
			}
			life--;
			life_gui.transform.localScale = life_gui.transform.localScale - new Vector3(reduce,0,0);
			life_gui.transform.position = life_gui.transform.position - new Vector3(reduce/2,0,0);			
			if(life_gui.transform.localScale.x <= 0){
				life_gui.transform.localScale = new Vector3(0,0,0);
			}
			
			//Debug.Log(life);
			audioSource.PlayOneShot( audioClip );
			if(life == 0){
				GameObject.Find ("GameController").SendMessage("playSE");
				Instantiate(explode, transform.position, Quaternion.identity);
				Destroy(gameObject);
				GameObject.Find("GameController").SendMessage("StageGameover");
			}
		}		
	}
	
}
