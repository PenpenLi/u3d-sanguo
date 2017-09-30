using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkillIntoController : MonoBehaviour {

	public Button backBtn;
	public ScrollRect skillScrollList;
	public Button pref;

	public Image skillInfoPanel;

	public Text skillNameText;
	public Text percentText;

	public Button confirmBtn;

	public ScrollRect heroScrollList;
	public Image heroPref;

	public ScrollRect selectHeroScrollList;
	public Image selectHeroPref;

	private List<SkillModel> skillList;
	private List<Button> skillItems;

	private List<HeroModel> heroList;
	private List<Image> heroItems;

	private List<HeroModel> selectHeroList;
	private List<Image> selectHeroItems;

	private SkillModel currentSkillModel;

	private SkillHttpRequest skillRequest;
	private HeroHttpRequest heroRequest;

	void Awake(){
		backBtn.onClick.AddListener (BackClick);

		confirmBtn.onClick.AddListener (ConfirmBtnClick);

		skillRequest = Singleton<SkillHttpRequest>.Instance;
		skillRequest.GetAllIntoSkillsSuccess += GetAllIntoSkillsSuccess;

		heroRequest = Singleton<HeroHttpRequest>.Instance;
		heroRequest.GetAllCanIntoHerosSuccess += GetAllCanIntoHerosSuccess;
		heroRequest.ConvertIntoSkillSuccess += ConvertIntoSkillSuccess;

		SkillIntoItem.SelectSkillClick += SelectSkillClick;
		SkillIntoHeroItem.SkillIntoHeroClick += SkillIntoHeroClick;
		SkillIntoSelectHeroItem.DelHeroBtnClick += DelHeroBtnClick;
	}

	void OnDestroy(){
		skillRequest.GetAllIntoSkillsSuccess -= GetAllIntoSkillsSuccess;
		heroRequest.GetAllCanIntoHerosSuccess -= GetAllCanIntoHerosSuccess;
		heroRequest.ConvertIntoSkillSuccess -= ConvertIntoSkillSuccess;

		SkillIntoItem.SelectSkillClick -= SelectSkillClick;
		SkillIntoHeroItem.SkillIntoHeroClick -= SkillIntoHeroClick;
		SkillIntoSelectHeroItem.DelHeroBtnClick -= DelHeroBtnClick;
	}

	// Use this for initialization
	void Start () {
		skillInfoPanel.gameObject.SetActive (false);

		skillItems = new List<Button> ();
		heroItems = new List<Image> ();
		selectHeroList = new List<HeroModel> ();
		selectHeroItems = new List<Image> ();

		skillRequest.GetAllIntoSkills ();
	}

	// Update is called once per frame
	void Update () {

	}

	void RefreshDisplay(){
		foreach(Button bt in skillItems){
			Destroy (bt.gameObject);
		}
		skillItems.Clear ();
		if(skillList != null){
			foreach(SkillModel skill in skillList){
				Button bt = Instantiate (pref);
				skillItems.Add (bt);
				bt.transform.SetParent (skillScrollList.content.transform, true);

				SkillIntoItem item = bt.GetComponent<SkillIntoItem> ();
				item.Bind (skill);
			}
		}
	}

	void RefreshHeroDisplay(){
		foreach(Image bt in heroItems){
			Destroy (bt.gameObject);
		}
		heroItems.Clear ();
		if(heroList != null){
			foreach(HeroModel hero in heroList){
				Image bt = Instantiate (heroPref);
				heroItems.Add (bt);
				bt.transform.SetParent (heroScrollList.content.transform, true);

				SkillIntoHeroItem item = bt.GetComponent<SkillIntoHeroItem> ();
				item.Bind (hero);
			}
		}
	}

	void RefreshSelectHeroDisplay(){
		foreach(Image bt in selectHeroItems){
			Destroy (bt.gameObject);
		}
		selectHeroItems.Clear ();
		if(selectHeroList != null){
			foreach(HeroModel hero in selectHeroList){
				Image bt = Instantiate (selectHeroPref);
				selectHeroItems.Add (bt);
				bt.transform.SetParent (selectHeroScrollList.content.transform, true);

				SkillIntoSelectHeroItem item = bt.GetComponent<SkillIntoSelectHeroItem> ();
				item.Bind (hero);
			}
		}
	}

	void BackClick(){
		SceneManager.LoadScene ("center");
	}

	void ConfirmBtnClick(){
		heroRequest.ConvertIntoSkill (selectHeroList, currentSkillModel);
	}

	public void GetAllIntoSkillsSuccess(List<SkillModel> skills){
		skillList = skills;
		RefreshDisplay ();
	}

	public void SelectSkillClick(SkillModel skill){
		currentSkillModel = skill;
		skillInfoPanel.gameObject.SetActive (true);
		skillScrollList.gameObject.SetActive (false);
		RefreshSkillInfo ();

		heroRequest.GetAllCanIntoHeros (skill.userSkillId);
	}

	public void GetAllCanIntoHerosSuccess(List<HeroModel> heros){
		heroList = heros;
		RefreshHeroDisplay ();
	}

	public void ConvertIntoSkillSuccess(SkillModel skill){
		selectHeroList.Clear ();
		RefreshSelectHeroDisplay ();
	}

	public void SkillIntoHeroClick(HeroModel hero){
		selectHeroList.Add (hero);
		RefreshSelectHeroDisplay ();

		heroList.Remove (hero);
		RefreshHeroDisplay ();

		currentSkillModel.percent += hero.canIntoNum;
		RefreshSkillInfo ();
	}

	public void DelHeroBtnClick(HeroModel hero){
		selectHeroList.Remove (hero);
		RefreshSelectHeroDisplay ();

		heroList.Add (hero);
		RefreshHeroDisplay ();

		currentSkillModel.percent -= hero.canIntoNum;
		RefreshSkillInfo ();
	}

	void RefreshSkillInfo(){
		skillNameText.text = currentSkillModel.skillName;
		percentText.text = currentSkillModel.percent + "%";
	}

}
