using UnityEngine;
using System.Collections;

public class SceneGet : MonoBehaviour {
	Vector3 PointingPosition;
	bool SquareSwitch;
	bool TranslateSwitch;
	int GoToScene;

	// Use this for initialization
	void Start () {
		TranslateSwitch = true;
		SquareSwitch = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (TranslateSwitch) {
						if (Input.GetButtonDown ("Fire1")) {
								if (IfClickInSquare () || SquareSwitch) {
										PointingPosition.y = 0.3f;
										PointingPosition.z = 0;
										transform.position = PointingPosition;
										SquareSwitch = true;
										TranslateSwitch = false ;
										GoToThePoint();
								}
						} else {
								SquareSwitch = false;
								//GoToThePoint ();
						}
				} else {
			Debug.Log("Change Scene");
			switch(GoToScene){
			case 1:Debug.Log("GoToLevel1");Application.LoadLevel("Level1");break;
			case 2:Debug.Log("GoToLevel2");Application.LoadLevel("Level2");break;
			case 3:Debug.Log("GoToLevel3");Application.LoadLevel("Level3");break;			
			}
				}
	}



	bool IfClickInSquare(){
		PointingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (PointingPosition.x < 2 && PointingPosition.x > -2 && PointingPosition.y < 1 && PointingPosition.y > -1)
						return true;
				else
						return false;

	}
	void GoToThePoint(){ //映射位置至三个点
		Vector3 Temp = transform.position;
		if (Temp.x < -1.0f) {
						Temp.x = -2.0f;
						GoToScene = 1;
				} else {
						if (Temp.x > 1.0f) {
								Temp.x = 2.0f;
								GoToScene = 3;
						} else {
								GoToScene = 2;
								Temp.x = 0.0f;
						}
				}
		transform.position = Temp;
	}



}
