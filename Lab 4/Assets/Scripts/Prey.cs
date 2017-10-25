using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prey : MonoBehaviour {

	public GameObject prey;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = prey.GetComponent<Rigidbody> ();
		prey.transform.parent = transform;
		prey.transform.localPosition = new Vector3(Random.Range(0, 100), 0, 0);
		rb.AddForce (100, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
