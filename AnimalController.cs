using UnityEngine;
using System.Collections;

public class AnimalController : MonoBehaviour {
	private GameObject PlayerObject;
	private GameObject Animal_1;
	private GameObject Animal_2;
	public GameObject Animal_3;
	public static bool AnimalSwitch=false ;
	public static int PlayerXNum;
	public static int PlayerYNum;
	public bool PlayerSwitch;
	public int NumOfAnimal;
	bool Lose ;
	private static int Round;
	 GameObject [] Animals = new GameObject[10];
	GameObject Hole1;
	public static GameObject Hole11;
	public static GameObject Hole22;
	public static int Hole11BoxX;
	public static int Hole11BoxY;
	public static int Hole22BoxX;
	public static int Hole22BoxY;
	GameObject Hole2;
	GameObject NewAnimals;
	int AnimalsTop;
	int AnimalsKey;
	public static bool HoleDestroy;
	bool HoleInit;



	// 获得几个对象
	void Start () {
		PlayerObject = GameObject.Find ("player");
		Animal_1 = GameObject.Find ("tiger");
		Animal_2 = GameObject.Find ("Snake");
		Animal_3 = GameObject.Find ("tiger_1");
		Hole1 = GameObject.Find ("Hole1");
		Hole2 = GameObject.Find ("Hole2");
		NumOfAnimal = 1;
		Round = 0;
		AnimalsKey = 0;
		AnimalsTop = 0;
		Lose = false;
		HoleDestroy = false;
		HoleInit = false;
		InitHole1();InitHole2();

	}
	
	// Update is called once per frame
	void Update () {
		if(Lose)Application.LoadLevel("Enjoy");



		if (AnimalSwitch) {
			Debug.Log ("AnimalControllerSwitchIsTrue");
			switch(NumOfAnimal){

			case 1:Debug.Log  ("Let Tiger Go");
				Debug.Log("NumOfAnimalIs "+NumOfAnimal);
				NumOfAnimal++;
				AnimalSwitch=false;Animal_1.SendMessage("Move",true);break;
			case 2://Debug.Log("Let Snake Go");
				Debug.Log("NumOfAnimalIs "+NumOfAnimal);
				NumOfAnimal++;
				AnimalSwitch=false;Animal_2.SendMessage("Move",true);break;
			case 3:NumOfAnimal++;

			/*	if(Round == (Round/2)*2){
					int AppleBoxX = (int)Random.Range(-10,10); 
					int AppleBoxY = (int)Random.Range(-10,10); 
					float DinosaurPositionX = (float)AppleBoxX - 0.5f;
					float DinosaurPositionY = (float)AppleBoxY - 0.5f;
					float DinosaurPositionZ = -1.0f;
					//NewAnimals = Instantiate(Animal_3, new Vector3(DinosaurPositionX,DinosaurPositionY+1.0f,DinosaurPositionZ),transform.rotation)as GameObject;
					Animals[AnimalsKey] =  Instantiate(Animal_3,new Vector3(DinosaurPositionX,DinosaurPositionY,DinosaurPositionZ),transform.rotation) as GameObject ;
					AnimalsKey++;
				}else{//Destroy(NewAnimals);
					Destroy(Animals[(AnimalsKey-1)]);
					AnimalsKey--;}*/break;
			case 4:NumOfAnimal++;

				if(!HoleDestroy&&HoleInit){
					if(Random.Range(-10,10)>0){InitHole1();InitHole2();HoleInit=false;}
				}
				if(HoleDestroy){Destroy(Hole11);Destroy(Hole22);HoleDestroy=false;HoleInit=true;}
				break;

			case 5://Debug.Log("Let Player Go");
				NumOfAnimal=0;
				SetPlayerTrue();AnimalSwitch=false;Round++;
				if(PlayerController.BoxNumX==((int)Hole11.transform.position.x)&&PlayerController.BoxNumY==((int)Hole11.transform.position.y)) HoleDestroy=true;
				else{ if(PlayerController.BoxNumX==((int)Hole22.transform.position.x)&&PlayerController.BoxNumY==((int)Hole22.transform.position.y)) HoleDestroy=true;}
							break;
			
			}
		
		}

	
	}


	void SetAnimalSwitch(bool Switch ){//ThePlayerX is the number of the box player in, in X direction
		PlayerXNum = PlayerController.BoxNumX;
		PlayerYNum = PlayerController.BoxNumY;
		AnimalSwitch = Switch;
		Debug.Log ("SetAnimalSwitchAgain");
	}

	void SetPlayerTrue(){

		PlayerObject.SendMessage ("OnTurn");
	}

	void SetNumOfAnimal(int Set){
		NumOfAnimal = Set;
		Debug.Log ("NumOfAnimalShouldBe "+NumOfAnimal);
	}

	void SetLoseTrue(){
		Lose = true;
	}

	void InitHole1(){
		int AppleBoxX = (int)Random.Range(1,9); 
		int AppleBoxY = (int)Random.Range(-9,9); 
		Hole11BoxX = AppleBoxX;
		Hole11BoxY = AppleBoxY;
		Debug.Log ("hole1"+Hole11BoxX+" "+Hole11BoxY);
		float DinosaurPositionX = (float)AppleBoxX - 0.5f;
		float DinosaurPositionY = (float)AppleBoxY - 0.5f;
		float DinosaurPositionZ = 1.0f;
		//NewAnimals = Instantiate(Animal_3, new Vector3(DinosaurPositionX,DinosaurPositionY+1.0f,DinosaurPositionZ),transform.rotation)as GameObject;
		Hole11 =  Instantiate(Hole2,new Vector3(DinosaurPositionX,DinosaurPositionY,DinosaurPositionZ),transform.rotation) as GameObject ;

		}
	void InitHole2(){
		int AppleBoxX = (int)Random.Range(-9,-1); 
		int AppleBoxY = (int)Random.Range(-9,9); 
		Hole22BoxX = AppleBoxX;
		Hole22BoxY = AppleBoxY;
		Debug.Log ("hole2"+Hole22BoxX+" "+Hole22BoxY);
		float DinosaurPositionX = (float)AppleBoxX - 0.5f;
		float DinosaurPositionY = (float)AppleBoxY - 0.5f;
		float DinosaurPositionZ = 1.0f;
		//NewAnimals = Instantiate(Animal_3, new Vector3(DinosaurPositionX,DinosaurPositionY+1.0f,DinosaurPositionZ),transform.rotation)as GameObject;
		Hole22 =  Instantiate(Hole1,new Vector3(DinosaurPositionX,DinosaurPositionY,DinosaurPositionZ),transform.rotation) as GameObject ;
		
	}

}
