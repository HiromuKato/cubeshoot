using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
	private int score;
	
	void InitScore(){
		this.score = 0;
	}
	
	void AddScore(int score){
		this.score += score;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Score : " + this.score;	
	}
}
