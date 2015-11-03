using UnityEngine;
using System.Collections;

public class Protagonist : MonoBehaviour {
	public Sprite[] lsprites;
	public Sprite[] rsprites;
	public Sprite[] directionSprite;
	public float framesPerSecond;
	public float speed;
	private bool startWalk;
	private bool direction;
	private SpriteRenderer spriteRenderer;
	private Vector3 moveDirection;
	// Use this for initialization
	void Start () {
		speed = 3.0f;
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
	}
		
	void  FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3 (moveHorizontal, 0, 0);
		GetComponent<Rigidbody2D> ().velocity = movement * speed;

		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond); 
		index = index % lsprites.Length; 
		if (moveHorizontal > 0) {
			spriteRenderer.sprite = rsprites [index];
			direction = true;
			startWalk=true;

		} else if (moveHorizontal < 0) {
			spriteRenderer.sprite = lsprites [index];
			direction = false;
			startWalk=true;
		} else {
			if (direction&&startWalk) {//right
				spriteRenderer.sprite = directionSprite[ 0 ];
			}
			else if(!direction&&startWalk){//left
				spriteRenderer.sprite = directionSprite[ 1 ];
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
