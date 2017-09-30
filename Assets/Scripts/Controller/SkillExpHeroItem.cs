using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SkillExpHeroItem : MonoBehaviour {

	public Text heroNameText;
	public Text expText;
	public Button fjBtn;

	private HeroModel hero;

	public static Action<HeroModel> FJHero;

	// Use this for initialization
	void Start () {
		fjBtn.onClick.AddListener (FJBtnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Bind(HeroModel hero){
		this.hero = hero;
		heroNameText.text = hero.nickname;
		expText.text = "可分解" + hero.canSkillPoint;
	}

	void FJBtnClick(){
		if(FJHero != null){
			FJHero (hero);
		}
	}
}
