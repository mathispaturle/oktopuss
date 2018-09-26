using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

	private Rigidbody rb;
	public float maxSpeed = 5.0f;
	float speed = 8;
	bool hasTreasure = false;
	int score = 0;
	int collected = 0;

	public Text scoreText;
	public Image[] inputsUser;
	public Image[] deathImages;

	Quaternion rotation;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rb.velocity.y, -maxSpeed, maxSpeed));
		scoreText.text = score.ToString ();
		inputHandler ();
	}

	void inputHandler(){

		float h = speed * Input.GetAxis("Horizontal");
		float v = speed * Input.GetAxis("Vertical");

		/*this.transform.eulerAngles = new Vector3(
			this.transform.eulerAngles.x,
			this.transform.eulerAngles.y * v * 90,
			this.transform.eulerAngles.z * h * 90
		);*/



		if (Input/*.GetButtonDown("Fire3")*/.GetKeyDown("space")) {
			rb.AddForce( new Vector3 (h * speed, v * speed, 0));
		}

		if (Input.GetKeyDown ("r")) {
			Application.LoadLevel (0);
		}

		if (Input.GetKey ("w")) {
			setActiveKeys (0);
		} else {
			setInactiveKeys (0);
		}

		if (Input.GetKey ("a")) {
			setActiveKeys (1);
		} else {
			setInactiveKeys (1);
		}

		if (Input.GetKey ("s")) {
			setActiveKeys (2);
		} else {
			setInactiveKeys (2);
		}

		if (Input.GetKey ("d")) {
			setActiveKeys (3);
		} else {
			setInactiveKeys (3);
		}



		if (Input.GetKeyDown ("space")) {
			setActiveKeys (4);
		} else {
			setInactiveKeys (4);
		}

	}

	void setActiveKeys(int num){
		inputsUser [num].gameObject.SetActive (true);
	}

	void setInactiveKeys(int num){
		inputsUser [num].gameObject.SetActive (false);
	}


	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "target") {
			score += collected;
			collected = 0;
			//print ("Your score is: " + score);
		}
	}

	void OnTriggerStay(Collider col){

		if (col.gameObject.tag == "reward") {

			if (Input.GetKeyDown ("a")) {
				collected += 10;
				print (collected);
			}
		}
	}


}
