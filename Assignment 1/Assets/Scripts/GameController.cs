using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	[SerializeField]
	private UIController ui;
	[SerializeField]
	private GameObject userShip;

	void Start () {
		
	}

	public void GameOver(){
		ui.ShowGameOver ();
		userShip.gameObject.SetActive (false);
	}
}
