using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prey : MonoBehaviour {

	private Vector3 velocity;
	// Use this for initialization
	void Start () {
		transform.parent = transform;
		transform.localPosition = new Vector3(Random.Range(0, 0), 0, 0);
		velocity = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));

	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = transform.localPosition + velocity;
	}
}
