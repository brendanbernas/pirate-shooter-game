﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserShipCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag.Equals("ice"))
		{
			Debug.Log("hit ice");
			//loss life
		}
	}
}
