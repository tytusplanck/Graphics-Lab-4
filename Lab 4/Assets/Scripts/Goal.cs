using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.parent = transform;
		transform.localPosition = new Vector3(10, 0, 10);
		transform.name = "goal";

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
