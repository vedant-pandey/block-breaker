using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LvlManager levelManager;
	void OnTriggerEnter2D(Collider2D trigger){
		print("Trigger");
		levelManager = GameObject.FindObjectOfType<LvlManager>();
		levelManager.LoadLevel("Lose");
		
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		print("Collision");
	}
}
