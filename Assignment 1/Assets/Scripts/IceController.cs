/*
 * Name:IceController.cs
 * By: Brendan Bernas (modified from MailPilot lab)
 * Last Modified By: Brendan Bernas
 * Date Last Modified: Oct 20, 2017
 * Program Description: Controls behaviour of ice game objects that it is attached to
 * Revision History: 1.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceController : MonoBehaviour {

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

	//gets Transform component from the attached ice GameObject for use later
	void Start () {
		_transform = this.gameObject.GetComponent<Transform> ();
		ResetMovePosition ();
	}
	
	//move the ice GameObject in specified direction once every frame
	void Update () {
		movePosition = _transform.position;
		movePosition += new Vector2 (speed, 0);

		//if it is out of bouds, 'respawn' the object
		if (movePosition.x < endX) {
			ResetMovePosition ();
		}
		_transform.position = movePosition;
	}

	//"respawn" ice by resetting position and change appearance of ice
	void ResetMovePosition(){
		movePosition = new Vector2 (startX + Random.Range(0, 10), Random.Range (startY, endY));
		ChangeGameObjectAppearance ();
	}

	//change appearance by changing size of the object
	private void ChangeGameObjectAppearance(){
		//change the size of the game object
		float randomScale = (float)(Random.Range(5,16)) * 0.1f;
		_transform.localScale = new Vector2 (randomScale, randomScale);
	}
}
