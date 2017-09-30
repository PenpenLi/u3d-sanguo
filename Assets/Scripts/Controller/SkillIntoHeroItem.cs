using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SkillIntoHeroItem : MonoBehaviour {

	public static Action<HeroModel> SkillIntoHeroClick;

	public Text heroNameText;
	public Text percentText;
	public Text statusText;
	public Button addBtn;

	private HeroModel model;

	// Use this for initialization
	void Start () {

		addBtn.onClick.AddListener (AddBtnClick);
	}

	// Update is called once per frame
	void Update () {

	}

	public void Bind(HeroModel hero){
		model = hero;

		heroNameText.text = model.nickname;
		percentText.text = model.canIntoNum + "%";
		statusText.text = PrefDefine.USER_HERO_STATUS[model.status];
	}

	public void AddBtnClick(){
		if(SkillIntoHeroClick != null){
			SkillIntoHeroClick (model);
		}
	}
}
