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
