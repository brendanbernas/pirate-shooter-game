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


	private Life life;
	private Points points;

	void Start () {
		life = Life.Instance;
		life.Ui = this;
		life.GameController = this.gameObject.GetComponent<GameController>();
		UpdateLifeUI ();

		points = Points.Instance;
		points.Ui = this;
		UpdatePointsUI ();
	}

	public void UpdatePointsUI(){
		pointsText.text = points.Amount.ToString();
	}

	public void UpdateLifeUI () {
		//updating life amount
		string output = "";
		for (int i = 0; i < life.Amount; i++) {
			if (i % 3 == 0)
				output += " ";
			output += "I";
		}
		hullText.text = output;
	}

	public void ShowGameOver(){
		gameOverScreen.gameObject.SetActive (true);
		gameOverScoreText.text = "Score: " + points.Amount;
		//TODO disable the other stuff;
	}

	public void ShowHealthLow(){
		healthLowOverlay.gameObject.SetActive (true);
	}

	public void ShowDamageTaken(){
		StartCoroutine ("ScreenFlashRed");
	}

	IEnumerator ScreenFlashRed(){
		damageTakenOverlay.gameObject.SetActive (true);
		yield return new WaitForSeconds (0.2f);
		damageTakenOverlay.gameObject.SetActive (false);
	}

	public void ShowFireStatus(bool value){
		if (value) {
			reloadOverlay.gameObject.SetActive (true);
			reloadOverlayText.text = "Ready (Space)";
		} else {
			reloadOverlay.gameObject.SetActive (false);
			reloadOverlayText.text = "Reloading...";
		}
	}

	public void RestartGame(){
		//restarting game
		life.Amount = 30;
		points.Amount = 0;
		SceneManager.LoadScene("main_scene", LoadSceneMode.Single);
	}
}
