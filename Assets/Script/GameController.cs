using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public GameObject enemy;
	
	public GUITexture texClear;
	public GUITexture texGameover;
	
	private bool isStageEnd;
	
	public AudioClip audioClip;
	AudioSource audioSource;
	
	private int rand_x, rand_y;
	private Vector3 ePos;
	GameObject[,] obj = new GameObject[10,5];
	
	private int hit_count=0;
	
	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = audioClip;
		
		texClear.enabled = false;
		texGameover.enabled = false;
		isStageEnd = false;
		
		ePos = transform.position+ new Vector3(8,2,0);
		for(int y = 0; y<5; y++){
			ePos = ePos + new Vector3(-10,-1.0f,0);

			for(int x = 0; x<10; x++){
				ePos = ePos + new Vector3(1.0f,0,0);
				obj[x,y] = (GameObject)Instantiate(enemy, ePos, Quaternion.identity);
				if(y==0){obj[x,y].renderer.material.color = Color.blue;}
				else if(y==1){obj[x,y].renderer.material.color = Color.cyan;}
				else if(y==2){obj[x,y].renderer.material.color = Color.green;}
				else if(y==3){obj[x,y].renderer.material.color = Color.yellow;}
				else if(y==4){obj[x,y].renderer.material.color = Color.red;}
			
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(isStageEnd && (Input.GetKey(KeyCode.Mouse0))){
			//Application.LoadLevel ("Menu");
			Application.LoadLevel("shooting");
		}
		rand_x = Random.Range(0,10);
		rand_y = Random.Range(0,5);
		if(obj[rand_x,rand_y]){
		//GameObject.Find("Enemy(Clone)").SendMessage("enemyShoot");
			obj[rand_x,rand_y].SendMessage("enemyShoot");
		}
	}
	
	void CountHit(){
		hit_count++;
		//Debug.Log(hit_count);
		if(hit_count == 50){
			StageClear();
		}
	}
	
	void StageClear(){
		texClear.enabled = true;
		isStageEnd = true;
	}
	
	void StageGameover(){
		texGameover.enabled = true;
		isStageEnd = true;
	}
	
	
	void playSE(){
		audioSource.Play();
		//audioSource3.PlayOneShot( audioClip3 );
	}	
}
