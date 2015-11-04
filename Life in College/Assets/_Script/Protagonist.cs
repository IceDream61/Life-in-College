using UnityEngine;
using System.Collections;

public class Protagonist : MonoBehaviour {
	public Sprite[] lsprites;
	public Sprite[] rsprites;
	public Sprite[] usprites;
	public Sprite[] dsprites;
	public Sprite[] directionSprite;
	public float framesPerSecond;
	public float speed;
	private int direction;
	private SpriteRenderer spriteRenderer;
	private Vector3 moveDirection;
	// Use this for initialization
	void Start () {
		direction = 3;//down
		speed = 3.0f;
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
	}
		
	void  FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		GetComponent<Rigidbody2D> ().velocity = new Vector3(0,0,0);
		if(moveHorizontal!=0){
			Vector3 movement = new Vector3 (moveHorizontal,0,0);
			GetComponent<Rigidbody2D> ().velocity = movement * speed;
		}
		else if(moveVertical!=0){
			Vector3 movement = new Vector3 (0,moveVertical, 0);
			GetComponent<Rigidbody2D> ().velocity = movement * speed;
		}




		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond); 
		index = index % lsprites.Length; 
		if (moveHorizontal > 0) {//right
			spriteRenderer.sprite = rsprites [index];
			direction = 0;


		} else if (moveHorizontal < 0) {//left
			spriteRenderer.sprite = lsprites [index];
			direction = 1;

		} else if(moveVertical>0){//up
			spriteRenderer.sprite = usprites [index];
			direction = 2;
		}else if(moveVertical<0){//down
			spriteRenderer.sprite = dsprites [index];
			direction = 3;
		}
		else {
			if (direction==0) {//right
				spriteRenderer.sprite = directionSprite[ 0 ];
			}
			else if(direction==1){//left
				spriteRenderer.sprite = directionSprite[ 1 ];
			}
			else if(direction==2){//up
				spriteRenderer.sprite = directionSprite[ 2 ];
			}
			else if(direction==3){//down
				spriteRenderer.sprite = directionSprite[ 3 ];
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
