﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Solder : MonoBehaviour {

	// Use this for initialization
	public Dialog dialog;
	public LockCameraAndShowMenu l;
	public LogManager log;
	public GameObject ca;
	public GameObject con;
	bool isEnd;
	int count = 0;
	void Start () {
		dialog = GameObject.Find("DialogManager").GetComponent<Dialog>();
		log = GameObject.Find("LogManager").GetComponent<LogManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
		StartCoroutine(rotate());

		if (count == 0 && isEnd)
		{
			l.mLock();
			StartCoroutine(f());
		}
		else if (isEnd && count == 1 && !EventButton.buttons[9])
		{
			dialog.show("让我再多看一眼这里的风景吧", new Vector3(0, 0, 0));
		}
		else if (EventButton.buttons[9] && count == 1)
		{
			EventButton.buttons[10] = true;
			StartCoroutine(g());
			count++;
		}
		else if (EventButton.buttons[9] && count == 2)
		{
			dialog.show("再见，士兵，愿你凯旋", new Vector3(0, 0, 0));
		}
	}

	private IEnumerator rotate()
	{
		float i = (ca.transform.eulerAngles.x > 180 ? ca.transform.eulerAngles.x - 360 : ca.transform.eulerAngles.x) - 16;
		float j = con.transform.eulerAngles.y > 180 ? con.transform.eulerAngles.y - 360 : con.transform.eulerAngles.y;

		while ((Mathf.Abs(i) > 0.5) || Mathf.Abs(j) > 0.5)
		{
			if (Mathf.Abs(i) > 0.5)
			{
				ca.transform.Rotate(-(Mathf.Abs(i) / i) * 0.5f, 0, 0);
				i = (ca.transform.eulerAngles.x > 180 ? ca.transform.eulerAngles.x - 360 : ca.transform.eulerAngles.x) - 16;
			}
			if (Mathf.Abs(j) > 0.5)
			{
				con.transform.Rotate(0, (Mathf.Abs(i) / i) * 0.5f, 0);
				j = con.transform.eulerAngles.y > 180 ? con.transform.eulerAngles.y - 360 : con.transform.eulerAngles.y;
			}
			yield return new WaitForSeconds(0.001f);
		}
		isEnd = true;
	}

	IEnumerator f()
	{
		log.show("您好，士兵先生。部队应该已经到达前线了，您为什么在这呢", 2);
		yield return new WaitForSeconds(2);
		dialog.show("我在等人......如果可以的话，我一辈子也不想离开这里", new Vector3(50, 100, 0));
		yield return new WaitForSeconds(3);
		log.show("能为祖国冲锋陷阵是至高无上的荣耀", 2);
		yield return new WaitForSeconds(2);
		dialog.show("或许您说的对吧", new Vector3(100, 100, 1));
		count++;
		l.munLock();
	}

	IEnumerator g()
	{
		log.show("有位夫人托我把这个给你", 2);
		yield return new WaitForSeconds(2);
		dialog.show("这......太谢谢您了，女士！啊，她为什么不亲自来呢.....", new Vector3(100, 100, 0));
		yield return new WaitForSeconds(3);
		log.show("她说她还有些事", 2);
		yield return new WaitForSeconds(2);
		dialog.show("她一定是不想见我......请你帮我把这株花带给她吧，带我转告她，我永远爱她。我要走了，再见", new Vector3(100, 100, 1));
		yield return new WaitForSeconds(3);
		log.show("再见，士兵。我会带到的，愿你凯旋", 2);
		count++;
	}
}
