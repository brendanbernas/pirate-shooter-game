using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points{
	private int amount;
	private static Points instance = null;
	private UIController ui;

	private Points(){
		this.amount = 0;
	}

	public static Points Instance{
		get{
			if (instance == null)
				instance = new Points();
			return instance;
		}
	}

	public UIController Ui{
		set{ this.ui = value; }
	}

	public int Amount{
		get{ return amount; }
		set{ 
			this.amount = value;
			ui.UpdatePointsUI ();
		}
	}

}
