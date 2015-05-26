using UnityEngine;
using System.Collections;

public class Hole2 : MonoBehaviour {

	public static int HoleBoxX;
	public static int HoleBoxY;
	Vector3 HolePosition;
	bool IfChangePosition;
	public static bool IfTranslat;
	
	
	// Use this for initialization
	void Start () {
		//GetRandomBox ();
		//transform.position = HolePosition;
		IfChangePosition = false;
		IfTranslat = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(IfChangePosition){
			GetRandomBox ();
			transform.position = HolePosition;
			IfChangePosition = false;
			IfTranslat = true;
		}
		
		
		
	}
	
	void GetRandomBox(){
		HoleBoxX = (int)Random.Range(-10,-1); 
		HoleBoxY = (int)Random.Range(-10,10); 
		HolePosition.x = (float)HoleBoxX - 0.5f;
		HolePosition.y = (float)HoleBoxY - 0.5f;
		HolePosition.z = -0.5f;
	}
	
	void ApplePositionChangeSwitchTrue(){
		IfChangePosition = true;
	}
	
	void HoleIfTranslateSwitchFalse(){
		IfTranslat = false;
	}
}
