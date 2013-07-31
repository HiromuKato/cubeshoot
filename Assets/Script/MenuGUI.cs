using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {
	
	public AudioClip audioClip;
	AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = audioClip;
	}
	
	
	void OnGUI() {
		// Startボタン表示
		if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 110, 100, 50), "Start")) {
			// クリックされたらStage01シーンをロードする
			//audioSource.Play();
			//GameObject.Find ("GameController").SendMessage("playSE");
			//audioSource.PlayOneShot( audioClip );
			Application.LoadLevel("shooting");
		}
	}
}
