/*
 * Name:UserShipController.cs
 * By: Brendan Bernas (taken from MailPilot lab)
 * Last Modified By: Brendan Bernas
 * Date Last Modified: Oct 20, 2017
 * Program Description: Gives function to destroy object from animation
 * Revision History: 1.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {
	public void DestroyMe(){
		Destroy (this.gameObject);
	}
}
