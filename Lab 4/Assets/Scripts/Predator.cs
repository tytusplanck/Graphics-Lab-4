using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : MonoBehaviour {

	private Vector3 velocity;
	public Rigidbody rb;
	float thrust = 1f;
	Vector3 direction;
	int flag = 0;
	float maxDist = 10f;
	float speed = 1.0f;
	float predSight = 8.0f;

	GameObject goal;


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
		float thrust = Random.Range (0, .000000002f);
		transform.parent = transform;
		transform.localPosition = new Vector3(Random.Range(-19, 19), 0, Random.Range(-19, 19));
		//velocity = new Vector3(Random.Range(-.002f, .002f), 0, Random.Range(-.002f, .002f));
		rb.MovePosition(transform.forward * thrust);
		goal = GameObject.Find ("goal");


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		if (transform.position.x > 29 || transform.position.x < -29 || transform.position.z > 29 || transform.position.z < -29) {
			goal = GameObject.Find ("goal");
			print (goal);
			direction = goal.transform.position - transform.position;
			flag = 20;
		}

		if (flag < 1) {
			direction = searchForPrey (); //need to find position of nearest prey
			//flag = Random.Range(15, 40);
		}
		flag = flag - 1;

		rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
	}

	private Vector3 searchForPrey() {
		GameObject[] preyArray = new GameObject[9];
		preyArray = findPrey ();
		int closestIndex = findClosestPrey (preyArray);
		Vector3 preyDirection;

		if (closestIndex >= 0) {
			preyDirection = preyArray [closestIndex].transform.position - transform.position;
			//rb.MovePosition (transform.position + direction * speed * Time.fixedDeltaTime);
			transform.LookAt(preyArray[closestIndex].transform.position);
		} else {
			preyDirection = new Vector3 (Random.Range (-25, 25), 0, Random.Range (-25, 25));
			transform.LookAt (preyDirection);
			//rb.MovePosition (transform.position + rand * speed * Time.fixedDeltaTime);
			flag = Random.Range(15, 20);

		}
		return preyDirection;
	}

	private GameObject[] findPrey() {
		GameObject[] preyArray;
		preyArray = new GameObject[10];
		preyArray [0] = GameObject.Find ("prey0");
		preyArray [1] = GameObject.Find ("prey1");
		preyArray [2] = GameObject.Find ("prey2");
		preyArray [3] = GameObject.Find ("prey3");
		preyArray [4] = GameObject.Find ("prey4");
		preyArray [5] = GameObject.Find ("prey5");
		preyArray [6] = GameObject.Find ("prey6");
		preyArray [7] = GameObject.Find ("prey7");
		preyArray [8] = GameObject.Find ("prey8");
		preyArray [9] = GameObject.Find ("prey9");
		return preyArray;
	}

	//finds prey or returns -1 if random
	private int findClosestPrey(GameObject[] preyArray) {
		int count = 1;
		int closest = -1;
		GameObject closestPrey = preyArray [0];
		while (count < 10) {
			if ((transform.position - preyArray [count].transform.position).magnitude < (transform.position - closestPrey.transform.position).magnitude && (transform.position - preyArray[count].transform.position).magnitude < predSight) {
				//if (transform.rotation.y - (preyArray[count].transform.rotation - transform.rotation) < 90 &&  transform.rotation.y - (preyArray[count].transform.rotation - transform.rotation) > -90) {
				if (Vector3.Angle (transform.forward, preyArray [count].transform.position - transform.position) < 180) {
					closest = count;
					//print ("In FOV");
				} else {
					//print ("Random");
				}

			}
			count = count + 1;
		}
		return closest;
	}

}
