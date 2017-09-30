using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHeroItem : MonoBehaviour {

	public Button btn;
	public Text nameText;
	public Text skillText;
	public Text exSkill1Text;
	public Text exSkill2Text;

	private SkillHeroScrollList skillHeroScrollList;
	private HeroModel currentHero;

	// Use this for initialization
	void Start () {
		btn.onClick.AddListener (ItemClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Bind(HeroModel hero, SkillHeroScrollList list){
		this.skillHeroScrollList = list;
		this.currentHero = hero;

		nameText.text = hero.nickname;
		if(hero.skill != null){
			skillText.text = hero.skill.skillName;
		}
		if(hero.exSkill1 != null){
			exSkill1Text.text = hero.exSkill1.skillName;
		}
		if(hero.exSkill2 != null){
			exSkill2Text.text = hero.exSkill2.skillName;
		}
	}

	void ItemClick(){
		this.skillHeroScrollList.ItemClick (this.currentHero);
	}
}
