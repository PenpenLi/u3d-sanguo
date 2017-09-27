using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillItem : MonoBehaviour {

	public Button buttonComponent;
	public Text nameText;
	public Text skillTypeText;
	public Text soldierTypeText;

	private SkillModel model;
	private SkillScrollList scrollList;

	// Use this for initialization
	void Start () {
		buttonComponent.onClick.AddListener (HandleClick);
	}

	// Update is called once per frame
	void Update () {

	}

	public void Bind(SkillModel heroModel, SkillScrollList heroScrollList){
		model = heroModel;
		scrollList = heroScrollList;

		nameText.text = model.skillName;
		skillTypeText.text = "战法类型:" + PrefDefine.SKILL_TYPE[model.skillType];
		soldierTypeText.text = "兵种:" + PrefDefine.SOLDIER_TYPE[model.soldierType];
	}

	public void HandleClick(){
		scrollList.DetailBtnClick (model);
	}
}
