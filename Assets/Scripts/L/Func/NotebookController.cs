﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookController : MonoBehaviour {
	public GameObject[] pages;

	void Start () {
		pages = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			pages [i] = transform.GetChild(i).gameObject;
		}
		pages [EventButton.notePage].SetActive (true);


		//here to control element with eventbuttons
		//pages [0].transform.GetChild (3).gameObject.SetActive (true);
		if(EventButton.buttons[0]){
			pages [0].transform.GetChild (3).gameObject.SetActive (true);
			pages [1].transform.GetChild (4).gameObject.SetActive (true);
		}
		if (EventButton.buttons [1]) {
			pages [1].transform.GetChild (3).gameObject.SetActive (true);
		}
		if(EventButton.buttons[3]){
			pages [0].transform.GetChild (2).gameObject.SetActive (true);
			pages [1].transform.GetChild (5).gameObject.SetActive (true);
		}
		if (EventButton.buttons [4]) {
			pages [1].transform.GetChild (1).gameObject.SetActive (true);
		}
		if (EventButton.buttons [5]) {
			pages [1].transform.GetChild (2).gameObject.SetActive (true);
		}
	}

	void Update () {
		
	}
}
