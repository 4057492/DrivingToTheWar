﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.FirstPerson{

public class FPSCon : MonoBehaviour {

		private MouseLook mouselook = new MouseLook();
		public bool mouselock = true;


	// Use this for initialization
	void Start () {
			mouselook.Init (transform, transform.GetChild (0));
			mouselook.SetCursorLock (mouselock);
	}
	
	// Update is called once per frame
	void Update () {
			mouselook.LookRotation (transform, transform.GetChild (0));
			mouselook.SetCursorLock (mouselock);
			if(!mouselock){
				this.enabled = false;
			}
	}
	}
}
