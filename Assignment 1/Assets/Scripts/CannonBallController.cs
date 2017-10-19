using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour {

	public GameObject spawner;
	public Vector2 direction;

	[SerializeField]
	private float speed = 0.03f;
	[SerializeField]
	private float upperYBound = 5.73f;
	[SerializeField]	
	private float lowerYBound = -5.73f;

	private Vector2 trajectory;
	private Transform cannonTransform;


	// Use this for initialization
	void Start () {
		//calculating trajectory
		cannonTransform = this.gameObject.GetComponent<Transform>();
		cannonTransform.position = spawner.GetComponent<Transform> ().position;

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currPos = cannonTransform.position;
		if (currPos.y >= upperYBound || currPos.y <= lowerYBound)
			Destroy (this.gameObject);
		else {
			currPos += direction * speed;
			cannonTransform.position = currPos;
		}
	}


}
