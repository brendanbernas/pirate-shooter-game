using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanController : MonoBehaviour {

	[SerializeField]
	private float speed = -0.1F;
	[SerializeField]
	private float startX = 0;
	[SerializeField]
	private float endX = 100;

	private Vector2 currentPosition;
	private Transform _transform;
	// Use this for initialization
	void Start () {
		_transform = this.gameObject.GetComponent<Transform>();
		currentPosition = _transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//get current position and move it left
		currentPosition = _transform.position;
		currentPosition += new Vector2 (speed, 0);

		//if the current position is greater than endX reset the current position to start
		if (currentPosition.x < endX)
			ResetCurrentPosition ();

		//apply the transformation to the object
		_transform.position = currentPosition;
	}

	void ResetCurrentPosition(){
		currentPosition = new Vector2 (startX, 0);
	}
}
