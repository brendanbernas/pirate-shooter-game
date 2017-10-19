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

	// Use this for initialization
	void Start () {
		_transform = this.gameObject.GetComponent<Transform> ();
		ResetMovePosition ();
	}

	// Update is called once per frame
	void Update () {
		//movePosition = _transform.position;
		movePosition += new Vector2 (speed, 0);

		if (movePosition.x < endX)
			ResetMovePosition ();

		_transform.position = movePosition;
	}

	public void ResetMovePosition(){
		movePosition = new Vector2 (startX + Random.Range(0, 10), Random.Range (startY, endY));

		//SpawnerController.RemovePositionInUse (movePosition.y);
		//movePosition = new Vector2(startX + Random.Range(0, 10), SpawnerController.GetSpawnYPosition ());
		//SpawnerController.AddPositionInUse (movePosition.y);
	}
}
