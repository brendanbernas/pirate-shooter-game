/*
 * Name:GreyShipController.cs
 * By: Brendan Bernas (modified from MailPilot lab)
 * Last Modified By: Brendan Bernas
 * Date Last Modified: Oct 20, 2017
 * Program Description: Controls behaviour of red pirate game objects that it is attached to
 * Revision History: 1.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPirateController : MonoBehaviour {

	[SerializeField]
	private float startX = 0;
	[SerializeField]
	private float endX = 100;
	[SerializeField]
	private float startY = 0;
	[SerializeField]
	private float endY = 100;
	[SerializeField]
	private float speed = -1;

	private Transform _transform;
	private Vector2 movePosition;

	// gets transform component to move it late
	void Start () {
		_transform = this.gameObject.GetComponent<Transform> ();
		ResetMovePosition ();
	}

	// moves red pirate game object
	void Update () {
		movePosition += new Vector2 (speed, 0);

		//if position is out of bounds it is reset
		if (movePosition.x < endX)
			ResetMovePosition ();

		_transform.position = movePosition;
	}

	//reset the position of the game object
	//is public and can be called from other scripts
	public void ResetMovePosition(){
		movePosition = new Vector2 (startX + Random.Range(0, 10), Random.Range (startY, endY));
	}
}
