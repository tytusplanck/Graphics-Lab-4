using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prey : MonoBehaviour {

	private Vector3 velocity;
	Rigidbody rb;
	float thrust = 1f;
	// Use this for initialization
	void Start () {

		float thrust = Random.Range (-.000000002f, .000000002f);
		transform.parent = transform;
		transform.localPosition = new Vector3(Random.Range(-19, 19), 0, Random.Range(-19, 19));
		//velocity = new Vector3(Random.Range(-.002f, .002f), 0, Random.Range(-.002f, .002f));
		rb.AddForce(transform.forward * thrust);

	}

	// Update is called once per frame
	void Update () {
		Vector3 rotation = transform.rotation.eulerAngles;
		rotation.z = 2;
		transform.rotation = Quaternion.Euler (rotation);

		if (transform.position.x > 20 || transform.position.x < 20) {
			rb.AddForce (transform.forward * thrust * -1f);
		}
	}
}
