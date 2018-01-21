using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private int timesHit;
	private LvlManager levelManager;
	private bool isBreakable;
	
	Color brickColor;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//Keep track of breakable bricks
		if(isBreakable){
			breakableCount++;
		}
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LvlManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if(isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits(){
		timesHit ++;
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();
			GameObject smokePuff = Instantiate(smoke ,transform.position, Quaternion.identity) as GameObject;
			smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
			Destroy(gameObject);
		} else{
			LoadSprites();
		}
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else{
			Debug.LogError("Brick sprite missing.");
		}
	}
	
	//TODO Remove this method after the player wins
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
}
