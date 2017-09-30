using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SkillUpSkillItem : MonoBehaviour {

	private SkillModel skill;

	public Text skillNameText;
	public Text levelText;
	public Button levelUpBtn;
	public Text upExpText;

	public static Action<SkillModel> SkillLevelUp;

	// Use this for initialization
	void Start () {
		levelUpBtn.onClick.AddListener (LevelUpBtnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Bind(SkillModel skillModel){
		this.skill = skillModel;

		skillNameText.text = skill.skillName;
		levelText.text = "等级:" + skill.level;
		upExpText.text = "升级需要:\n" + skill.canUpExp;
	}

	void LevelUpBtnClick(){
		if(SkillLevelUp != null){
			SkillLevelUp (skill);
		}
	}
}
