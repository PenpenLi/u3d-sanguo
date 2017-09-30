using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SkillGetItem : MonoBehaviour {

	public static Action<HeroModel> HeroToSkillClick;

	public Button FJBtn;
	public Text nameText;
	public Text exSkillText;

	private HeroModel model;

	public static Action<ProductModel> HeroIntoClick;

	// Use this for initialization
	void Start () {
		FJBtn.onClick.AddListener (FJBtnClick);
	}

	// Update is called once per frame
	void Update () {

	}

	public void Bind(HeroModel heroModel){
		model = heroModel;

		nameText.text = model.nickname;
		exSkillText.text = model.skill.skillName;
	}

	public void FJBtnClick(){
		if(HeroToSkillClick != null){
			HeroToSkillClick (model);
		}
	}
}
