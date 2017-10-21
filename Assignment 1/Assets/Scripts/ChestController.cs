/*
 * Name:ChestController.cs
 * By: Brendan Bernas (slightly modified from MailPilot lab)
 * Last Modified By: Brendan Bernas
 * Date Last Modified: Oct 20, 2017
 * Program Description: Controls the behaviour of the chest GameObjects this script is attached to
 * Revision History: 1.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour {

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

	//getting attached objects Transform component
	void Start () {
		_transform = this.gameObject.GetComponent<Transform> ();
		ResetMovePosition ();
	}

	//moving gameObject every frame
	void Update () {
		movePosition += new Vector2 (speed, 0);

		//if gameObject out of bounds, reset it
		if (movePosition.x < endX)
			ResetMovePosition ();

		_transform.position = movePosition;
	}

	//resets the position of gameObject back to spawn
	//can be triggered from other scripts hence public
	public void ResetMovePosition(){
		movePosition = new Vector2 (startX + Random.Range(0, 10), Random.Range (startY, endY));
	}
}
