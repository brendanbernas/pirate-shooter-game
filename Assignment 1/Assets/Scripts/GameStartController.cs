/*
 * Name:GameStartController.cs
 * By: Brendan Bernas
 * Last Modified By: Brendan Bernas
 * Date Last Modified: Oct 20, 2017
 * Program Description: Has StartGame() function to start game from main_menu scene
 * Revision History: 1.0
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartController : MonoBehaviour {

	//loads main_scene
	public void StartGame(){
		SceneManager.LoadScene ("main_scene");
	}
}
