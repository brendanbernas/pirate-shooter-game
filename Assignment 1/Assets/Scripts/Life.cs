/*
 * Name:Life.cs
 * By: Brendan Bernas (modified from MailPilot lab)
 * Last Modified By: Brendan Bernas
 * Date Last Modified: Oct 20, 2017
 * Program Description: Singleton class that allows for tracking of life (hull points) in current game
 * 						Update UI when the value changes
 * Revision History: 1.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life{
	private int amount;
	private static Life instance = null;
	private UIController ui;
	private GameController gc;

	//private instantiator
	private Life(int amount){
		this.amount = amount;
	}

	//public property to access private instantiator
	public static Life Instance{
		get{
			if (instance == null)
				instance = new Life (30);
			return instance;
		}
	}

	//must set UIController after instantiation to allow for UI updates
	public UIController Ui{
		set{ this.ui = value; }
	}

	public GameController GameController{
		set{ this.gc = value; }
	}

	//property to get an set amount
	//update the UI whenever the amount is updated
	public int Amount{
		get{return amount;}
		set{
			this.amount = value;
			ui.UpdateLifeUI ();
			ui.ShowDamageTaken ();
			if (this.amount <= 6)
				ui.ShowHealthLow ();
			if (this.amount <= 0)
				gc.GameOver ();
		}
	}
}
