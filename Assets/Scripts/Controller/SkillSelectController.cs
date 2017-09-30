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
	private SkillHttpRequest skillRequest;

	private SkillHeroScrollList skillHeroScrollList; 
	private SkillSkillScrollList skillScrollList;

	private HeroModel currentHero;
	private int currentPosition;

	void Awake(){
		skillHeroScrollList = content.viewport.GetComponentInChildren<SkillHeroScrollList> ();
		skillScrollList = skillContent.viewport.GetComponentInChildren<SkillSkillScrollList> ();

		skillRequest = Singleton<SkillHttpRequest>.Instance;
		heroRequest = Singleton<HeroHttpRequest>.Instance;

		skillRequest.GetAllUserSkillsSuccess += GetAllUserSkillsSuccess;
		heroRequest.AddSkillSuccess += AddSkillSuccess;
	}

	void OnDestroy(){
		skillRequest.GetAllUserSkillsSuccess -= GetAllUserSkillsSuccess;
		heroRequest.AddSkillSuccess -= AddSkillSuccess;
	}

	// Use this for initialization
	void Start () {
		skillPanel.gameObject.SetActive (false);

		backBtn.onClick.AddListener (BackClick);

		exSkill1Btn.onClick.AddListener (ExSkill1BtnClick);
		exSkill2Btn.onClick.AddListener (ExSkill2BtnClick);

		heroRequest.getAllHero ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void BackClick(){
		if(skillPanel.gameObject.activeSelf){
			skillPanel.gameObject.SetActive (false);
			content.gameObject.SetActive (true);

			heroRequest.getAllHero ();
		}else{
			SceneManager.LoadScene ("Center");
		}
	}

	void ExSkill1BtnClick(){
		currentPosition = 1;
		skillRequest.GetAllUserSkills ();
	}

	void ExSkill2BtnClick(){
		currentPosition = 2;
		skillRequest.GetAllUserSkills ();
	}

	//
	public void GetAllHeroSuccess(List<HeroModel> heros){
		skillHeroScrollList.RefreshHeros (heros, this);
	}

	public void HeroItemClick(HeroModel hero){
		currentHero = hero;

		content.gameObject.SetActive (false);
		skillPanel.gameObject.SetActive (true);
		RefreshSkillPanel (hero);
	}

	public void GetAllUserSkillsSuccess(List<SkillModel> skills){
		skillScrollList.RefreshSkills (skills, this);
	}

	public void SkillItemClick(SkillModel skill){
		heroRequest.AddSkill (currentHero, skill, currentPosition);
	}

	void RefreshSkillPanel(HeroModel hero){
		heroNameText.text = hero.nickname;
		if(hero.skill != null){
			skillText.text = hero.skill.skillName;
		}
		if(hero.exSkill1 != null){
			exSkill1Btn.GetComponentInChildren<Text> ().text = hero.exSkill1.skillName;
		}
		if(hero.exSkill2 != null){
			exSkill2Btn.GetComponentInChildren<Text> ().text = hero.exSkill2.skillName;
		}
	}

	public void AddSkillSuccess(HeroModel hero){
		RefreshSkillPanel (hero);
	}
}
