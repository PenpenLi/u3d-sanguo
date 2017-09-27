using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkillSelectController : MonoBehaviour, IHeroHttpRequestDelegate {

	public Button backBtn;
	public ScrollRect content;

	public Image skillPanel;
	public Text heroNameText;
	public Text skillText;
	public Button exSkill1Btn;
	public Button exSkill2Btn;
	public ScrollRect skillContent;

	private HeroHttpRequest heroRequest;

	private SkillHeroScrollList skillHeroScrollList; 

	// Use this for initialization
	void Start () {
		skillPanel.gameObject.SetActive (false);

		backBtn.onClick.AddListener (BackClick);

		heroRequest = Singleton<HeroHttpRequest>.Instance;
		heroRequest.getAllHero (this);

		skillHeroScrollList = content.viewport.GetComponentInChildren<SkillHeroScrollList> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void BackClick(){
		if(skillPanel.gameObject.activeSelf){
			skillPanel.gameObject.SetActive (false);
			content.gameObject.SetActive (true);

			heroRequest.getAllHero (this);
		}else{
			SceneManager.LoadScene ("Center");
		}
	}

	//
	public void GetAllHeroSuccess(List<HeroModel> heros){
		skillHeroScrollList.RefreshHeros (heros, this);
	}

	public void HeroItemClick(HeroModel hero){
		content.gameObject.SetActive (false);
		skillPanel.gameObject.SetActive (true);
		RefreshSkillPanel (hero);
	}

	public void SkillItemClick(SkillModel skill){
		
	}

	void RefreshSkillPanel(HeroModel hero){
		heroNameText.text = hero.nickname;
		skillText.text = hero.skillId;
		exSkill1Btn.GetComponent<Text> ().text = "1";
		exSkill2Btn.GetComponent<Text> ().text = "2";
	}
}
