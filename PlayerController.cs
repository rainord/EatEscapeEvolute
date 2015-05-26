
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 1.0f;
	public static int score = (int)-0.5;
	public static bool turnOnOff = true;
	public static float PlayerX;
	public static float PlayerY;
	public static int BoxNumX;
	public static int BoxNumY;
	GameObject ForApple;
	GameObject ForAnimalCtrl;
	private int Steps;
	private SpriteRenderer TheSpriteRender;
	public Sprite[] Sprites;
	Vector3 PlayerPosition;

	
	float ScreenLUX = -28.0f;//关于屏幕点映射的参数
	float ScreenLUY = 36.0f;
	float ScreenL = 1.0f;
	
	Vector3 p;
	
	
	void Start () {
		Steps = 4;
		score = 0;
		ForApple = GameObject.Find ("Apple");
		ForAnimalCtrl = GameObject.Find ("AnimalController");
		//初始player所在的格子
		BoxNumX = 1;
		BoxNumY = 1;
		TheSpriteRender = GetComponent<Renderer>() as SpriteRenderer;
		TheSpriteRender.sprite = Sprites [0];
	}
	
	// Update is called once per frame
	void Update () {
		
		SetPositionWithBox();
		
		if (Input.GetMouseButtonDown (0)&&turnOnOff) {
			//判断点击的范围是否在移动范围内
			
			
			
			Debug.Log (transform.position + "playerPosition");
			p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if(CheckClick()){
				Debug.Log (p + "mappingPosition1");
				p=MappingPosition(p);
				Debug.Log (p + "mappingPosition");
				
				transform.position = p;

				
				Debug.Log (transform.position + "player");
				
				turnOnOff = false ; // lock the point act
				PlayerX = transform.position.x;
				PlayerY = transform.position.y;
				BoxNumX = SetBoxNum(transform.position .x);
				BoxNumY = SetBoxNum(transform .position .y);
				//判断是否吃到苹果

				if(BoxNumX==Apple.AppleBoxX&&BoxNumY==Apple.AppleBoxY){ForApple.SendMessage("ApplePositionChangeSwitchTrue");
					score++;
					if(score>=1){TheSpriteRender.sprite = Sprites [1];
						Steps+=1;
					}
							}

				if(BoxNumX==AnimalController.Hole11BoxX && BoxNumY==AnimalController.Hole11BoxY){
					Debug.Log("GetHole1");
					BoxNumX=(int)AnimalController.Hole22BoxX;BoxNumY=(int)AnimalController.Hole22BoxY;
					AnimalController.HoleDestroy=true;
				}else {if(BoxNumX==AnimalController.Hole22BoxX && BoxNumY==AnimalController.Hole22BoxY)
					{	Debug.Log("GetHole2");
						BoxNumX=(int)AnimalController.Hole11BoxX;BoxNumY=(int)AnimalController.Hole11BoxY;
						AnimalController.HoleDestroy=true;
					}
					
				}



				ForAnimalCtrl.SendMessage("SetAnimalSwitch",true);
				ForAnimalCtrl.SendMessage("SetNumOfAnimal",1);
				turnOnOff = false ;

			}
			
		}
		
		if (score > 10) {
			Application.LoadLevel("Enjoy");
			
		}
	}
	
	

	
	void OnGUI(){
		GUI.Label (new Rect (10, 10, 120, 20), "Score:" + score.ToString ());
		
		
	}
	
	//switch of player can move or not
	void OnTurn(){
		turnOnOff = true;
		
	}
	//映射坐标到相应方格的中心点

	void SetPositionWithBox(){
		PlayerPosition.x = (float)BoxNumX - 0.5f;
		PlayerPosition.y = (float)BoxNumY - 0.5f;
		PlayerPosition.z = -1.0f;
		transform.position = PlayerPosition;
	}

	Vector3 MappingPosition(Vector3 ThePosition){
		Vector3 MapPosition = ThePosition;
		MapPosition.x = (float)SetBoxNum (MapPosition.x)-0.5f;
		MapPosition.y = (float)SetBoxNum (MapPosition.y)-0.5f;
		MapPosition.z = -1.0f;
		return MapPosition;
		}

	
	int SetBoxNum(float Pos){ //转化成点所在的格子编号,其编号来源于自己右上角的整数点

		int BoxNum;
		if (Pos > 0) {
			BoxNum = (int)(Pos + 1);	
			
		}
		else BoxNum = (int) Pos;
		return BoxNum;
		
		
	}

	//判断点击位置是否在移动范围内
	bool CheckClick(){
		int ClickBoxX = SetBoxNum (p.x);
		int ClickBoxY = SetBoxNum (p.y);
		int CheckX = (ClickBoxX - BoxNumX) >= 0?(ClickBoxX - BoxNumX):-(ClickBoxX - BoxNumX);
		int CheckY = (ClickBoxY - BoxNumY) >= 0?(ClickBoxY - BoxNumY):-(ClickBoxY - BoxNumY);
		bool Check;
		
		if ((CheckX + CheckY) <= Steps)
			Check = true;
		else
			Check = false;
		return Check;
		
		
	}



	
	
	
}
	


	
