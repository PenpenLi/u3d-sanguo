﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkillScrollList : MonoBehaviour {
	public Button btn;

	private SkillHttpRequest skillRequest;
	private List<SkillModel> skills = new List<SkillModel>();

	private float screenW;

	// Use this for initialization
	void Start () {

		RefreshDisplay ();

//		GameObject httpRequestObject = GameObject.FindGameObjectWithTag ("HeroHttpRequest");
//		if (httpRequestObject != null) {
//			heroRequest = httpRequestObject.GetComponent<HeroHttpRequest> ();
//			if (heroRequest == null) {
//				Debug.Log ("HeroHttpRequest script is null");
//			} else {
//				heroRequest.getAllHero (this);
//			}
//		} else {
//			Debug.Log ("httpRequestObject is null");
//		}

		GameObject canvasObj = GameObject.FindGameObjectWithTag ("SkillCanvas");
		if(canvasObj != null){
			screenW = canvasObj.GetComponent<RectTransform> ().rect.width;
		}

		skillRequest = Singleton<SkillHttpRequest>.Instance;
		skillRequest.GetAllSkills (this);
	}

	// Update is called once per frame
	void Update () {

	}

	void RefreshDisplay(){
		AddButtons ();
	}

	void AddButtons(){
		for(int i=0; i<skills.Count; i++){
			Button bt = Instantiate (btn);
			bt.transform.SetParent (transform, true);
			//bt.GetComponent<RectTransform> ().SetPositionAndRotation (new Vector3(0, -i*150, 0), Quaternion.identity);
			bt.GetComponent<RectTransform> ().localPosition= new Vector3(0, -i*150, 0);
			RectTransform rt = bt.GetComponent<RectTransform> ();
			//			rt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Left, 0, 750);
			rt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Top, i*150, 150);

			SkillItem item = bt.GetComponent<SkillItem> ();
			SkillModel model = skills[i];
			item.Bind (model, this);
		}

		RectTransform rootRt = GetComponent<RectTransform> ();
		rootRt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Left, 0, screenW);
		rootRt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Top, 0, skills.Count * 150);
	}

	public void DetailBtnClick(SkillModel skillModel){
		SkillDetailController.skillModel = skillModel;
		SceneManager.LoadScene ("SkillDetail");
	}

	public void GetAllSkillSuccess(List<SkillModel> newSkills){
		skills.Clear ();
		skills.AddRange (newSkills);
		RefreshDisplay ();

		//		HeroModel model = new HeroModel ();
		//		model.nickname = "xx";
		//		heros.Add (model);
		//		RefreshDisplay ();
	}
}
