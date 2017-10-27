using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	private Prey prey;
	public Prey preyPrefab;

	public BorderWall borderWallPrefab;
	private BorderWall borderWall;

	public int jungleHeight;
	public int jungleWidth;

	public Goal goalPrefab;
	private Goal goal;

	public static int addPrey = 0;

	// Use this for initialization
	void Start () {
		goal = Instantiate (goalPrefab) as Goal;
		goal.transform.position = new Vector3 (10, 0, 10);
		
		generateJungle ();
		int count = 0;
		while (count < 10) {
			prey = Instantiate (preyPrefab) as Prey;
			prey.goal = goal;
			count = count + 1;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (addPrey > 0) {
			prey = Instantiate (preyPrefab) as Prey;
			prey.goal = goal;
			addPrey = addPrey - 1;
		}
	}

	void generateJungle(){
		for(int i = -jungleHeight; i < jungleHeight+1; i++){
			Instantiate(borderWallPrefab, new Vector3(jungleWidth, 0, i), Quaternion.Euler(new Vector3(0, 90, 0)));
			Instantiate(borderWallPrefab, new Vector3(-jungleWidth, 0, i), Quaternion.Euler(new Vector3(0, 90, 0)));
		}
		for(int k = -jungleWidth; k < jungleWidth+1; k++){
			Instantiate(borderWallPrefab, new Vector3(k, 0, jungleHeight), Quaternion.identity);
			Instantiate(borderWallPrefab, new Vector3(k, 0, -jungleHeight), Quaternion.identity);
		}
	}
}
