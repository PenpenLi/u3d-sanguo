using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SkillIntoItem : MonoBehaviour {

	public static Action<SkillModel> SelectSkillClick;

	public Button contentBtn;
	public Text skillNameText;
	public Text percentText;
	public Text descText;

	private SkillModel model;

	// Use this for initialization
	void Start () {
		
		contentBtn.onClick.AddListener (ContentBtnClick);
	}

	// Update is called once per frame
	void Update () {

	}

	public void Bind(SkillModel skillModel){
		model = skillModel;

		skillNameText.text = model.skillName;
		percentText.text = model.percent + "%";
		descText.text = model.desc;
	}

	public void ContentBtnClick(){
		if(SelectSkillClick != null){
			SelectSkillClick (model);
		}
	}
}
