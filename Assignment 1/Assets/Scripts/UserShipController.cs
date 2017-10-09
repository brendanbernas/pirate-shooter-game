using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserShipController : MonoBehaviour {
	
	private Rigidbody2D shipRb;

	// Use this for initialization
	void Start () {
		shipRb = this.gameObject.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		float force = 2.0f;
		float userInputVertical = Input.GetAxis ("Vertical");
		float userInputHorizontal = Input.GetAxis ("Horizontal");

		/*
		Vector2 worldRightDirection = this.transform.TransformDirection (Vector2.right);
		Vector2 worldLeftDirection = this.transform.TransformDirection (Vector2.left);


		//adding forces for right and left
		if (userInputVertical > 0) {
			shipRb.AddForce (worldRightDirection * force);
			shipRb.constraints = RigidbodyConstraints2D.None;
		} 
		else if (userInputVertical < 0) {
			shipRb.AddForce (worldLeftDirection * force);
			shipRb.constraints = RigidbodyConstraints2D.None;
		}
		else
			shipRb.constraints = RigidbodyConstraints2D.FreezePositionX;
		

		//shipRb.AddForce (worldRightDirection * force);

		//adding rotation
		if (userInputHorizonal > 0)
			shipRb.MoveRotation (shipRb.rotation - 65 * Time.fixedDeltaTime);
		else if (userInputHorizonal < 0)
			shipRb.MoveRotation (shipRb.rotation + 65 * Time.fixedDeltaTime);
		*/

		/*
		if (userInputVertical > 0)
			shipRb.AddForce (Vector2.right * force);
		else if (userInputVertical < 0)
			shipRb.AddForce (Vector2.left * force);
		*/
		if (userInputHorizontal > 0) {
			shipRb.AddForce (Vector2.down * force);
			shipRb.MoveRotation (shipRb.rotation - 65 * Time.fixedDeltaTime);
		}
			
		else if (userInputHorizontal < 0){
			shipRb.AddForce (Vector2.up * force);
			shipRb.MoveRotation (shipRb.rotation + 65 * Time.fixedDeltaTime);
		}
			
	}
}
