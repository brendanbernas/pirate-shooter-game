/*
 * Name:OceanController.cs
 * By: Brendan Bernas (modified from MailPilot lab)
 * Last Modified By: Brendan Bernas
 * Date Last Modified: Oct 20, 2017
 * Program Description: Controls behaviour of the background ocean game object that it is attached to
 * Revision History: 1.0
 */

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

	//gets ocean objects tranform component
	void Start () {
		_transform = this.gameObject.GetComponent<Transform>();
		currentPosition = _transform.position;
	}
	
	//move ocean left
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

	//reset position
	void ResetCurrentPosition(){
		currentPosition = new Vector2 (startX, 0);
	}
}
