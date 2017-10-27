using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prey : MonoBehaviour {

	private Vector3 velocity;
	public Rigidbody rb;
	float thrust = 1f;
	Vector3 direction;
	int flag = 0;
	float maxDist = 10f;
	public Goal goal;


	// Use this for initialization
	void Start () {
		goal.transform.position = new Vector3 (10, 0, 10);
		rb = GetComponent<Rigidbody> ();
		float thrust = Random.Range (0, .000000002f);
		transform.parent = transform;
		transform.localPosition = new Vector3(Random.Range(-19, 19), 0, Random.Range(-19, 19));
		//velocity = new Vector3(Random.Range(-.002f, .002f), 0, Random.Range(-.002f, .002f));
		rb.MovePosition(transform.forward * thrust);

	}

	// Update is called once per frame
	void Update () {
		rb = GetComponent<Rigidbody> ();
		Vector3 rotation = transform.rotation.eulerAngles;
		rotation.z = 0;
		transform.rotation = Quaternion.Euler (rotation);
	}

	void FixedUpdate() {

		if ((transform.position - goal.transform.position).magnitude < 2.5f) {
			Destroy (gameObject);
			Manager.addPrey = Manager.addPrey + 1;
		}


		if (transform.position.x > 19 || transform.position.x < -19) {
			rb.MovePosition(transform.forward * thrust * -1f);
		}

		if (flag < 1) {
			direction = determineDirection (transform.position, goal.transform.position);
			flag = Random.Range(15, 80);
		}
		flag = flag - 1;

		transform.LookAt(goal.transform);

		float speed = 0.5f;
		rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
	}

	private Vector3 determineDirection(Vector3 currentPos, Vector3 targetPos) {
		if ((targetPos - currentPos).magnitude < maxDist) {
			return goal.transform.position - currentPos;
		} else {
			Vector3 rand = new Vector3 (Random.Range (-20, 20), 0, Random.Range (-20, 20));
			return rand - currentPos;
		}
	}
		
}
