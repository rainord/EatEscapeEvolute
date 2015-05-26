using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {
	public static int AppleBoxX;
	public static int AppleBoxY;
	Vector3 ApplePosition;
	bool IfChangePosition;
	// Use this for initialization
	void Start () {
		GetRandomBox ();
		transform.position = ApplePosition;
		IfChangePosition = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(IfChangePosition){
			GetRandomBox ();
			transform.position = ApplePosition;
			IfChangePosition = false;

		}


	}
	void GetRandomBox(){
		AppleBoxX = (int)Random.Range(-10,10); 
		AppleBoxY = (int)Random.Range(-10,10); 
		ApplePosition.x = (float)AppleBoxX - 0.5f;
		ApplePosition.y = (float)AppleBoxY - 0.5f;
		ApplePosition.z = -0.5f;
	}
	void ApplePositionChangeSwitchTrue(){
		IfChangePosition = true;
	}

}
