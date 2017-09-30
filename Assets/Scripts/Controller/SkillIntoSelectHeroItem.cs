using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SkillIntoSelectHeroItem : MonoBehaviour {

	public static Action<HeroModel> DelHeroBtnClick;

	public Text heroNameText;
	public Text percentText;
	public Button delBtn;

	private HeroModel model;

	// Use this for initialization
	void Start () {
		delBtn.onClick.AddListener (DelBtnClick);
	}

	// Update is called once per frame
	void Update () {

	}

	public void Bind(HeroModel hero){
		model = hero;

		heroNameText.text = model.nickname;
		percentText.text = model.canIntoNum + "%";
	}

	public void DelBtnClick(){
		if(DelHeroBtnClick != null){
			DelHeroBtnClick (model);
		}
	}
}
