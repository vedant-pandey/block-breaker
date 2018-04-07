using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private PaddleMove paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<PaddleMove>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			// Lock the ball on the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
				
			// Wait for start signal by on click
			if(Input.GetMouseButtonDown(0)){
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2.0f,2.0f), 10.0f);
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		Vector2 tweak = new Vector2(Random.Range(0f,0.25f),Random.Range(0f,0.25f));
			if(hasStarted){
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;
			//print(rigidbody2D.velocity);
			if(Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) <= 1){
				float ySpeed = this.GetComponent<Rigidbody2D>().velocity.y;
				ySpeed = this.GetComponent<Rigidbody2D>().velocity.y;
				ySpeed = (ySpeed * 2); 
				if (ySpeed == 0) {ySpeed = 1.5f;}
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x,ySpeed);
			}
		}
	}
}
