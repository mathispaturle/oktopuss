using UnityEngine;

public class player : MonoBehaviour {

	private Rigidbody rb;
	public float maxSpeed = 5.0f;
	float speed = 8;

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

		if (Input.GetButtonDown("Fire3")) {
			rb.AddForce( new Vector3 (h * speed, v * speed, 0));
		}
	}
}
