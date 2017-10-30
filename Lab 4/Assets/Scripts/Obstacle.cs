using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.parent = transform;
		transform.position = new Vector3(Random.Range(-14, 5), 0, Random.Range(-10, 5));
	}

	// Update is called once per frame
	void Update () {

	}
}
