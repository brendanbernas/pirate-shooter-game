using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCannonBallController : MonoBehaviour {

	public GameObject spawner;
	private Transform objTrans;

	void Start () {
		//set rotate to spawner
		Rigidbody2D spawnerRb = spawner.GetComponent<Rigidbody2D>();
		Rigidbody2D objRb = this.gameObject.GetComponent<Rigidbody2D> ();
		objTrans = this.gameObject.GetComponent<Transform> ();

		Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), spawner.GetComponent<Collider2D> ());
		objTrans.position = spawnerRb.position;
		objTrans.Rotate (0, 0, spawnerRb.rotation);

		StartCoroutine ("DespawnCount");
	}

	void Update () {
		//move local direction right
		//modified from week 3 slides
		float force = 0.1f;
		Vector3 worldRightDirection = objTrans.TransformDirection (Vector2.right * force);
		objTrans.localPosition += worldRightDirection;
	}

	public IEnumerator DespawnCount(){
		yield return new WaitForSeconds (3f);
		Destroy (this.gameObject);
	}
}
