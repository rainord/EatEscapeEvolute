using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour {
	
	float dx ;
	float dy ;
	GameObject ForPlayer;
	GameObject ForAnimalCTRL;
	public static  bool IfMove=false;
	public static bool IfCheckAttack=false;
	private int TigerSteps=4;
	private Vector3 AttackP;
	private int CheckX;
	private int CheckY;
	bool AttackPlayer;

	public Sprite[] Sprites;
	public float FramePerSecond = 10.0f;
	private SpriteRenderer TheSpriteRender;
	
	private int TigerBoxX = 4;
	private int TigerBoxY = 5;
	private float TigerX = 3.5f;
	private float TigerY = 4.5f;
	
	
	float ScreenLUX = -28.0f;//关于屏幕点映射的参数
	float ScreenLUY = 36.0f;
	float ScreenW = 56.0f;
	float ScreenH = 72.0f;
	float ScreenL = 1.0f;
	
	
	
	// Use this for initialization
	void Start () {
		//ForPlayer = GameObject.Find ("player");//To comunicate with player
		ForAnimalCTRL = GameObject.Find ("AnimalController");
		AttackPlayer=false;
		TheSpriteRender = GetComponent<Renderer>() as SpriteRenderer;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		if (IfMove) {
			//ForAnimalCTRL.SendMessage("SetAnimalSwitch",false);
			//Debug.Log ("SnakeAnimation");
			int index = (int)(Time.timeSinceLevelLoad * FramePerSecond);
			index = index % Sprites.Length;
			TheSpriteRender.sprite = Sprites [index];
			if (IfCheckAttack) {//判断是否需要设定行走路线
				Debug.Log("whyIfCheckAttaceSnakeComeToTrueAgain");
				bool TheCheck = CheckAttack();

				if (TheCheck) {
					TigerBoxX = AnimalController.PlayerXNum;
					TigerBoxY = AnimalController.PlayerYNum;
					AttackPlayer = true;
						 		} else{
					AttackPlayer=false;
					if(CheckX*CheckX<CheckY*CheckY){//x方向距离长还是y方向距离长
						if(CheckY*CheckY<=17)TigerBoxY-=CheckY;
							else TigerBoxY = CheckY<0?(TigerBoxY+=4):(TigerBoxY-=4);
						}else{if(CheckX*CheckX<=17) TigerBoxX-=CheckX;
						else TigerBoxX = CheckX<0?(TigerBoxX+=4):(TigerBoxX-=4);

					}

				}
				
				
			}
			
			Debug.Log("SnakeBox"+TigerBoxX+" "+TigerBoxY);
			
			transform.position = Vector3.Lerp (transform.position, new Vector3 ((float)TigerBoxX-0.5f, (float)TigerBoxY-0.5f, -1.0f), Time.deltaTime);
			if (((transform.position.x -(float)TigerBoxX+0.5f)>-0.1f&&(transform.position.x - (float)TigerBoxX+0.5f)<0.1f )&&((transform.position.y - (float)TigerBoxY+0.5f)>-0.1f&& (transform.position.y - (float)TigerBoxY+0.5f) <0.1f)){
				//Debug.Log ("TurnSnakeAnimationOff");
				//ForAnimalCTRL.SendMessage("SetNumOfAnimal",3);
				if(AttackPlayer)ForAnimalCTRL.SendMessage("SetLoseTrue");
				ForAnimalCTRL.SendMessage ("SetAnimalSwitch", true);
				TheSpriteRender.sprite = Sprites [0];
				IfMove = false;
			}
			
			//Move (IfMove);
			
			
			
		}
	}
	void Move(bool BoolMove){
		
		IfMove = BoolMove;
		IfCheckAttack = BoolMove;
		
	}
	
	//判断能否吃到
	bool CheckAttack(){
		CheckX = (TigerBoxX - PlayerController.BoxNumX);//判断player位置与怪物位置的距离
		CheckY = (TigerBoxY - PlayerController.BoxNumY);// >= 0?(TigerBoxY - PlayerController.BoxNumY):-(TigerBoxY - PlayerController.BoxNumY);
		bool IneCheckAttack;
		if ((CheckY == 0 && (-4 <= CheckX && CheckX <= 4)) || ((CheckX == 0) && (-4 <= CheckY && CheckY <= 4))) {//能攻击到
						Debug.Log ("ATTACK Player");
						IneCheckAttack = true;
				} else {
						Debug.Log ("Cant ATTACK Player");
						IneCheckAttack = false;
				}
			IfCheckAttack = false;	
		return IneCheckAttack;
			}
	
	
	Vector3 TigerMappingPosition(Vector3 ThePosition){
		Vector3 MapPosition = ThePosition;
		MapPosition.x = (float)TigerSetBoxNum (MapPosition.x)-0.5f;
		MapPosition.y = (float)TigerSetBoxNum (MapPosition.y)-0.5f;
		MapPosition.z = -1.0f;
		return MapPosition;
		
	}
	
	int TigerSetBoxNum(float Pos){//转化成点所在的格子编号
		int BoxNum;
		if (Pos > 0) {
			BoxNum = (int)(Pos + 1);	
			
		}
		else BoxNum = (int) Pos;
		return BoxNum;
		
		
	}
	
	
	
	
}
