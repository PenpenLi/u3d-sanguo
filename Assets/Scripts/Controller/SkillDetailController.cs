using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkillDetailController : MonoBehaviour {
	public static SkillModel skillModel;

	public Button backBtn;

	public Text nameText;
	public Text descText;
	public Text skillTypeText;
	public Text soldierTypeText;
	public Text atkDistanceText;
	public Text atkDestDescText;
	public Text condDescText;
	public Text cautionDescText;

	private SkillHttpRequest skillRequest;

	// Use this for initialization
	void Start () {
		backBtn.onClick.AddListener (BackClick);

		nameText.text = skillModel.skillName;
		descText.text = skillModel.desc;
		skillTypeText.text = "战法类型:" + PrefDefine.SKILL_TYPE[skillModel.skillType];
		soldierTypeText.text = "兵种:" + PrefDefine.SOLDIER_TYPE[skillModel.soldierType];
		atkDistanceText.text = "有效距离:" + skillModel.atkDist;
		atkDestDescText.text = "目标群体:" + skillModel.atkDest;

		condDescText.text = skillModel.cond;
		cautionDescText.text = skillModel.caution;
	}

	// Update is called once per frame
	void Update () {

	}

	void BackClick(){
		SceneManager.LoadScene ("Skill");
	}
}