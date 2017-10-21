/*
 * Name:UIController.cs
 * By: Brendan Bernas (modified from MailPilot lab)
 * Last Modified By: Brendan Bernas
 * Date Last Modified: Oct 20, 2017
 * Program Description: Controls behaviour UI
 * Revision History: 1.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	[SerializeField]
	private Text hullText;
	[SerializeField]
	private Text pointsText;
	[SerializeField]
	private Image healthLowOverlay;
	[SerializeField]
	private Image damageTakenOverlay;
	[SerializeField]
	private Image reloadOverlay;
	[SerializeField]
	private Text reloadOverlayText;
	[SerializeField]
	private Image gameOverScreen;
	[SerializeField]
	private Text gameOverScoreText;

	//Life and Points objects
	private Life life;
	private Points points;

	//connecting UI to Life and Points objects
	void Start () {
		life = Life.Instance;
		life.Ui = this;
		life.GameController = this.gameObject.GetComponent<GameController>();
		UpdateLifeUI ();

		points = Points.Instance;
		points.Ui = this;
		UpdatePointsUI ();
	}

	//updating points on UI
	public void UpdatePointsUI(){
		pointsText.text = points.Amount.ToString();
	}

	//updating hull points on UI
	public void UpdateLifeUI () {
		//segments the points into goups of 3 for readiblity
		//ex: instead of IIIIIIIIIIII will be III III III III
		string output = "";
		for (int i = 0; i < life.Amount; i++) {
			if (i % 3 == 0)
				output += " ";
			output += "I";
		}
		hullText.text = output;
	}

	//shows game over on UI
	public void ShowGameOver(){
		gameOverScreen.gameObject.SetActive (true);
		gameOverScoreText.text = "Score: " + points.Amount;
	}

	//shows low health overlay on UI
	public void ShowHealthLow(){
		healthLowOverlay.gameObject.SetActive (true);
	}

	//shows damage has taken on UI
	public void ShowDamageTaken(){
		//will only show for 0.2s (flash of red)
		StartCoroutine ("ScreenFlashRed");
	}

	//coroutine to flash red screen on damage taken
	IEnumerator ScreenFlashRed(){
		damageTakenOverlay.gameObject.SetActive (true);
		yield return new WaitForSeconds (0.2f);
		damageTakenOverlay.gameObject.SetActive (false);
	}

	//updating fire status
	public void ShowFireStatus(bool value){
		if (value) {
			reloadOverlay.gameObject.SetActive (true);
			reloadOverlayText.text = "Ready (Space)";
		} else {
			reloadOverlay.gameObject.SetActive (false);
			reloadOverlayText.text = "Reloading...";
		}
	}

	//restarting game
	public void RestartGame(){
		//restarting points and life
		life.Amount = 30;
		points.Amount = 0;
		//reloading scene
		SceneManager.LoadScene("main_scene", LoadSceneMode.Single);
	}
}
