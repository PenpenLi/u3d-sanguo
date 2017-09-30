using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSkillItem : MonoBehaviour {

	public Button btn;
	public Text skillNameText;
	public Text skillTypeText;
	public Text soldierTypeText;
	public Text atkDistText;
	public Text atkDestText;
	public Text statusText;

	private SkillSkillScrollList skillScrollList;
	private SkillModel currentSkill;

	// Use this for initialization
	void Start () {
		btn.onClick.AddListener (ItemClick);
	}

	// Update is called once per frame
	void Update () {

	}

	public void Bind(SkillModel skill, SkillSkillScrollList list){
		this.skillScrollList = list;
		this.currentSkill = skill;

		skillNameText.text = skill.skillName;
		skillTypeText.text = "战法类型：" + PrefDefine.SKILL_TYPE[skill.skillType];
		soldierTypeText.text = "士兵类型：" + PrefDefine.SOLDIER_TYPE[skill.soldierType];
		atkDistText.text = "攻击距离：" + skill.atkDist + "";
		atkDestText.text = "攻击目标：" + skill.atkDest;
		if(skill.useHeroId != null){
			statusText.text = "分配给\n" + skill.useHeroModel.nickname;
		}else{
			statusText.text = "未分配";
		}
	}

	void ItemClick(){
		this.skillScrollList.ItemClick (this.currentSkill);
	}
}
