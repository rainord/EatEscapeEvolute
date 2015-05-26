using UnityEngine;
using System.Collections;

public class Tiger : MonoBehaviour {

	float dx ;
	float dy ;
	GameObject ForPlayer;
	GameObject ForAnimalCTRL;
	public static  bool IfMove=false;
	public static bool IfCheckAttack=false;
	private int TigerSteps=3;
	private Vector3 AttackP;

	public Sprite[] Sprites;
	public float FramePerSecond = 10.0f;
	private SpriteRenderer TheSpriteRender;
	bool AttackPlayer;
	private int TigerBoxX = 7;
	private int TigerBoxY = -7;
	private float TigerX = 6.5f;
	private float TigerY = -6.5f;



	float ScreenL = 1.0f;



	// Use this for initialization
	void Start () {
		ForPlayer = GameObject.Find ("player");//To comunicate with player
		ForAnimalCTRL = GameObject.Find ("AnimalController");

		TheSpriteRender = GetComponent<Renderer>() as SpriteRenderer;

	}
	
	// Update is called once per frame
	void Update () {



				if (IfMove) {
		//	Debug.Log ("Tiger"+transform.position.x+" "+transform.position.y+""+transform.position.z);

						int index = (int)(Time.timeSinceLevelLoad * FramePerSecond);
						index = index % Sprites.Length;
						TheSpriteRender.sprite = Sprites [index];
			//Debug.Log ("TigerShouldLogSpriteNumber "+index);
						if (IfCheckAttack) {
				Debug.Log("whyIfCheckTigerAttackComeToTrueAgain");
				bool TheCheck = CheckAttack();
				IfCheckAttack = false;
								if (TheCheck) {
					TigerBoxX = AnimalController.PlayerXNum;
					TigerBoxY = AnimalController.PlayerYNum;
					AttackPlayer = true;
				} else{//如果不能攻击到，则选择一个行走的方式
					AttackPlayer=false;
				if (TigerBoxX == PlayerController.BoxNumX) {
										if (TigerBoxY > PlayerController.BoxNumY)
												TigerBoxY -= TigerSteps;
										else
												TigerBoxY += TigerSteps;

								}
								if (TigerBoxY == PlayerController.BoxNumY) {
										if (TigerBoxX > PlayerController.BoxNumX)
												TigerBoxX -= TigerSteps;
										else
												TigerBoxX += TigerSteps;

								} else {
										if (TigerBoxX == (PlayerController.BoxNumX + 1)) {
												TigerBoxX -= 1;
												if (TigerBoxY > PlayerController.BoxNumY)
														TigerBoxY -= (TigerSteps - 1);
												else
														TigerBoxY += (TigerSteps + 1);

										} else {
												if (TigerBoxX == (PlayerController.BoxNumX - 1)) {
														TigerBoxX -= 1;
														if (TigerBoxY > PlayerController.BoxNumY)
																TigerBoxY -= (TigerSteps - 1);
														else
																TigerBoxY += (TigerSteps + 1);
												}
						else{if(TigerBoxX>PlayerController.BoxNumX){
								if(TigerBoxY>PlayerController.BoxNumY){
									TigerBoxX-=2;
									TigerBoxY-=1;

								}
								else{TigerBoxX-=2;
									TigerBoxY+=1;}

							}else{if(TigerBoxY>PlayerController.BoxNumY){
									TigerBoxX+=2;
									TigerBoxY-=1;
									
								}
								else{TigerBoxX+=2;
									TigerBoxY+=1;}
									}

								}
							}

					}}

			
			}



								transform.position = Vector3.Lerp (transform.position, new Vector3 ((float)TigerBoxX-0.5f, (float)TigerBoxY-0.5f, -1.0f), Time.deltaTime);
			if ((-0.1f<(transform.position.x - (float)TigerBoxX+0.5f) &&(transform.position.x - (float)TigerBoxX+0.5f)<0.1f )&&((transform.position.y - (float)TigerBoxY+0.5f)>-0.1f&& (transform.position.y - (float)TigerBoxY+0.5f) <0.1f)) {
				Debug.Log("TigerShouldBeStopped");
				IfMove = false;
				TheSpriteRender.sprite = Sprites [0];
				if(AttackPlayer)ForAnimalCTRL.SendMessage("SetLoseTrue");
				//ForAnimalCTRL.SendMessage("SetNumOfAnimal",2);
				ForAnimalCTRL.SendMessage ("SetAnimalSwitch", true);
					
								}

				}
		}
	void Move(bool BoolMove){

		IfMove = BoolMove;
		IfCheckAttack = BoolMove;




	}

	//判断能否吃到
	bool CheckAttack(){
		int CheckX = ((TigerBoxX - PlayerController.BoxNumX) >= 0?(TigerBoxX - PlayerController.BoxNumX):-(TigerBoxX - PlayerController.BoxNumX));//判断player位置与怪物位置的距离
		int CheckY =((TigerBoxY - PlayerController.BoxNumY) >= 0?(TigerBoxY - PlayerController.BoxNumY):-(TigerBoxY - PlayerController.BoxNumY));
		bool CheckAttack;
		if ((CheckX + CheckY) < TigerSteps)
						CheckAttack = true;
				else
						CheckAttack = false;
		
		IfCheckAttack = false;
			return CheckAttack;


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
		if (Pos < 0) {
			BoxNum = (int)(Pos + 1);	
			
		}
		else BoxNum = (int) Pos;
		return BoxNum;
		
		
	}




}
