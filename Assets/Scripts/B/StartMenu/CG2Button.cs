﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG2Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnMouseDown()
	{
		SceneChanger.Change("levels", "CG2");
	}
}