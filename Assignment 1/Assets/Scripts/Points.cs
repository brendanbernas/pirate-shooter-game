/* Name:Life.cs
 * By: Brendan Bernas (modified from MailPilot lab)
 * Last Modified By: Brendan Bernas
 * Date Last Modified: Oct 20, 2017
 * Program Description: Singleton class that allows for tracking of game points in current game
 * 						Update UI when the value changes
 * Revision History: 1.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points{
	private int amount;
	private static Points instance = null;
	private UIController ui;

	//private constructor
	private Points(){
		this.amount = 0;
	}

	//public static instance method to ensure singleton design
	public static Points Instance{
		get{
			if (instance == null)
				instance = new Points();
			return instance;
		}
	}

	//must set UIController after instantiation to allow for UI updates
	public UIController Ui{
		set{ this.ui = value; }
	}

	//public property
	//updates UI when value changes
	public int Amount{
		get{ return amount; }
		set{ 
			this.amount = value;
			ui.UpdatePointsUI ();
		}
	}

}
