/*
 * Name:GameController.cs
 * By: Brendan Bernas
 * Last Modified By: Brendan Bernas
 * Date Last Modified: Oct 20, 2017
 * Program Description: Has GameOver() function to bring game to game end state
 * Revision History: 1.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	[SerializeField]
	private UIController ui;
	[SerializeField]
	private GameObject userShip;

	//brings game to end state
	public void GameOver(){
		//shows game over on ui (also hiding the screen)
		ui.ShowGameOver ();
		//disables the user avatar
		userShip.gameObject.SetActive (false);
	}
}
