using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSkillItemButton : MonoBehaviour {

	public Button btn;
	public Text skillNameText;
	public Text skillText;
	public Text exSkill1Text;
	public Text statusText;

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
		skillText.text = hero.skillId;
		exSkill1Text.text = "1";
		exSkill2Text.text = "2";
	}

	void ItemClick(){
		this.skillHeroScrollList.ItemClick (this.currentHero);
	}
}
