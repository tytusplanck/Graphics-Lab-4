using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	private Prey prey;
	public Prey preyPrefab;

	// Use this for initialization
	void Start () {
		int count = 0;
		while (count < 10) {
		prey = Instantiate (preyPrefab) as Prey;
			count = count + 1;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
