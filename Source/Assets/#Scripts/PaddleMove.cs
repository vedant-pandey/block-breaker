using UnityEngine;
using System.Collections;

public class PaddleMove : MonoBehaviour {


	public bool autoPlay = false;
	public bool randomMove = false;
	
	private Ball ball;
	
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoPlay){
			MoveWithMouse();
		} else{
			AutoPlay();
		}
	}
	
	void MoveWithMouse(){
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePos = new Vector3 (mousePosInBlocks, this.transform.position.y, 0f);
		paddlePos.x = Mathf.Clamp(mousePosInBlocks,1.0f,15.0f);
		this.transform.position = paddlePos;
	}
	
	void AutoPlay(){
		float ballPos;
		if(!randomMove)
		{
			ballPos = ball.transform.position.x;
		} else{
			ballPos = Random.Range(ball.transform.position.x-1.0f,ball.transform.position.x+1.0f);
		}
		Vector3 paddlePos = new Vector3 (ballPos, this.transform.position.y, 0f);
		paddlePos.x = Mathf.Clamp(ballPos,1.0f,15.0f);
		this.transform.position = paddlePos;
	}
}
