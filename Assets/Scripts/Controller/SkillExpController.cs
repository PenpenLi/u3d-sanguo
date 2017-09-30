using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkillExpController : MonoBehaviour {

	public Button backBtn;
	public Image pref;
	public ScrollRect heroScrollList;

	public Text skillPointText;

	private UserHttpRequest userRequest;
	private HeroHttpRequest heroRequest;

	private List<HeroModel> heroList;
	private List<Image> items;

	private UserModel currentUserModel;

	void Awake(){
		backBtn.onClick.AddListener (BackClick);

		userRequest = Singleton<UserHttpRequest>.Instance;
		userRequest.GetSkillPointSuccess += GetSkillPointSuccess;

		heroRequest = Singleton<HeroHttpRequest>.Instance;
		heroRequest.GetAllCanSkillPointHerosSuccess += GetAllCanSkillPointHerosSuccess;
		heroRequest.ConvertToSkillPointSuccess += ConvertToSkillPointSuccess;

		SkillExpHeroItem.FJHero += FJHero;
	}

	void OnDestroy(){
		userRequest.GetSkillPointSuccess -= GetSkillPointSuccess;
		heroRequest.GetAllCanSkillPointHerosSuccess -= GetAllCanSkillPointHerosSuccess;
		heroRequest.ConvertToSkillPointSuccess -= ConvertToSkillPointSuccess;

		SkillExpHeroItem.FJHero -= FJHero;
	}

	// Use this for initialization
	void Start () {
		items = new List<Image> ();
		heroList = new List<HeroModel> ();

		userRequest.GetSkillPoint ();
		heroRequest.GetAllCanSkillPointHeros ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void RefreshDisplay(){
		foreach(Image bt in items){
			Destroy (bt.gameObject);
		}
		items.Clear ();
		if(heroList != null){
			foreach(HeroModel hero in heroList){
				Image bt = Instantiate (pref);
				items.Add (bt);
				bt.transform.SetParent (heroScrollList.content.transform, true);

				SkillExpHeroItem item = bt.GetComponent<SkillExpHeroItem> ();
				item.Bind (hero);
			}
		}
	}

	void RefreshTopUI(){
		skillPointText.text = "战法经验:" + currentUserModel.skillPoint;
	}

	void BackClick(){
		SceneManager.LoadScene ("center");
	}

	public void GetSkillPointSuccess(UserModel userModel){
		currentUserModel = userModel;
		RefreshTopUI ();
	}

	public void GetAllCanSkillPointHerosSuccess(List<HeroModel> heros){
		heroList = heros;
		RefreshDisplay ();
	}

	public void FJHero(HeroModel hero){
		heroRequest.ConvertToSkillPoint (hero);
	}

	public void ConvertToSkillPointSuccess(UserModel userModel){
		currentUserModel = userModel;
		RefreshTopUI ();

		heroRequest.GetAllCanSkillPointHeros ();
	}
}
