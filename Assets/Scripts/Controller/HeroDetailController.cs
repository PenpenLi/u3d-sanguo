using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroDetailController : MonoBehaviour {

	public static HeroModel heroModel;

	public Button backBtn;

	public Text nameText;
	public Text descText;
	public Text costText;
	public Text soldierTypeText;
	public Text atkDistanceText;
	public Text intelligentText;
	public Text atkText;
	public Text towerAtkText;
	public Text defenceText;
	public Text speedText;
	public Text skillDescText;
	public Text exSkillDescText;

	private SkillHttpRequest skillRequest;

	// Use this for initialization
	void Start () {
		backBtn.onClick.AddListener (BackClick);

		nameText.text = heroModel.nickname;
		descText.text = heroModel.desc;
		costText.text = "cost:" + heroModel.cost;
		soldierTypeText.text = "兵种:" + heroModel.type;
		atkDistanceText.text = "攻击距离:" + heroModel.atkDist;
		intelligentText.text = "初始谋略:" + heroModel.intelligence;
		atkText.text = "初始攻击:" + heroModel.attack;
		towerAtkText.text = "初始攻城:" + heroModel.towerAtk;
		defenceText.text = "初始防御:" + heroModel.defence;
		speedText.text = "初始速度:" + heroModel.speed;

		GameObject httpRequestObject = GameObject.FindGameObjectWithTag ("SkillHttpRequest");
		if (httpRequestObject != null) {
			skillRequest = httpRequestObject.GetComponent<SkillHttpRequest> ();
			if (skillRequest == null) {
				Debug.Log ("HeroHttpRequest script is null");
			} else {
				skillRequest.GetSkillById (heroModel.skillId, this);
			}
		} else {
			Debug.Log ("httpRequestObject is null");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void BackClick(){
		SceneManager.LoadScene ("Hero");
	}

	public void GetSkillByIdSuccess(SkillModel skillModel){
		skillDescText.text = skillModel.desc;
	}
}
