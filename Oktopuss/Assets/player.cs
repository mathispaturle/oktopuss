using UnityEngine;

public class player : MonoBehaviour {

	private Rigidbody rb;
	public float maxSpeed = 5.0f;
	float speed = 8;
	bool hasTreasure = false;
	int score = 0;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rb.velocity.y, -maxSpeed, maxSpeed));

		inputHandler ();
	}

	void inputHandler(){

		float h = speed * Input.GetAxis("Horizontal");
		float v = speed * Input.GetAxis("Vertical");

		if (Input/*.GetButtonDown("Fire3")*/.GetKeyDown("space")) {
			rb.AddForce( new Vector3 (h * speed, v * speed, 0));
		}
	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "reward") {
			hasTreasure = true;
			print ("Player took treasure");
		}

		if (col.gameObject.tag == "target") {
			if (hasTreasure) {
				print ("Player released treasure: " + score);
				score++;
				hasTreasure = false;
			}
		}

	}
}
