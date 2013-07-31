using UnityEngine;
using System.Collections;

public class MouseCtrl : MonoBehaviour {
	private Vector3 tmpInput;
	private Vector3 tmpPos;

	//private Vector3 screenPoint;
    //private Vector3 offset;

	
    void Start ()
    {
        Random.seed = (int)Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R))
        {
            gameObject.renderer.material.color = Color.red;
        }

		
		// マウス座標を取得
		tmpInput = Input.mousePosition;
		
		// 座標変換のためカメラのZ座標を引く
		tmpInput.z = -Camera.mainCamera.transform.position.z;
		
		//スクリーン座標をゲーム上の座標に変換
		tmpPos = Camera.mainCamera.ScreenToWorldPoint(tmpInput);		
		
		//バーを動かす
		transform.position = tmpPos;		
		Debug.Log(transform.position.x);

	}
/*
    void OnMouseDrag() {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
    }
*/
	 void OnMouseDown ()
    {
		Debug.Log("TEST");
/*		
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
*/
        float r = Random.Range(0f,1f);
        float g = Random.Range(0f,1f);
        float b = Random.Range(0f,1f);
        Color randomColour = new Color(r,g,b,1f);
        
        renderer.material.color = randomColour;
    }

}