using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prey : MonoBehaviour {

	private Vector3 velocity;
	public Rigidbody rb;
	float thrust = 1f;
	// Use this for initialization
	void Start () {
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
		rotation.y = 0;
		transform.rotation = Quaternion.Euler (rotation);

		if (transform.position.x > 19 || transform.position.x < -19) {
			rb.MovePosition(transform.forward * thrust * -1f);
		}
	}
		
}
